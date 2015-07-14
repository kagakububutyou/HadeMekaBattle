/*
 *  選択された武器を装備するスクリプト
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
 * 2015/07/14 書き始める
 * 
 */
using UnityEngine;
using System.Collections;

public class WeaponEquipment : MonoBehaviour {

    /// <summary>
    /// 武器のオブジェクト
    /// </summary>
    [SerializeField]
    private GameObject[] weapons = null;
    /// <summary>
    /// 武器の場所
    /// </summary>
    [SerializeField]
    private GameObject displayingPosition = null;

	/// <summary>
	/// 武器の装備
	/// </summary>
    public void WeaponChange(string childrenName) 
    {
        //*
        /// 子供がいたら子供全員消す
        if (displayingPosition.transform.IsChildOf(displayingPosition.transform))
        {
            foreach (Transform n in displayingPosition.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }
        //*/

        foreach (var weapon in weapons)
        {
            if (childrenName == weapon.name)
            {
                GameObject clone = (GameObject)Instantiate(weapon);
                clone.name = weapon.name;
                clone.transform.position = displayingPosition.transform.position;
                clone.transform.SetParent(displayingPosition.transform);
            }
        }
	}
}
