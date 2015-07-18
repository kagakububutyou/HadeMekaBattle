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
 * 2015/07/18 構造型に変更
 * 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponEquipment : MonoBehaviour {

    /// <summary>
    /// 武器の装備のデータ
    /// </summary>
    [System.Serializable]
    public struct WeaponEquipmentData
    {
        public WeaponEquipmentData(BuildManager.WeaponID weaponID, GameObject weaponObject)
        {
            this.weaponID = weaponID;
            this.weaponObject = weaponObject;
        }
        public BuildManager.WeaponID weaponID;
        public GameObject weaponObject;

    }
    /// <summary>
    /// 武器の装備のデータ
    /// </summary>
    [SerializeField]
    private List<WeaponEquipmentData> weaponEquipmentData = new List<WeaponEquipmentData>();

    /// <summary>
    /// 武器の場所
    /// </summary>
    [SerializeField]
    private GameObject equippedPosition = null;

    [SerializeField]
    EquimentPositionChange equimentPositionChange = null;


	/// <summary>
	/// 武器の装備
	/// </summary>
    public void WeaponChange(BuildManager.WeaponID weaponID) 
    {
        //*
        /// 子供がいたら子供全員消す
        if (equippedPosition.transform.IsChildOf(equippedPosition.transform))
        {
            foreach (Transform n in equippedPosition.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }
        //*/

        //　以下で同じ武器のidを装備する
        var weapon = weaponEquipmentData.Find(i => i.weaponID == weaponID);
        GameObject clone = (GameObject)Instantiate(weapon.weaponObject);
        clone.name = weapon.weaponObject.name;
        clone.transform.position = equippedPosition.transform.position;
        clone.transform.rotation = equippedPosition.transform.rotation;
        clone.transform.SetParent(equippedPosition.transform);
	}

    /// <summary>
    /// 武器解除
    /// </summary>
    public void WeaponCancel()
    {
        if (equippedPosition.transform.IsChildOf(equippedPosition.transform))
        {
            foreach (Transform n in equippedPosition.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }

        equimentPositionChange.ForcedWithdrawal();
    }
}
