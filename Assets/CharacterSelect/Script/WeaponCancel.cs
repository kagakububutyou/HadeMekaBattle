/*
 *  武器をキャンセルするスクリプト
 * 
 *  決め事
 * 
 *  命名規則：   Pascal形式　例) AttackCount; Camel形式
 *      名前空間 Pascal形式　クラス、構造体　Pascal形式　プロパティ　Pascal形式
 *      メンバ変数(フィールド)　Camel形式　メソッド　Pascal形式　パラメータ　Camel形式
 *      
 *  メソット    1メソッド10行以内　最大2インデント　名前をわかりやすく
 *  Property    getのみ行う　setは、プライベート
 * 
 * SendMessageを使わない　Editorから読み込むだけなら[Serialize Failed]を使用する
 * 
 * 状態管理をしっかり行う　ジェネリック思考で考える
 * 
 * Code by shinnnosuke hiratsuka
 * 
 * 2015/07/11 書き始める
 * 2015/07/14 コメントつける
 * 2015/07/21 リファクタリング
 * 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
/// <summary>
/// 武器をキャンセルする
/// </summary>
public class WeaponCancel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    /// <summary>
    /// GamePadのカメラ
    /// </summary>
    private Camera padCamera = null;

    /// <summary>
    /// 武器装備のパネル
    /// </summary>
    private RectTransform panel = null;

    /// <summary>
    /// 選択しているかどうか？
    /// </summary>
    private bool isSelect = false;

    /// <summary>
    /// 押しっぱなし時に呼び出すイベント
    /// </summary>
    public UnityEvent onLongPress = new UnityEvent();
    /// <summary>
    /// 押しっぱなし判定の間隔（この間隔毎にイベントが呼ばれる）
    /// </summary>
    private float intervalAction = 0.2f;
   
    /// <summary>
    /// 次の押下判定時間
    /// </summary>
    private float nextTime = 0f;

    /// <summary>
    /// 押下状態
    /// </summary>
    public bool pressed
    {
        get;
        private set;
    }
    /// <summary>
    /// 武器装備のキャンパス
    /// </summary>
    private Canvas canvas = null;
    /// <summary>
    /// 武器のID
    /// </summary>
    private BuildManager.WeaponID weaponID = BuildManager.WeaponID.NULL;
    /// <summary>
    /// 武器のステータス表示
    /// </summary>
    [SerializeField]
    private WeaponStatusChanger weaponStatusChanger = null;

    /// <summary>
    /// パネルの設定
    /// </summary>
    /// <param name="rectTrans"></param>
    public void SetNowPanel(RectTransform rectTrans)
    {
        panel = rectTrans;

    }
    /// <summary>
    /// 武器のIdをもらってくる
    /// </summary>
    /// <param name="weaponID">武器のID</param>
    public void GetWeaponID(BuildManager.WeaponID weaponID)
    {
        this.weaponID = weaponID;
    }

	// Use this for initialization
	private void Start () 
    {
        padCamera = GameObject.Find("GamePad Camera").GetComponent<Camera>();
        weaponStatusChanger = GameObject.Find("Status Panel").GetComponent<WeaponStatusChanger>();
	}

    /// <summary>
    /// ボタンをおした時の処理
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;      
        nextTime = Time.realtimeSinceStartup + intervalAction;

        transform.localScale = new Vector3(10.0f, 10.0f, 1);        //  サイズ変更
        canvas = GameObject.Find("EquippedWeaponCanvas").GetComponent<Canvas>();
        canvas.sortingOrder = 2;    //  オーダーレイヤーを変える
        isSelect = true;
        weaponStatusChanger.Change(weaponID);       //  ステータスの変更

    }

    /// <summary>
    /// ボタンを離した時の処理
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        isSelect = false;   

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            //  Panelとあたっていなかったら
            if (hit.collider.gameObject != panel.gameObject)
            {
                Destroy(gameObject);
                WeaponEquipment weaponEquipment = GameObject.Find(panel.name).GetComponent<WeaponEquipment>();
                weaponEquipment.WeaponCancel();
            }
            else 
            {
                transform.position = panel.transform.position;
                transform.localScale = new Vector3(1.0f, 1.0f, 1);        //  サイズ変更
            }
        }
        canvas.sortingOrder = 0;    //  オーダーレイヤーを変える
    }

	// Update is called once per frame
	private void Update ()
    {
        // ボタンが押した時と離した時が同時にならないようにしている処理
        if (pressed && nextTime < Time.realtimeSinceStartup)
        {
            onLongPress.Invoke();
            nextTime = Time.realtimeSinceStartup + intervalAction;
        }

        if (!isSelect) return;  //  選択していなかったら戻る

        //  選択した瞬間
        if (Input.GetMouseButton(0))
        {
            var mousePos = Input.mousePosition;
            mousePos.z = 10.0f;
            var worldPos = padCamera.ScreenToWorldPoint(mousePos);
            gameObject.transform.position = worldPos;
        }
	}
}
