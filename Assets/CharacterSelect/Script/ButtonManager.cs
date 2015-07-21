/*
 *  ボタンのマネージャーのスクリプト
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
 * 2015/07/13 改行整理
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// 押されたボタンを反応しないようにするのスクリプト
/// </summary>
public class ButtonManager : MonoBehaviour {

    [SerializeField]
    private Button[] button = null;

    /// <summary>
    /// すべてのボタンを反応するようにし
    /// 押されたボタンを反応しないようにする
    /// </summary>
    /// <param name="myButton">押されたボタン</param>
    public void OnPush(Button myButton)
    {
        foreach (var item in button)
        {
            item.enabled = true;
        }
        myButton.enabled = false;
    }
}
