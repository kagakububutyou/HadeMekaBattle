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
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterNextButton : MonoBehaviour {

    [SerializeField]
    private Button nextButton = null;

    [SerializeField]
    private GameObject characterCanvas = null;
    [SerializeField]
    private GameObject weaponButton = null;
    [SerializeField]
    private GameObject equippedWeapon = null;

	// Use this for initialization
	private void Start () 
    {
        nextButton.onClick.AddListener(PushButton);
	}
	// Update is called once per frame
	private void Update () 
    {
	
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
        weaponButton.SetActive(true);
        equippedWeapon.SetActive(true);
        characterCanvas.SetActive(false);
    }
}
