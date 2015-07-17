using UnityEngine;
using System.Collections;

public class BulletBasePalametar : MonoBehaviour {
    [SerializeField]
    protected BuildManager.WeaponID weaponID;


	// プロパティ
    public float Power { get { return data.power; } }
    public float Speed { get { return data.speed; } }
    public float Firerate { get { return BulletDataBase.GetData(weaponID).fireRate; } }
    public BulletPalamaterData.TYPE AttackType { get { return data.attackType; } }

    protected BulletPalamaterData data = null;

    public void SetData(BuildManager.WeaponID _id) 
    {
        data = BulletDataBase.GetData(weaponID);

        if (data.attackType == BulletPalamaterData.TYPE.ENERGY)
        {
            this.gameObject.AddComponent<EnergyPalametar>();
        }
    }

    /*void Awake()
    {
        data = BulletDataBase.GetData(weaponID);

        Debug.Log(Firerate);

        if (data.attackType == BulletPalamaterData.TYPE.ENERGY) 
        {
            this.gameObject.AddComponent<EnergyPalametar>();
        }
    }*/

}
