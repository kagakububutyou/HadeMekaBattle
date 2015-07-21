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
using System.Collections.Generic;
/// <summary>
/// キャラクターの切り替えのスクリプト
/// </summary>
public class CharacterChanger : MonoBehaviour {


    /// <summary>
    /// キャラクターの情報
    /// </summary>
    [System.Serializable]
    public struct CharacterData
    {
        /// <summary>
        /// キャラクターデータ
        /// </summary>
        /// <param name="bodyId">キャラのID</param>
        /// <param name="characterObject">オブジェクト</param>
        public CharacterData(BuildManager.BodyID bodyId, GameObject characterObject)
        {
            this.bodyId = bodyId;
            this.characterObject = characterObject;
        }
        /// <summary>
        /// キャラのID
        /// </summary>
        public BuildManager.BodyID bodyId;
        /// <summary>
        /// キャラクターのオブジェクト
        /// </summary>
        public GameObject characterObject;
    }


    /// <summary>
    /// 機体のデータ
    /// </summary>
    [SerializeField]
    private List<CharacterData> characterData = new List<CharacterData>();
    /// <summary>
    /// お父さんの設定
    /// </summary>
    [SerializeField]
    private GameObject nowCharacter = null;
    /// <summary>
    /// キャラクターのアイコンのカットイン
    /// </summary>
    [SerializeField]
    private EquimentPositionChange monitorLogo = null;
    /// <summary>
    /// キャラクターのアイコンの切り替え
    /// </summary>
    [SerializeField]
    private CharacterIntroduction introduction = null;

    /// <summary>
    /// Characterの取得
    /// </summary>
    /// <param name="character">キャラをもらってくる</param>
    /// 子供がふたり以上いたら子供全員消す
    /// 出産する
    public void GetCharacter(BuildManager.BodyID bodyId)
    {
        /// 子供がいたら子供全員消す
        if (nowCharacter.transform.IsChildOf(nowCharacter.transform))
        {
            foreach (Transform n in nowCharacter.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }

        var body = characterData.Find(i => i.bodyId == bodyId);
        
        /// 以下で生成
        GameObject clone = (GameObject)Instantiate(body.characterObject);

        //  名前変える
        clone.name = body.characterObject.name;

        /// お父さんを設定
        clone.transform.SetParent(nowCharacter.transform);
        clone.transform.rotation = body.characterObject.transform.rotation;

        //  カットイン
        monitorLogo.LoopPositionMoving();
        monitorLogo.TargetPositionMoving();
     
        //  アイコン変更
        introduction.Change(body.bodyId);
        
    }
}
