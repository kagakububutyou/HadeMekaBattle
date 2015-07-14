using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//--------------------------------------------------
[System.Serializable]
public struct DataBase
{
    public float power;
    public float speed;
}

[System.Serializable]
public class BulletTable : TableBase<BuildManager.WeaponID, DataBase, BulletPair>
{ }

[System.Serializable]
public class BulletPair : KeyAndValue<BuildManager.WeaponID, DataBase>
{
    public BulletPair(BuildManager.WeaponID key, DataBase value)
        : base(key, value)
    { }
}
//--------------------------------------------------

// 球を打ち出す
public class BulletShooter : MonoBehaviour {
    [SerializeField]
    private BulletTable table;

    // バレットデータテーブル
    static Dictionary<BuildManager.WeaponID, string> bulletTable = new Dictionary<BuildManager.WeaponID, string>();

	[SerializeField]
	private BuildManager.WeaponID id;			// 武器名

    private BuildManager.WeaponType type = BuildManager.WeaponType.NONE;
	//[SerializeField]
	private GameObject bullet = null;			// 生成する弾のプレハブ

	private float fireRate;						// 連射速度

	private EnergyManager energyManager = null;	// 親オブジェクトからエネルギー値を受け取る

	private float createTimer = 0.0f;			// 弾生成時間管理
	private float createInterval = 0.0f;		// 生成間隔

	public BuildManager.WeaponID GetWeaponId{get{return id;}}

	// Use this for initialization
	void Start () {
        if(bulletTable.Count == 0)
        {
            //Debug.Log("初期化 : bulletTable");
            bulletTable.Add(BuildManager.WeaponID.SGMT, "Bullet_SGMT");
            bulletTable.Add(BuildManager.WeaponID.YMD, "Bullet_YMD");
            bulletTable.Add(BuildManager.WeaponID.HRTK, "Bullet_HRTK");
            bulletTable.Add(BuildManager.WeaponID.TKG, "Bullet_TKG");
            bulletTable.Add(BuildManager.WeaponID.雷楽, "RBullet_Raigaku");
            bulletTable.Add(BuildManager.WeaponID.藤鷹, "RBullet_Fuzitaka");
            bulletTable.Add(BuildManager.WeaponID.南, "RBullet_Minami");
            bulletTable.Add(BuildManager.WeaponID.パリサイトジャン, "Missile_PariSitejan");
            bulletTable.Add(BuildManager.WeaponID.コガマージャン, "Missile_KogaMajan");
            bulletTable.Add(BuildManager.WeaponID.オートモージャン, "Missile_AutoMojan");
            bulletTable.Add(BuildManager.WeaponID.End_of_a_Tard, "Missile_End_of_a_Tard");
            bulletTable.Add(BuildManager.WeaponID.M_F_DS, "Lancher_M_F_DS");
            bulletTable.Add(BuildManager.WeaponID.M_T_GK, "Lancher_M_T_GK");
            bulletTable.Add(BuildManager.WeaponID.L_F_GK, "Lancher_L_F_GK");
        }

        type = BuildManager.GetTypeByID(id);


		// 親オブジェクトに登録されたEnergyManagerを取得する
		try
		{
			energyManager = GetComponent<EnergyManager>();
		}
		catch
		{
			energyManager = null;
		}
		

        // プレハブを取得
        bullet = (GameObject)Resources.Load(("Prefabs/" + bulletTable[id]));
        Debug.Log(bullet);
       
        if(bullet == null)
        {
            Debug.Log("bullet is NULL!!");
        }

        fireRate = GetRate();

        if(fireRate < -1)
        {
            Debug.Log("firerate is failed");
        }

        createInterval = (1.0f / fireRate);

	}
	
	// Update is called once per frame
	//void Update () {}

	// ショットを打つ(基本外部使用限定)
	public void CreateBullet()
	{
        //Debug.Log("cr bll");
		// クリエイトタイマーを増加させる
		createTimer += Time.deltaTime;

		// タイマーがインターバル値を超えたら生成する処理を呼ぶ
		while(createTimer >= createInterval)
		{
			//Debug.Log("ショット！");
			Create();						// 生成し
			createTimer -= createInterval;	// インターバルを減らす
		}
	}

	// 弾を生成する
	void Create()
	{
		// 生成する
		GameObject obj;
		obj = Network.Instantiate (bullet, this.transform.position, this.transform.rotation, 0) as GameObject;

        // energyをセットする
        EnergySet(obj);

		// ホーミングミサイルならターゲットの座標を要求する処理を噛ませる
        TargetRequest(obj);
	}

    float GetRate()
    {
        

        switch (type)
        {
            case BuildManager.WeaponType.MachineGun:
            case BuildManager.WeaponType.Rifle:
                return bullet.GetComponent<BulletPalameter>().Firerate;

            case BuildManager.WeaponType.Missile:
                return bullet.GetComponent<MissilePalametar>().Firerate;

            case BuildManager.WeaponType.Launcher:
                return bullet.GetComponent<LancherPalametar>().Firerate;
        }

        return -1;
    }

    // エネルギーを取得させる
    void EnergySet(GameObject _obj)
    {
        switch (type)
        {
            case BuildManager.WeaponType.MachineGun:
            case BuildManager.WeaponType.Rifle:
                //_obj.gameObject.GetComponent<BulletPalameter>().Energy = energyManager.EnergyRatio;
                break;

            case BuildManager.WeaponType.Missile:
                //_obj.gameObject.GetComponent<MissilePalametar>().Energy = energyManager.EnergyRatio;
                break;

            case BuildManager.WeaponType.Launcher:
                //_obj.gameObject.GetComponent<LancherPalametar>().Energy = energyManager.EnergyRatio;
                break;
        }
    }

    // ホーミングミサイルが要求する
    void TargetRequest(GameObject _obj) 
    {
        if ((int)id / 10 == (int)BuildManager.WeaponType.Missile)
        {
            _obj.gameObject.GetComponent<MissilePalametar>().TargetObject = null;
        }
    }
}
