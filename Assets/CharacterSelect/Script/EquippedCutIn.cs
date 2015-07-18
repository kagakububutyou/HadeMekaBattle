/*
 *  装備している武器のアイコンの表示するスクリプト
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
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EquippedCutIn : MonoBehaviour {

    /// <summary>
    /// 武器の場所
    /// </summary>
    [SerializeField]
    private Image displayingPosition = null;

    /// <summary>
    /// 武器のアイコンのデータ
    /// </summary>
    [System.Serializable]
    public struct EquippedCutInData
    {
        public EquippedCutInData(BuildManager.WeaponID weaponID, Sprite icon)
        {
            this.weaponID = weaponID;
            this.icon = icon;
        }
        public BuildManager.WeaponID weaponID;
        public Sprite icon;

    }

    [SerializeField]
    private EquimentPositionChange positionMoving = null;
    /// <summary>
    /// 武器の装備のデータ
    /// </summary>
    [SerializeField]
    private List<EquippedCutInData> weaponEquipmentData = new List<EquippedCutInData>();

    /// <summary>
    /// 装備の表示
    /// </summary>
    /// <param name="childrenName"></param>
    public void EquippedDisplay(BuildManager.WeaponID weaponID)
    {
        ChangeIcon(weaponID);

        positionMoving.LoopPositionMoving();
        positionMoving.TargetPositionMoving();
    }

    /// <summary>
    /// 切り替え
    /// </summary>
    /// <param name="childrenName"></param>
    private void ChangeIcon(BuildManager.WeaponID weaponID)
    {
        var icon = weaponEquipmentData.Find(i => i.weaponID == weaponID);
        displayingPosition.sprite = icon.icon;
    }
}
