/*
 *  画像の透過度を変更するスクリプト
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
 * 2015/07/21 書き始め
 * 
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// 画像の透過度を変更する
/// </summary>
public class ImageAlphaBlender : MonoBehaviour {

    /// <summary>
    /// フェード時間
    /// </summary>
    [SerializeField]
    private float fadeTime = 1.0f;
    /// <summary>
    /// 遅延時間
    /// </summary>
    [SerializeField]
    private float delayTime = 0.0f; 
    /// <summary>
    /// イージングタイプ
    /// </summary>
    [SerializeField]
    private iTween.EaseType easeType = iTween.EaseType.linear;
    /// <summary>
    /// 画像
    /// </summary>
    private Image image = null;

	// Use this for initialization
	private void Start () 
    {
        image = GetComponent<Image>();
        FadeWithItween(1.0f, 0.0f,fadeTime);
	}
	/// <summary>
	/// イージング
	/// </summary>
	/// <param name="beginValue">どこから</param>
	/// <param name="endValue">どこまで</param>
	/// <param name="time">動く時間</param>
    public void FadeWithItween(float beginValue,float endValue,float time)
    {
        iTween.ValueTo(gameObject, iTween.Hash("from", beginValue, "to", endValue, "delay", delayTime, "time", time, "easetype", easeType, "looptype", iTween.LoopType.pingPong, "onupdate", "UpdateHandler"));

    }
    /// <summary>
    /// 色変更
    /// </summary>
    /// <param name="value">透過度</param>
    private void UpdateHandler(float value)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, value);
    }

    
}
