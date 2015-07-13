/*
 *  武器のNextボタンの表示のスクリプト
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

public class WeaponNextButtonDisplaying : MonoBehaviour {

    /// <summary>
    /// NextButton
    /// </summary>
    [SerializeField]
    private GameObject nextButton = null;

    [SerializeField]
    private GameObject[] childrens = null;

	// Use this for initialization
	private void Start () 
    {
	
	}
	
	// Update is called once per frame
	private void Update () 
    {
        IsChildrenExisting();
	}
    /// <summary>
    /// 子供がいるかどうか
    /// </summary>
    private void IsChildrenExisting()
    {
        if (childrens[0].transform.childCount == 1 && childrens[1].transform.childCount == 1
            && childrens[2].transform.childCount == 1 && childrens[3].transform.childCount == 1)
        {
            ButtonDisplaying(true);
        }
        else
        {
            ButtonDisplaying(false);
        }
    }

    /// <summary>
    /// ボタンの表示
    /// </summary>
    private void ButtonDisplaying(bool isShow)
    {
        nextButton.SetActive(isShow);
    }
}
