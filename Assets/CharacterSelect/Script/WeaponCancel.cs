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
 * 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WeaponCancel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private Camera padCamera = null;

    private RectTransform panel = null;

    //
    bool isSelect = false;

    /// <summary>
    /// 押しっぱなし時に呼び出すイベント
    /// </summary>
    public UnityEvent onLongPress = new UnityEvent();
    /// <summary>
    /// 押しっぱなし判定の間隔（この間隔毎にイベントが呼ばれる）
    /// </summary>
    float intervalAction = 0.2f;
    /// <summary>
    /// 押下開始時にもイベントを呼び出すフラグ
    /// </summary>
    bool callEventFirstPress;

    /// <summary>
    /// 次の押下判定時間
    /// </summary>
    float nextTime = 0f;

    /// <summary>
    /// 押下状態
    /// </summary>
    public bool pressed
    {
        get;
        private set;
    }
    Canvas canvas = null;

    public void SetNowPanel(RectTransform rectTrans)
    {
        panel = rectTrans;

    }


	// Use this for initialization
	private void Start () 
    {
        padCamera = GameObject.Find("GamePad Camera").GetComponent<Camera>();
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
        canvas.sortingOrder = 2;
        isSelect = true;
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
            //  Panelとあたっていたら
            if (hit.collider.gameObject != panel.gameObject)
            {
                Destroy(gameObject);
            }
            else 
            {
                transform.position = panel.transform.position;
                transform.localScale = new Vector3(1.0f, 1.0f, 1);        //  サイズ変更
            }
        }
        canvas.sortingOrder = 0;

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
