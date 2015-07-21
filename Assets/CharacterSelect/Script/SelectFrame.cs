/*
 *  タッチした場所にフレームを生成するスクリプト
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
 * 2015/07/14 関数の整理
 * 2015/07/21 リファクタリング
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// タッチした場所にフレームを生成するスクリプト
/// </summary>
/// 今使ってない
public class SelectFrame : MonoBehaviour {

    /// <summary>
    /// 選択した時のフレーム
    /// </summary>
    private Image selectFrame = null;
    /// <summary>
    /// お父さん
    /// </summary>
    [SerializeField]
    private GameObject myFather = null;
    /// <summary>
    /// 武器の数
    /// </summary>
    [SerializeField]
    private int weaponNum = 0;
    /// <summary>
    /// 押された場所に生成
    /// </summary>
    /// <param name="myButton">ボタンの押した場所</param>
    public void OnPush(Button myButton)
    {
        if (Selection(weaponNum)) return;

        Image clone = (Image)Instantiate(selectFrame, myButton.transform.position, myButton.transform.rotation);
        clone.name = selectFrame.name;

        /// お父さんを設定
        clone.transform.parent = myFather.transform;
        clone.transform.localScale = selectFrame.transform.localScale;
    }
    /// <summary>
    /// 何個選択しているか？
    /// </summary>
    /// <returns>選択されていたらtrue</returns>
    private bool Selection(int nun)
    {
        if (myFather.transform.childCount >= nun)
        {
            return true;
        }
        return false;
    }
}
