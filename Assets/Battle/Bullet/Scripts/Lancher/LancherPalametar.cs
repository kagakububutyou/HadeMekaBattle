using UnityEngine;
using System.Collections;

// ランチャーのパラメータ
public class LancherPalametar : BulletBasePalametar {

	[SerializeField]
	private float vectorRotationY = -0.5f;	// ベクトルでの最終的に向いて欲しい向き(Y)

	[SerializeField]
	private float rotationSpeed = 15.0f;	// 一秒間に曲がる角度

    public float VectorRotationY { get { return vectorRotationY; } }
    public float RotationSpeed { get { return rotationSpeed; } }

    void Start()
    {
        this.gameObject.GetComponent<HitChecker>().Palametar = this;

        data = BulletDataBase.GetData(weaponID);

        if (data.attackType == BulletPalamaterData.TYPE.ENERGY)
        {
            this.gameObject.AddComponent<EnergyPalametar>();
        }
    }
}
