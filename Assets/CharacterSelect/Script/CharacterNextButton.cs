/*
 *  キャラ選択画面のNextボタンのスクリプト
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
 * 2015/07/13 書き始める
 *     同日   コメントを付ける
 * 2015/07/15 nowWeaponの親変更
 * 2015/07/21 リファクタリング
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// キャラ選択画面のNextボタンのスクリプト
/// </summary>
public class CharacterNextButton : MonoBehaviour {

    /// <summary>
    /// ボタン自体
    /// </summary>
    [SerializeField]
    private Button nextButton = null;
    /// <summary>
    /// GamePadのキャラクターのUIのキャンパス
    /// </summary>
    [SerializeField]
    private GameObject characterCanvas = null;
    /// <summary>
    /// GamePadの武器ボタンのキャンパス
    /// </summary>
    [SerializeField]
    private GameObject weaponButton = null;
    /// <summary>
    /// GamePadの武器装備のキャンパス
    /// </summary>
    [SerializeField]
    private GameObject equippedWeapon = null;

    /// <summary>
    /// 親　nowCharacter
    /// </summary>
    [SerializeField]
    private GameObject parent = null;
    /// <summary>
    /// 子　nowWeapon
    /// </summary>
    [SerializeField]
    private GameObject children = null;
    /// <summary>
    /// キャラの回転
    /// </summary>
    [SerializeField]
    private Quaternion characterRotate = Quaternion.identity;

	// Use this for initialization
	private void Start () 
    {
        nextButton.onClick.AddListener(PushButton);
	}
    /// <summary>
    /// ボタンをおした時
    /// </summary>
    private void PushButton()
    {
        SceneSwitching();
    }
    /// <summary>
    /// シーンの切り替え
    /// </summary>
    /// なんちゃってシーンの切り替え
    /// キャラ選択から武器選択へ
    private void SceneSwitching()
    {
        weaponButton.SetActive(true);       //  表示
        equippedWeapon.SetActive(true);     //  表示
        characterCanvas.SetActive(false);   //  非表示
        //　回転をリセットする
        parent.transform.rotation = Quaternion.identity;
        parent.transform.GetChild(0).transform.rotation = characterRotate;

        //  親変更
        children.transform.SetParent(parent.transform);

    }
}
