/*
 *  選択している武器のステータスを表示するスクリプト
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
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WeaponStatusChanger : MonoBehaviour {

    /// <summary>
    /// ステータスアイコンのデータ
    /// </summary>
    [System.Serializable]
    public struct StatusIconData
    {
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="weaponID">武器のID</param>
        /// <param name="logo">ロゴ</param>
        /// <param name="icon">アイコン</param>
        /// <param name="status">ステータス</param>
        public StatusIconData(BuildManager.WeaponID weaponID, Sprite logo, Sprite icon, Sprite status)
        {
            this.weaponID = weaponID;
            this.logo = logo;
            this.icon = icon;
            this.status = status;
        }

        public BuildManager.WeaponID weaponID;
        public Sprite logo;
        public Sprite icon;
        public Sprite status;
    }

    /// <summary>
    /// ステータスデータ
    /// </summary>
    [SerializeField]
    private List<StatusIconData> statusData = new List<StatusIconData>();
    /// <summary>
    /// ロゴ
    /// </summary>
    [SerializeField]
    private Image logo = null;
    /// <summary>
    /// アイコン
    /// </summary>
    [SerializeField]
    private Image icon = null;
    /// <summary>
    /// ステータス
    /// </summary>
    [SerializeField]
    private Image status = null;
    /// <summary>
    /// ステータスの変更
    /// </summary>
    /// <param name="weaponID">武器のID</param>
    public void Change(BuildManager.WeaponID weaponID)
    {
        var weapon = statusData.Find(i=>i.weaponID==weaponID);
        logo.sprite = weapon.logo;
        icon.sprite = weapon.icon;
        status.sprite= weapon.status;
    }
}
