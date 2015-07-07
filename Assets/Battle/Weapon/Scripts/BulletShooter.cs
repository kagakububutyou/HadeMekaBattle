using UnityEngine;
using System.Collections;

// 球を打ち出す
public class BulletShooter : MonoBehaviour {
	[SerializeField]
	private BuildManager.WeaponType type;		// 武器タイプ
	[SerializeField]
	private BuildManager.WeaponID id;			// 武器名
	[SerializeField]
	private float fireRate;						// 連射速度
	[SerializeField]
	private float power;						// 火力
	[SerializeField]
	private float speed;						// 弾丸速度
	[SerializeField]
	private GameObject bullet;					// 生成する弾のプレハブ
	[SerializeField]
	private Vector3 criatePosition;				// 弾の生成ポジション (+ 武器のポジション)　調整中のため未実装

	private EnergyManager energyManager = null;	// 親オブジェクトからエネルギー値を受け取る

	private float createTimer = 0.0f;			// 弾生成時間管理
	private float createInterval = 0.0f;		// 生成間隔
	private bool triggerOnFlag = false;			// ショットを行っているかのフラグ(タイマーの初期化などに使う)
	private float previousTimer = 0.0f;			// 前フレームの生成時間
	
	public BuildManager.WeaponType GetWeaponType{get{return type;}}
	public BuildManager.WeaponID GetWeaponId{get{return id;}}

	// Use this for initialization
	void Start () {
		// 親オブジェクトに登録されたEnergyManagerを取得する
		try
		{
			energyManager = gameObject.transform.parent.gameObject.GetComponent<EnergyManager>();
		}
		catch//()
		{
			Debug.Log("親オブジェクトが存在していません");
			energyManager = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(createInterval == 0.0f) createInterval = (1.0f / fireRate);	// Startで初期化失敗したときの為の保険
		CheckCreateTrigger ();
		TestCreateShot ();		// BulletTestシーンでのみ有効
	}

	// ショットを打つ(基本外部使用限定)
	public void CreateBullet()
	{
		// トリガーを起動する
		if(!triggerOnFlag) triggerOnFlag = true;

		// クリエイトタイマーを増加させる
		createTimer += Time.deltaTime;

		// タイマーがインターバル値を超えたら生成する処理を呼ぶ
		while(createTimer >= createInterval)
		{
			Create();						// 生成し
			createTimer -= createInterval;	// インターバルを減らす
			previousTimer = createTimer;	// このフレームのタイマーを保存する
		}
	}

	// 弾を生成する
	void Create()
	{
		// 生成する
		GameObject obj = Network.Instantiate(bullet,this.transform.position,this.transform.rotation,0) as GameObject;

		// 生成したオブジェクトにパラメータを適用する
		GameObject target = null;
		if(type == BuildManager.WeaponType.Missile) target = null;	// ミサイルなら目標物のゲームオブジェクトをリクエスト(実装待ち)

		if (energyManager == null) 
		{
			obj.gameObject.GetComponent<BulletPalametarSetter>().SetPalametar(power, 0.0f, speed, target);
		}
		else 
		{
			obj.gameObject.GetComponent<BulletPalametarSetter>().SetPalametar(power, energyManager.EnergyRatio, speed, target);
		}
	}

	void CheckCreateTrigger()
	{
		// そもそもフラグが立っていない場合
		if(!triggerOnFlag) return;

		// createTimerが更新されていないのであれば値は同じのはず
		if (previousTimer == createTimer) 
		{
			triggerOnFlag = false;
			createTimer = createInterval;
		}
	}

	// BulletTestシーンでのみ有効なメソッド
	void TestCreateShot()
	{
		if (Application.loadedLevelName == "BulletTest") 
		{
			if (Input.GetButton ("Fire2")) CreateBullet ();	// テスト
		}
	}
}
