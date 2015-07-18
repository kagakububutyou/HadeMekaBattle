using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// 球を打ち出す
public class BulletShooter : MonoBehaviour {

    // バレットデータテーブル
    static Dictionary<BuildManager.WeaponID, string> bulletTable = new Dictionary<BuildManager.WeaponID, string>();

	[SerializeField]
	private BuildManager.WeaponID id;			// 武器名
    public BuildManager.WeaponID GetWeaponId { get { return id; } }

    private BuildManager.WeaponType type = BuildManager.WeaponType.NONE;
	
	private GameObject bullet = null;			// 生成する弾のプレハブ

	private EnergyManager energyManager = null;	// 親オブジェクトからエネルギー値を受け取る

    private float fireRate;						// 連射速度
	private float createTimer = 0.0f;			// 弾生成時間管理
	private float createInterval = 0.0f;		// 生成間隔

    private int bulletNumber = 100;             // 残段数



    private GameObject effect;                  // エフェクトのプレハブ

	// Use this for initialization
	void Start () {
        if(bulletTable.Count == 0)
        {
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

        // タイプをセット
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
        if(bullet == null)
        {
            Debug.Log("bullet is NULL!!");
        }

        // ファイアレートをセット
        fireRate = BulletDataBase.GetData(id).fireRate;
        if(fireRate <= -1 || fireRate == 0.0f)
        {
            Debug.Log("firerate is failed");
        }
        createInterval = (1.0f / fireRate);

        // 弾数をセット
        if (BulletDataBase.GetData(id).bulletNumber != 0)
        {
            bulletNumber = BulletDataBase.GetData(id).bulletNumber;
        }

        // エフェクトを取得
        effect = GetEffect(bullet);
	}
	
	// Update is called once per frame
	void Update () 
    {
        // CreateBulletが呼ばれていない間の処理

    }

	// ショットを打つ(基本外部使用限定)
	public void CreateBullet()
	{
        // 残段数がなければ処理をしない
        if (bulletNumber > 0)
        {
            // クリエイトタイマーを増加させる
            createTimer += Time.deltaTime;

            // タイマーがインターバル値を超えたら生成する処理を呼ぶ
            while (createTimer >= createInterval && bulletNumber > 0)
            {
                Create();						
                createTimer -= createInterval;	
                bulletNumber--;
            }
        }
	}

	// 弾を生成する
	void Create()
	{
		// 生成する
		GameObject obj;
		obj = Network.Instantiate (bullet, this.transform.position, this.transform.rotation, 0) as GameObject;
        //EffekseerEmitter.Create(effect, this.transform.position);

        GetPalameterLoading(obj);

        // energyをセットする
        EnergySet(obj);

		// ホーミングミサイルならターゲットの座標を要求する処理を噛ませる
        TargetRequest(obj);
	}

    // レートを取得
    void GetPalameterLoading(GameObject _obj)
    {
        switch (type)
        {
            case BuildManager.WeaponType.MachineGun:
            case BuildManager.WeaponType.Rifle:
                _obj.GetComponent<BulletPalameter>().GetPalameterData();
                break;

            case BuildManager.WeaponType.Missile:
                _obj.GetComponent<MissilePalametar>().GetPalameterData();
                break;

            case BuildManager.WeaponType.Launcher:
                _obj.GetComponent<LancherPalametar>().GetPalameterData();
                break;
        }
    }

    // レートを取得
    float GetRate(GameObject _obj)
    {
        switch (type)
        {
            case BuildManager.WeaponType.MachineGun:
            case BuildManager.WeaponType.Rifle:
                return _obj.GetComponent<BulletPalameter>().Firerate;

            case BuildManager.WeaponType.Missile:
                return _obj.GetComponent<MissilePalametar>().Firerate;

            case BuildManager.WeaponType.Launcher:
                return _obj.GetComponent<LancherPalametar>().Firerate;
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
                if (GetType(_obj) == BulletPalamaterData.TYPE.ENERGY)
                {
                    Debug.Log(_obj.gameObject.GetComponent<EnergyPalametar>().name);
                    _obj.gameObject.GetComponent<EnergyPalametar>().Energy = energyManager.EnergyRatio;
                }
                break;

            case BuildManager.WeaponType.Missile:
                if (GetType(_obj) == BulletPalamaterData.TYPE.ENERGY)
                {
                    _obj.gameObject.GetComponent<EnergyPalametar>().Energy = energyManager.EnergyRatio;
                }    
                break;

            case BuildManager.WeaponType.Launcher:
                if (GetType(_obj) == BulletPalamaterData.TYPE.ENERGY)
                {
                    _obj.gameObject.GetComponent<EnergyPalametar>().Energy = energyManager.EnergyRatio;
                }
                break;
        }
    }

    // ホーミングミサイルが要求する
    void TargetRequest(GameObject _obj) 
    {
        if ((int)id / 10 == (int)BuildManager.WeaponType.Missile)
        {
            // ターゲットを要求する
            _obj.gameObject.GetComponent<MissilePalametar>().TargetObject = null;
        }
    }

    // エフェクトの取得
    GameObject GetEffect(GameObject _obj) 
    {
        switch (type)
        {
            case BuildManager.WeaponType.MachineGun:
            case BuildManager.WeaponType.Rifle:
                if (GetType(_obj) == BulletPalamaterData.TYPE.ENERGY)
                {
                    return (GameObject)Resources.Load("Effects/EnergyFiring");
                }
                break;

            case BuildManager.WeaponType.Missile:
                if (GetType(_obj) == BulletPalamaterData.TYPE.ENERGY)
                {
                    return (GameObject)Resources.Load("Effects/EnergyFiring");
                }
                break;

            case BuildManager.WeaponType.Launcher:
                if (GetType(_obj) == BulletPalamaterData.TYPE.ENERGY)
                {
                    return (GameObject)Resources.Load("Effects/EnergyFiring");
                }
                break;
        }

        return (GameObject)Resources.Load("Effects/LiveAmmunitionFiring");
    }

    // 攻撃タイプの取得
    BulletPalamaterData.TYPE GetType(GameObject _obj) 
    {
        switch (type)
        {
            case BuildManager.WeaponType.MachineGun:
            case BuildManager.WeaponType.Rifle:
                if (_obj.gameObject.GetComponent<BulletPalameter>().AttackType == BulletPalamaterData.TYPE.ENERGY)
                {
                    return BulletPalamaterData.TYPE.ENERGY;
                }
                break;

            case BuildManager.WeaponType.Missile:
                if (_obj.gameObject.GetComponent<MissilePalametar>().AttackType == BulletPalamaterData.TYPE.ENERGY)
                {
                    return BulletPalamaterData.TYPE.ENERGY;
                }
                break;

            case BuildManager.WeaponType.Launcher:
                if (_obj.gameObject.GetComponent<LancherPalametar>().AttackType == BulletPalamaterData.TYPE.ENERGY)
                {
                    return BulletPalamaterData.TYPE.ENERGY;
                }
                break;
        }
        return BulletPalamaterData.TYPE.PHYSICAL;
    }
}
