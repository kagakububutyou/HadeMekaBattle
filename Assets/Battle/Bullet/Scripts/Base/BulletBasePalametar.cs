using UnityEngine;
using System.Collections;

public class BulletBasePalametar : MonoBehaviour {
    [SerializeField]
    protected BuildManager.WeaponID weaponID;

    protected HitChecker checker = null;       // ヒットチェッカークラス
    protected GameObject bullet = null;        // 弾のデータ
    protected GameObject effect = null;        // エフェクトのデータ

	// プロパティ
    public float Power { get { return data.power; } }
    public float Speed { get { return data.speed; } }
    public float Firerate { get { return BulletDataBase.GetData(weaponID).fireRate; } }
    public BulletPalamaterData.TYPE AttackType { get { if (data != null) return data.attackType; else return BulletDataBase.GetData(weaponID).attackType; } }
    public int BulletNumber { get { return BulletDataBase.GetData(weaponID).bulletNumber; } }

    protected BulletPalamaterData data = null;

    public void GetPalameterData()
    {
        // dataのセット
        data = BulletDataBase.GetData(weaponID);
        if (data.attackType == BulletPalamaterData.TYPE.ENERGY)
        {
            this.gameObject.AddComponent<EnergyPalametar>();
        }

        // プレハブのセット
        if (AttackType == BulletPalamaterData.TYPE.PHYSICAL)
        {
            bullet = (GameObject)Resources.Load("Effects/LiveBullet");
            effect = (GameObject)Resources.Load("Effects/LiveHit");
        }
        else 
        {
            bullet = (GameObject)Resources.Load("Effects/EnergyBullet");
            effect = (GameObject)Resources.Load("Effects/EnergyHit");
        }

        // checkerのセット
        checker = this.gameObject.GetComponent<HitChecker>();
        checker.Palametar = this;
        checker.Effect = effect;

        GameObject clone = Network.Instantiate (bullet, this.transform.position, this.transform.rotation, 0) as GameObject;
        clone.transform.parent = this.gameObject.transform;
    }
}
