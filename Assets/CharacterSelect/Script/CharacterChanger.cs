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
 * 
 */
using UnityEngine;
using System.Collections;

public class CharacterChanger : MonoBehaviour {

    [SerializeField]
    private GameObject nowCharacter = null;

	// Use this for initialization
	private void Start () 
    {
	
	}
	
	// Update is called once per frame
	private void Update () 
    {
	
	}
    /// <summary>
    /// Characterの取得
    /// </summary>
    /// <param name="character">キャラをもらってくる</param>
    /// 子供がふたり以上いたら長男を消す
    /// 
    public void GetCharacter(GameObject character)
    {
        if (nowCharacter.transform.childCount >= 1)
        {
            //         消す　   お父さんの            長男の      オブジェクトを
            GameObject.Destroy(nowCharacter.transform.GetChild(0).gameObject);
        }

        /// 以下で生成
        GameObject Clone = (GameObject)Instantiate(character);
        Clone.name = character.name;
        /// お父さんを設定
        Clone.transform.parent = nowCharacter.transform;
    }
}
