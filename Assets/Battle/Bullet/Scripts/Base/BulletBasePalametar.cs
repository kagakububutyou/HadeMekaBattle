using UnityEngine;
using System.Collections;

public class BulletBasePalametar : MonoBehaviour {
    [SerializeField]
    protected BuildManager.WeaponID weaponID;


	// プロパティ
    public float Power { get { return data.power; } }
    public float Speed { get { return data.speed; } }
    public float Firerate { get { return BulletDataBase.GetData(weaponID).fireRate; } }
    public BulletPalamaterData.TYPE AttackType { get { if (data != null) return data.attackType; else return BulletDataBase.GetData(weaponID).attackType; } }
    public int BulletNumber { get { return BulletDataBase.GetData(weaponID).bulletNumber; } }

    protected BulletPalamaterData data = null;

    public void GetPalameterData()
    {
        this.gameObject.GetComponent<HitChecker>().Palametar = this;

        data = BulletDataBase.GetData(weaponID);

        if (data.attackType == BulletPalamaterData.TYPE.ENERGY)
        {
            this.gameObject.AddComponent<EnergyPalametar>();
        }
    }
}
