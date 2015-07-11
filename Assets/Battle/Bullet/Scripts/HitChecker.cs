using UnityEngine;
using System.Collections;

public class HitChecker : MonoBehaviour {
    BulletBasePalametar palametar = null;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () {}

    void OnCollisionEnter(Collision other)
    {
        // エフェクト生成
        //EffekseerEmitter;

        // 弾を消す
        Destroy(this.gameObject);

        // ダメージ計算
        if(other.gameObject.GetComponent<NetworkView>().isMine == true)
        {
            return;
        }

        if(other.gameObject.tag == "Player")
        {

        }//*/
    }
}
