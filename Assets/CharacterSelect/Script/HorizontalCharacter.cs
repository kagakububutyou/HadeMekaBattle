/*
 *  キャラクターの十字キーを取得するスクリプト
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
 * 2015/07/08 切り替え番号の取得方法の変更
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HorizontalCharacter : MonoBehaviour {

    /// <summary>
    /// ボタンを格納
    /// </summary>
    [SerializeField]
    private Button[] button = null;
    /// <summary>
    /// キャラクターしまう用
    /// </summary>
    [SerializeField]
    private GameObject[] characterObject = null;
    /// <summary>
    /// キャラの切り替え用
    /// </summary>
    [SerializeField]
    private CharacterChanger characterChanger = null;
    /// <summary>
    ///     ボタンのマネージャーさん
    /// </summary>
    [SerializeField]
    private ButtonManager buttonManager = null;
    /// <summary>
    /// ボタンの大きさ
    /// </summary>
    [SerializeField]
    private ButtonScaling buttonScaling = null;
    /// <summary>
    /// ボタンの番号
    /// </summary>
    [SerializeField]
    private int buttonIndex = 0;
    /// <summary>
    /// お父さんの設定
    /// </summary>
    [SerializeField]
    private GameObject nowCharacter = null;

	// Use this for initialization
	private void Start () 
    {
	    
	}
	
	// Update is called once per frame
	private void Update () 
    {
        Horizontal();
	}
    /// <summary>
    /// 左右が押された時
    /// </summary>
    private void Horizontal()
    {
        var indexValue = (int)Input.GetAxisRaw("Horizontal");

        LoopCount();

        if (Input.GetButtonDown("Horizontal"))
        {
            buttonIndex += indexValue;
            buttonIndex = buttonIndex % button.Length;
            if(buttonIndex >= 0)
            {
                CharacterChanger(buttonIndex);
            }
            else
            {
                var tmp = button.Length - Math.Abs(buttonIndex);
                CharacterChanger(tmp);
            }
        }
    }

    /// <summary>
    /// キャラクターの切り替え
    /// </summary>
    /// <param name="index">キャラの番号</param>
    private void CharacterChanger(int index)
    {
        characterChanger.GetCharacter(characterObject[index]);
        buttonManager.OnPush(button[index]);
        buttonScaling.OnPush(button[index]);
    }

    /// <summary>
    /// ループカウント
    /// </summary>
    /// スマートなやり方あったら教えて下さい
    /// 
    private void LoopCount()
    {
        // ループカウント
        int loopCount = 0;
        //　キャラ番号の取得
        foreach (var item in button)
        {
            if (nowCharacter.transform.GetChild(0).gameObject.name == item.name)
            {
                buttonIndex = loopCount;
                return;
            }
            loopCount += 1;
        }
    }
}
