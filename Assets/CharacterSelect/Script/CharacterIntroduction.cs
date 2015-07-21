/*
 *  キャラクターの紹介を表示するスクリプト
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
 * 2015/07/18 書き始める
 * 2015/07/21 リファクタリング
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
/// <summary>
/// キャラクターの紹介を表示するスクリプト
/// </summary>
public class CharacterIntroduction : MonoBehaviour {

    /// <summary>
    /// 紹介構造体
    /// </summary>
    [System.Serializable]
    public struct Introduction
    {
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="bodyId">キャラのID</param>
        /// <param name="icon">アイコン</param>
        /// <param name="logo">ロゴ</param>
        /// <param name="description">紹介文</param>
        /// <param name="monitorLogo">装備枠に出るやつ</param>
        public Introduction(BuildManager.BodyID bodyId, Sprite icon, Sprite logo, Sprite description, Sprite monitorLogo)
        {
            this.bodyId = bodyId;
            this.icon = icon;
            this.logo = logo;
            this.description = description;
            this.monitorLogo = monitorLogo;
        }
        /// <summary>
        /// キャラのID
        /// </summary>
        public BuildManager.BodyID bodyId;
        /// <summary>
        /// アイコン
        /// </summary>
        public Sprite icon;
        /// <summary>
        /// ロゴ
        /// </summary>
        public Sprite logo;
        /// <summary>
        /// 紹介文
        /// </summary>
        public Sprite description;
        /// <summary>
        /// 装備枠のカットイン
        /// </summary>
        public Sprite monitorLogo;

    }

    /// <summary>
    /// 紹介文のデータ
    /// </summary>
    [SerializeField]
    private List<Introduction> introduction = new List<Introduction>();
    /// <summary>
    /// アイコン
    /// </summary>
    [SerializeField]
    private Image icon = null;
    /// <summary>
    /// ロゴ
    /// </summary>
    [SerializeField]
    private Image logo = null;
    /// <summary>
    /// 紹介文
    /// </summary>
    [SerializeField]
    private Image description = null;
    /// <summary>
    /// 装備枠に出るやつ
    /// </summary>
    [SerializeField]
    private Image monitorLogo = null;

    /// <summary>
    /// 紹介の切り替え
    /// </summary>
    /// <param name="bodyId">キャラのID</param>
    public void Change(BuildManager.BodyID bodyId)
    {
        var body = introduction.Find(i => i.bodyId == bodyId);
        icon.sprite = body.icon;
        logo.sprite = body.logo;
        description.sprite = body.description;
        monitorLogo.sprite = body.monitorLogo;
    }
}
