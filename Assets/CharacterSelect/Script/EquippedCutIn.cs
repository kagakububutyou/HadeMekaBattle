/*
 *  装備している武器のアイコンの表示するスクリプト
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
 * 2015/07/15 書き始め
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EquippedCutIn : MonoBehaviour {

    /// <summary>
    /// 武器のオブジェクト
    /// </summary>
    [SerializeField]
    private Sprite[] icons = null;
    /// <summary>
    /// 武器の場所
    /// </summary>
    [SerializeField]
    private Image displayingPosition = null;

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
    iTween.EaseType easeType = iTween.EaseType.linear;

    /// <summary>
    /// 装備の表示
    /// </summary>
    /// <param name="childrenName"></param>
    public void EquippedDisplay(string childrenName)
    {
        ChangeIcon(childrenName);
        TargetPositionMoving();
    }
    /// <summary>
    /// 切り替え
    /// </summary>
    /// <param name="childrenName"></param>
    private void ChangeIcon(string childrenName)
    {
        foreach (var icon in icons)
        {
            if (childrenName == icon.name)
            {
                displayingPosition.sprite = icon;
            }
        }
    }

    /// <summary>
    /// 表示位置に移動
    /// </summary>
    public void TargetPositionMoving()
    {
        iTween.MoveTo(displayingPosition.gameObject, iTween.Hash("x", targetPosition.x, "islocal", true, "time", movingTimeSeconds, "easetype", easeType));
    }
    /// <summary>
    /// 開始位置から始める
    /// </summary>
    public void LoopPositionMoving()
    {
        iTween.MoveFrom(displayingPosition.gameObject, iTween.Hash("x", startPosition.x, "islocal", true, "time", movingTimeSeconds, "easetype", easeType));
    }
    /// <summary>
    /// 開始位置に戻す
    /// </summary>
    public void StartPositionMoving()
    {
        iTween.MoveTo(displayingPosition.gameObject, iTween.Hash("x", startPosition.x, "islocal", true, "time", movingTimeSeconds, "easetype", easeType));
    }
}
