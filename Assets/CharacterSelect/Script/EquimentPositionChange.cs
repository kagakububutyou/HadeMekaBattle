/*
 *  装備の位置を動かすスクリプト
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
 * 2015/07/18 書き始め
 * 2015/07/21 リファクタリング
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// 装備のカットイン
/// </summary>
public class EquimentPositionChange : MonoBehaviour {

    /// <summary>
    /// 開始位置
    /// </summary>
    [SerializeField]
    private Vector3 startPosition = Vector3.zero;
    /// <summary>
    /// 目標位置
    /// </summary>
    [SerializeField]
    private Vector3 targetPosition = Vector3.zero;
    /// <summary>
    /// 移動時間(秒)
    /// </summary>
    [SerializeField]
    private float movingTimeSeconds = 0.0f;

    /// <summary>
    /// 行うイージングの種類
    /// </summary>
    [SerializeField]
    private iTween.EaseType easeType = iTween.EaseType.linear;

    /// <summary>
    /// 動くかどうか
    /// </summary>
    private bool isMoving = false;
    /// <summary>
    /// 動いた時間
    /// </summary>
    private float moveTime = 0;

	// Use this for initialization
	private void Start () 
    {
        startPosition = transform.position ;
	}
	
	// Update is called once per frame
	private void Update () 
    {
        if (isMoving)
        {
            moveTime -= Time.deltaTime;
            if (moveTime <= 0)
            {
                isMoving = false;
            }
        }
	}

    /// <summary>
    /// 表示位置に移動
    /// </summary>
    public void TargetPositionMoving()
    {
        if (isMoving) return;

        iTween.MoveTo(gameObject, iTween.Hash("x", targetPosition.x, "islocal", true, "time", movingTimeSeconds, "easetype", easeType));
        moveTime = movingTimeSeconds;
        isMoving = true;
    }

    /// <summary>
    /// 開始位置から始める
    /// </summary>
    public void LoopPositionMoving()
    {
        gameObject.transform.position = new Vector3(startPosition.x,transform.position.y,transform.position.z);
        isMoving = false;        
    }
    
    /// <summary>
    /// 強制離脱
    /// </summary>
    public void ForcedWithdrawal()
    {
        iTween.Stop(gameObject);
        LoopPositionMoving();   
    }


    /// <summary>
    /// 開始位置に戻す
    /// </summary>
    public void StartPositionMoving()
    {
        iTween.MoveTo(gameObject, iTween.Hash("x", startPosition.x, "islocal", true, "time", movingTimeSeconds, "easetype", easeType));
    }
}
