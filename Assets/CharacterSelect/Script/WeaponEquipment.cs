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
 * 2015/07/21 リファクタリング
 * 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 武器を装備する
/// </summary>
public class WeaponEquipment : MonoBehaviour {

    /// <summary>
    /// 武器の装備のデータ
    /// </summary>
    [System.Serializable]
    public struct WeaponEquipmentData
    {
        /// <summary>
        /// 武器のデータ
        /// </summary>
        /// <param name="weaponID">武器のID</param>
        /// <param name="weaponObject">モデル</param>
        public WeaponEquipmentData(BuildManager.WeaponID weaponID, GameObject weaponObject)
        {
            this.weaponID = weaponID;
            this.weaponObject = weaponObject;
        }
        /// <summary>
        /// 武器のID
        /// </summary>
        public BuildManager.WeaponID weaponID;
        /// <summary>
        /// 武器のモデル
        /// </summary>
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
    /// <summary>
    /// 装備のアイコンの移動
    /// </summary>
    [SerializeField]
    private EquimentPositionChange equimentPositionChange = null;

    /// <summary>
    /// 武器の装備
    /// </summary>
    /// <param name="weaponID">武器のID</param>
    public void WeaponChange(BuildManager.WeaponID weaponID) 
    {
        /// 子供がいたら子供全員消す
        if (equippedPosition.transform.IsChildOf(equippedPosition.transform))
        {
            foreach (Transform n in equippedPosition.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }

        //　以下で同じ武器のidを装備する
        var weapon = weaponEquipmentData.Find(i => i.weaponID == weaponID);
        GameObject clone = (GameObject)Instantiate(weapon.weaponObject);        //  武器作る
        clone.name = weapon.weaponObject.name;                                  //  名前変更
        clone.transform.position = equippedPosition.transform.position;         //  座標変更
        clone.transform.rotation = equippedPosition.transform.rotation;         //  回転変更
        clone.transform.SetParent(equippedPosition.transform);                  //  親変更
	}

    /// <summary>
    /// 武器解除
    /// </summary>
    public void WeaponCancel()
    {
        /// 子供がいたら子供全員消す
        if (equippedPosition.transform.IsChildOf(equippedPosition.transform))
        {
            foreach (Transform n in equippedPosition.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }
        /// アイコンを強制的に戻す
        equimentPositionChange.ForcedWithdrawal();
    }
}
