/*
 *  画像がタッチされた時に呼ぶスクリプト
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
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
/// <summary>
/// 画像がタッチされた時に呼ぶ
/// </summary>
public class HightLIghtPanelDestroyer : MonoBehaviour {

    /// <summary>
    /// 子供のリスト
    /// </summary>
    private List<GameObject> children = new List<GameObject>();

    // Use this for initialization
    private void Start()
    {
        //子供をすべて得る
        foreach (var child in gameObject.GetComponentsInChildrenWithoutSelf<Transform>())
        {
            children.Add(child.gameObject);
        }
    }
    /// <summary>
    /// 余命
    /// </summary>
    [SerializeField]
    float destroyingTime = 1.0f;
    /// <summary>
    /// 殺したかどうか
    /// </summary>
    private bool isDestroyed = false;

    /// <summary>
    /// ハイライトPanelを削除し、子も全て消す。
    /// </summary>
    public void DestroyHLPanel()
    {
        if (isDestroyed) return;

        //子供のiTweenを得て、終了させる。
        iTween.Stop(gameObject, true);

        //子供のImageのColorを得る
        //子供にitweenをつける、上記で得た色から0に向かってフェードさせる
        foreach (var child in children)
        {
            var childColor = child.GetComponent<Image>().color;

            child.GetComponent<ImageAlphaBlender>().FadeWithItween(childColor.a, 0.0f, destroyingTime);
        }

        //上記のフェードが終わったらこいつを殺す
        StartCoroutine(DestroyWithDelay());
    }

    /// <summary>
    /// フェードさせる
    /// </summary>
    /// <returns>殺すまでの時間</returns>
    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(destroyingTime);

        isDestroyed = true;
        Destroy(gameObject);
    }

}
