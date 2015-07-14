/*
 *  選択しているボタンを大きくするスクリプト
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
 * 2015/07/04 書き始める
 * 2015/07/13 コメントを付ける
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// 選択しているボタンを大きくするスクリプト
/// </summary>
public class ButtonScaling : MonoBehaviour {

    /// <summary>
    /// キャラ選択用のボタン全部
    /// </summary>
    [SerializeField]
    private Button[] button = null;
    /// <summary>
    /// 最小サイズ
    /// </summary>
    [SerializeField]
    private Vector3 scaleMin = new Vector3(1.0625f, 1.0625f, 1);
    /// <summary>
    /// 最大サイズ
    /// </summary>
    [SerializeField]
    private Vector3 scaleMax = new Vector3(1.0625f, 1.0625f, 1);

    /// <summary>
    /// イージングにかかる時間（秒）
    /// </summary>
    [SerializeField]
    float easeTime = 1.0f;

    /// <summary>
    /// 行うイージングの種類
    /// </summary>
    [SerializeField]
    iTween.EaseType easeType = iTween.EaseType.linear;

    /// <summary>
    /// 一旦全部縮小 押されたボタンを拡大
    /// </summary>
    /// <param name="myButton">押されたボタン</param>
    public void OnPush(Button myButton)
    {
        foreach (var item in button)
        {
            iTween.ScaleTo(item.gameObject, iTween.Hash("scale", scaleMin, "time", easeTime, "easetype", easeType));
        }
        iTween.ScaleTo(myButton.gameObject, iTween.Hash("scale", scaleMax, "time", easeTime, "easetype", easeType));
    }
}
