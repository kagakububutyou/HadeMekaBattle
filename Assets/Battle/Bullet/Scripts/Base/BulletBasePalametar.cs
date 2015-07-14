using UnityEngine;
using System.Collections;

public class BulletBasePalametar : MonoBehaviour {
    [SerializeField]
    public BuildManager.WeaponID weaponID;

    // 生成された際に取得する必要のあるパラメータ
    private float energy = -1.0f;

	// プロパティ
    public float Power { get { return BulletDataBase.GetData(weaponID).power; } }
    public float Speed { get { return BulletDataBase.GetData(weaponID).speed; } }
    public float Energy { get { return energy; } set { if(energy == -1.0f)energy = value; } }
    public float Firerate { get { return BulletDataBase.GetData(weaponID).fireRate; } }
    public BulletPalamaterData.TYPE AttackType { get { return BulletDataBase.GetData(weaponID).attackType; } }
}
