using UnityEngine;
using System.Collections;

// ミサイルのパラメータ
public class MissilePalametar : BulletBasePalametar {
	//---------ホーミング系パラメータ------------//
    // 追尾する対象
    [SerializeField]
	private GameObject targetObject = null;	

    // 回転する速度(°/秒)
    [SerializeField]
	private float rotationSpeed = 90.0f;	

    // ホーミング処理を行わなくなる距離
    [SerializeField]
	private float finalApproachRange = 5.0f;

	//---------------プロパティ----------------//
	public GameObject TargetObject
    {
        get
        {
            return targetObject;
        }
        set
        {
            if(targetObject == null)targetObject = value;
        }
    }

	public float RotationSpeed{get{return rotationSpeed;}}
	public float ApproachRange{get{return finalApproachRange;}}

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
