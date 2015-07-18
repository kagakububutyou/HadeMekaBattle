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
 * 2015/07/13 Start関数削除
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
/// <summary>
/// キャラクターの十字キーを取得するスクリプト
/// </summary>
public class HorizontalCharacter : MonoBehaviour {

    /// <summary>
    /// 機体データの構造体
    /// </summary>
    [System.Serializable]
    public struct CharacterData
    {
        public CharacterData(BuildManager.BodyID bobyID, GameObject model, Button button)
        {
            this.bobyID = bobyID;
            this.model = model;
            this.button = button;
        }

        public BuildManager.BodyID bobyID;
        public GameObject model;
        public Button button;
    }

    /// <summary>
    /// キャラクターのデータ
    /// </summary>
    [SerializeField]
    List<CharacterData> characterData = new List<CharacterData>();

    private BuildManager.BodyID nowBodyID = BuildManager.BodyID.NONE;
    /// <summary>
    /// キャラの切り替え用
    /// </summary>
    [SerializeField]
    private CharacterChanger characterChanger = null;
    /// <summary>
    /// ボタンのマネージャーさん
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

	// Update is called once per frame
    private void Update()
    {
        Horizontal();
    }

    /// <summary>
    /// 左右が押された時
    /// </summary>
    private void Horizontal()
    {
        
        var indexValue = (int)Input.GetAxisRaw("Horizontal");

        if (indexValue == 0) return;


        if (Input.GetButtonDown("Horizontal"))
        {
           
            buttonIndex += indexValue;
            buttonIndex = buttonIndex % characterData.Count;
            if(buttonIndex >= 0)
            {
                CharacterChanger(characterData[buttonIndex]);
            }
            else
            {
                var tmp = characterData.Count - Math.Abs(buttonIndex);
                CharacterChanger(characterData[tmp]);
            }

        }
    }

    /// <summary>
    /// キャラクターの切り替え
    /// </summary>
    /// <param name="index">キャラの番号</param>
    private void CharacterChanger(CharacterData data)
    {
        characterChanger.GetCharacter(data.bobyID);
        buttonManager.OnPush(data.button);
        buttonScaling.OnPush(data.button);

    }


    public void GetOnPush(BuildManager.BodyID bobyID)
    {
        nowBodyID = bobyID;

        buttonIndex = (int)nowBodyID;

    }
}
