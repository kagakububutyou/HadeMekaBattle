/*
 *  拡大縮小のスクリプト
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
/// <summary>
/// 拡大縮小のスクリプト
/// </summary>
public class CharacterSelectionTutorial : MonoBehaviour {

    /// <summary>
    /// 縮小最小値
    /// </summary>
    [SerializeField]
    private Vector2 scaleDownMinimumMagnification = Vector2.zero;

    /// <summary>
    /// 拡大最大値
    /// </summary>
    [SerializeField]
    private Vector2 zoomMaxMagnification = Vector2.zero;

    /// <summary>
    /// 拡大時間(秒)
    /// </summary>
    [SerializeField]
    private float zoomTimeSeconds = 0.0f;
    /// <summary>
    /// 行うイージングの種類
    /// </summary>
    [SerializeField]
    private iTween.EaseType easeType = iTween.EaseType.linear;

    /// <summary>
    /// イージング経過時間
    /// </summary>
    private float easeTime = 0.0f;
	
	// Update is called once per frame
	private void Update () 
    {
        ZoomScaleDown();
	}
    /// <summary>
    /// 拡大縮小
    /// </summary>
    public void ZoomScaleDown()
    {
        easeTime += Time.deltaTime;
        easeTime = easeTime % zoomTimeSeconds;

        if (zoomTimeSeconds / 2 > easeTime)
        {
            ScaleDown();
        }
        else
        {
            Zoom();
        }
    }

    /// <summary>
    /// 拡大
    /// </summary>
    private void Zoom()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", zoomMaxMagnification.x, "y", zoomMaxMagnification.y, "time", zoomTimeSeconds / 2, "looptype", iTween.LoopType.loop, "easetype", easeType));
    }

    /// <summary>
    /// 縮小
    /// </summary>
    private void ScaleDown()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", scaleDownMinimumMagnification.x, "y", scaleDownMinimumMagnification.y, "time", zoomTimeSeconds / 2, "looptype", iTween.LoopType.loop, "easetype", easeType));
    }
}
