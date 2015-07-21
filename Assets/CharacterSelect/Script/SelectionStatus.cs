/*
 *  選択しているステータスを表示するスクリプト
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
 * 2015/07/21 リファクタリング
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// ステータスの表示
/// </summary>
/// 使ってんの？
public class SelectionStatus : MonoBehaviour {

    /// <summary>
    /// アイコン
    /// </summary>
    [SerializeField]
    private Sprite[] icons = null;
    /// <summary>
    /// 表示する場所
    /// </summary>
    [SerializeField]
    private Image displayingPosition = null;

    /// <summary>
    /// 切り替え
    /// </summary>
    /// <param name="childrenName"></param>
    public void ChangeIcon(string childrenName)
    {
        foreach (var icon in icons)
        {
            if (childrenName == icon.name)
            {
                displayingPosition.sprite = icon;
            }
        }
    }
}
