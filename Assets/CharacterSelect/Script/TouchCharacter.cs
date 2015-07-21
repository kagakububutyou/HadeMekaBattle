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
 * 2015/07/14 コメントつける
 * 2015/07/18 IDに変更
 * 2015/07/21 リファクタリング
 * 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
/// <summary>
/// キャラクターのタッチを取得するスクリプト
/// </summary>
public class TouchCharacter : MonoBehaviour {

    /// <summary>
    /// キャラクターのId
    /// </summary>
    [SerializeField]
    private BuildManager.BodyID bodyId = BuildManager.BodyID.NONE;
    /// <summary>
    /// 自分自身のボタン
    /// </summary>
    [SerializeField]
    private Button characterButton = null;
    /// <summary>
    /// キャラクター変更
    /// </summary>
    [SerializeField]
    private CharacterChanger characterChanger = null;
    /// <summary>
    /// 十字キーでキャラ変更
    /// </summary>
    [SerializeField]
    private HorizontalCharacter horizontalCharacter = null;
    /// <summary>
    /// キャラクターキャンパスを
    /// </summary>
    [SerializeField]
    private ButtonManager buttonManager = null;
    /// <summary>
    /// キャラクターキャンパスを
    /// </summary>
    [SerializeField]
    private ButtonScaling buttonScaling = null;
    /// <summary>
    /// キャラクターの紹介文
    /// </summary>
    [SerializeField]
    private GameObject introduction = null;

    /// <summary>
    /// NestButton
    /// </summary>
    [SerializeField]
    private GameObject nextButton = null;

	// Use this for initialization
	private void Start () 
    {
        characterButton.onClick.AddListener(PushButton);
	}

    /// <summary>
    /// ボタンが押された時
    /// </summary>
    /// 生成を呼ぶ
    /// どのボタンが渡されたかを
    private void PushButton()
    {
        IsDisplaying();
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
        characterChanger.GetCharacter(bodyId);
        horizontalCharacter.GetOnPush(bodyId);
    }
    /// <summary>
    /// ボタンが押された時に表示するもの
    /// </summary>
    private void IsDisplaying()
    {
        //  表示していなかったら表示
        if (!introduction.activeInHierarchy)
        {
            introduction.SetActive(true);
            nextButton.SetActive(true);
        }
    }
}
