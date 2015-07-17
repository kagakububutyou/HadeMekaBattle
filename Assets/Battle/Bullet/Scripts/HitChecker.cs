using UnityEngine;
using System.Collections;

public class HitChecker : MonoBehaviour {

    BulletBasePalametar palametar = null;
    EnergyPalametar energyPalametar = null;

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

    void Start()
    {
        energyPalametar = GetComponent<EnergyPalametar>();
    }

	// Update is called once per frame
	//void Update () {}

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
        Destroy(this.gameObject);

        // ダメージ計算
        if (collision.gameObject.tag == "Player")
        {
            // 接触した相手が持ち主だった場合
            if (collision.gameObject.GetComponent<NetworkView>().isMine == true) return;
            
            // ダメージ計算
            if (palametar.AttackType == BulletPalamaterData.TYPE.PHYSICAL) 
            {
                // 物理ダメージ
                collision.gameObject.GetComponent<HealthManager>().PhysicalDamage((int)palametar.Power);
            }
            else if (palametar.AttackType == BulletPalamaterData.TYPE.ENERGY)
            {
                // エネルギーダメージ
                float pow = ((energyPalametar.Energy + 1.0f) * palametar.Power) + palametar.Power;
                collision.gameObject.GetComponent<HealthManager>().EnergyDamage((int)pow);
            }
        }
    }//*/
}
