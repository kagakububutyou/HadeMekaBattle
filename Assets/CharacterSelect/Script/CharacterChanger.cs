/*
 *  キャラクターの切り替えのスクリプト
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
 * 2015/07/08 出産方法の変更　
 * 2015/07/13 子供を消す条件を変更
 *   同日     Start,Update削除
 * 2015/07/14 親の設定の変更
 * 
 */
using UnityEngine;
using System.Collections;
/// <summary>
/// キャラクターの切り替えのスクリプト
/// </summary>
public class CharacterChanger : MonoBehaviour {

    /// <summary>
    /// お父さんの設定
    /// </summary>
    [SerializeField]
    private GameObject nowCharacter = null;

    /// <summary>
    /// Characterの取得
    /// </summary>
    /// <param name="character">キャラをもらってくる</param>
    /// 子供がふたり以上いたら子供全員消す
    /// 出産する
    public void GetCharacter(GameObject character)
    {
        /// 子供がいたら子供全員消す
        if (nowCharacter.transform.IsChildOf(nowCharacter.transform))
        {
            foreach (Transform n in nowCharacter.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }
        /// 以下で生成
        GameObject clone = (GameObject)Instantiate(character);
        clone.name = character.name;
        /// お父さんを設定
        clone.transform.SetParent(nowCharacter.transform);
    }
}
