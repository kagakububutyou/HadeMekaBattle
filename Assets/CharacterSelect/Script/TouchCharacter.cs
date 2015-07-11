/*
 *  キャラクターのタッチを取得するスクリプト
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
using UnityEngine.UI;
/// <summary>
/// キャラクターのタッチを取得するスクリプト
/// </summary>
public class TouchCharacter : MonoBehaviour {

    [SerializeField]
    private Button characterButton = null;
    [SerializeField]
    private GameObject[] characterObject = null;
    [SerializeField]
    private CharacterChanger characterChanger = null;
    [SerializeField]
    private ButtonManager buttonManager = null;
    [SerializeField]
    private ButtonScaling buttonScaling = null;

	// Use this for initialization
	private void Start () 
    {
        characterButton.onClick.AddListener(PushButton);
	}
	
	// Update is called once per frame
	private void Update () 
    {
	
	}

    /// <summary>
    /// ボタンが押された時
    /// </summary>
    /// 生成を呼ぶ
    /// どのボタンが渡されたかを
    private void PushButton()
    {
        Clone();
        buttonManager.OnPush(characterButton);
        buttonScaling.OnPush(characterButton);
    }
    /// <summary>
    /// オブジェクトの生成
    /// </summary>
    /// characterChangerのGetCharacterに引数でオブジェクトを渡せば
    /// 切り替わる
    private void Clone()
    {
        foreach (var item in characterObject)
        {
            if (item.name == characterButton.name)
            {
                characterChanger.GetCharacter(item);
            }
        }
    }
}
