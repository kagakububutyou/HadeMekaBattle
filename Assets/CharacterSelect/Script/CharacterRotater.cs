/*
 *  キャラクターの回転のスクリプト
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
 * 2015/07/13 コメントを付ける
 * 
 */
using UnityEngine;
using System.Collections;
/// <summary>
/// キャラクターの回転のスクリプト
/// </summary>
public class CharacterRotater : MonoBehaviour {

    /// <summary>
    /// 最大角度
    /// </summary>
    private const float RotateEularMax = 360.0f;
    /// <summary>
    /// 最低角度
    /// </summary>
    private const float RotateEularMin = 0.0f;

    /// <summary>
    /// 一秒あたりの回転量
    /// </summary>
    /// Range(Min,Max)やると
    /// バーで選べるようになる
    [SerializeField, Range(RotateEularMin, RotateEularMax)]
    private float rotateEularPerSecond = 90.0f;
	
	// Update is called once per frame
	private void Update () 
    {
        Rotate();
	}
    /// <summary>
    /// 回転
    /// </summary>
    /// オイラー角　0～360度
    /// ラジアン　　0～2π
    private void Rotate()
    {
        float rotateValue = Input.GetAxis("Rotate");

        if (rotateValue == 0) return;   //  回転していなかったら抜ける
        //  ここで回転
        transform.Rotate(new Vector3(0.0f, rotateEularPerSecond * rotateValue * Time.deltaTime, 0.0f));
    }
}
