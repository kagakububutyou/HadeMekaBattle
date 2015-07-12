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
	void Update () {}

    void OnTriggerEnter(Collider col) 
    {
        EffekseerEmitter.Create(effect, this.transform.position);
    }

    void OnCollisionEnter(Collision other)
    {
        // エフェクト生成
        EffekseerEmitter.Create(effect, this.transform.position);

        // 弾を消す
        Destroy(this.gameObject);

        // ダメージ計算
        if(other.gameObject.tag == "Player")
        {
            // 接触した相手が持ち主だった場合
            if (other.gameObject.GetComponent<NetworkView>().isMine == true) return;
            
            // ダメージ計算
            if (palametar.AttackType == BulletBasePalametar.TYPE.PHYSICAL) 
            {
                //
                other.gameObject.GetComponent<HealthManager>().PhysicalDamage((int)palametar.Power);
            }
            else if(palametar.AttackType == BulletBasePalametar.TYPE.ENERGY)
            {
                //
                other.gameObject.GetComponent<HealthManager>().EnergyDamage(100);
            }
        }
    }
}
