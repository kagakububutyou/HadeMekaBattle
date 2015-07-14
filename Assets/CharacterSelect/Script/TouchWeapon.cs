/*
 *  武器のタッチを取得するスクリプト
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
 * 2015/07/10 書き始める
 * 2018/07/14 コメントつける
 *            Parentの設定の変更
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// 武器ののタッチを取得するスクリプト
/// </summary>
public class TouchWeapon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    /// <summary>
    /// 自分自身
    /// </summary>
    [SerializeField]
    private Button characterButton = null;  

    /// <summary>
    /// お父さんの設定
    /// </summary>
    [SerializeField]
    private GameObject myFather = null;

    /// <summary>
    /// 押しっぱなし時に呼び出すイベント
    /// </summary>
    public UnityEvent onLongPress = new UnityEvent();
    /// <summary>
    /// 押しっぱなし判定の間隔（この間隔毎にイベントが呼ばれる）
    /// </summary>
    float intervalAction = 0.2f;

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
    /// <summary>
    /// カメラ取得
    /// </summary>
    Camera padCamera = null;
    /// <summary>
    /// ボタン生成に使う
    /// </summary>
    Button clone = null;
	// Use this for initialization
	private void Start () 
    {
        //カメラ取得
        padCamera = GameObject.Find("GamePad Camera").GetComponent<Camera>();
    }

    /// <summary>
    /// ボタンをおした時の処理
    /// </summary>
    /// <param name="eventData"></param>
	public void OnPointerDown (PointerEventData eventData)
    {
        pressed = true;
        OnTouch();
        nextTime = Time.realtimeSinceStartup + intervalAction;
	}

    /// <summary>
    /// ボタンを離した時の処理
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

	// Update is called once per frame
	void Update () 
    {
        // ボタンが押した時と離した時が同時にならないようにしている処理
        if (pressed && nextTime < Time.realtimeSinceStartup)
        {
            onLongPress.Invoke();
            nextTime = Time.realtimeSinceStartup + intervalAction;
        }
	}

    /// <summary>
    /// ボタンが押された時
    /// </summary>
    private void OnTouch()
    {
        TouchInstantiate(characterButton);
    }

    /// <summary>
    /// タッチされたら分身する
    /// </summary>
    private void TouchInstantiate(Button myButton)
    {
        clone = (Button)Instantiate(myButton);                      //  生成して
        clone.transform.SetParent(myFather.transform);              //  親決めて
        clone.name = characterButton.name;                          //  名前変えて
        clone.transform.rotation = myButton.transform.rotation;     //  角度変える
        clone.gameObject.AddComponent<TouchDragController>();       //  スクリプトくっつける
        Destroy(clone.gameObject.GetComponent<TouchWeapon>());      //  スクリプトをはずす
        var rectTrans = clone.transform as RectTransform;           //  データもらってくる
        rectTrans.localScale = new Vector3(10.0f, 10.0f, 1);        //  サイズ変更

    }
}
