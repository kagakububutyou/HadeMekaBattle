using UnityEngine;
using System.Collections;

public class HitChecker : MonoBehaviour {

    BulletBasePalametar palametar = null;

    public BulletBasePalametar Palametar 
    { 
        get 
        {
            return palametar; 
        }
        set
        { 
            if (palametar == null) palametar = value;
        } 
    }

    [SerializeField]
    private GameObject effect = null;

	// Update is called once per frame
	//void Update () {}

    // 衝突判定(Trigger)
    /*void OnTriggerEnter(Collider other) 
    {
        Debug.Log("衝突処理開始");
        
        // 当たったのがプレイヤーなら処理を行わない
        if (other.gameObject.GetComponent<NetworkView>().isMine == true) return;

        // エフェクト生成
        EffekseerEmitter.Create(effect, this.transform.position);

        // 弾を消す
        Destroy(this.gameObject);

        // ダメージ計算
        if (other.gameObject.tag == "Player")
        {
            // 接触した相手が持ち主だった場合
            if (other.gameObject.GetComponent<NetworkView>().isMine == true) return;

            // ダメージ計算
            if (palametar.AttackType == BulletBasePalametar.TYPE.PHYSICAL)
            {
                // 物理攻撃によるダメージ計算
                other.gameObject.GetComponent<HealthManager>().PhysicalDamage((int)palametar.Power);
            }
            else if (palametar.AttackType == BulletBasePalametar.TYPE.ENERGY)
            {
                // エネルギー攻撃によるダメージ計算
                other.gameObject.GetComponent<HealthManager>().EnergyDamage(100);
            }
        }
    }//*/

    // 衝突判定(Collision)
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("衝突処理開始");
        Destroy(this.gameObject);

        // 当たったのがプレイヤーなら処理を行わない
        if (collision.gameObject.GetComponent<NetworkView>().isMine == true) return;

        // エフェクト生成
        EffekseerEmitter.Create(effect, this.transform.position);

        // 弾を消す
        //Destroy(this.gameObject);

        // ダメージ計算
        if (collision.gameObject.tag == "Player")
        {
            // 接触した相手が持ち主だった場合
            if (collision.gameObject.GetComponent<NetworkView>().isMine == true) return;
            
            // ダメージ計算
            if (palametar.AttackType == BulletBasePalametar.TYPE.PHYSICAL) 
            {
                //
                collision.gameObject.GetComponent<HealthManager>().PhysicalDamage((int)palametar.Power);
            }
            else if(palametar.AttackType == BulletBasePalametar.TYPE.ENERGY)
            {
                //
                collision.gameObject.GetComponent<HealthManager>().EnergyDamage(100);
            }
        }
    }//*/
}
