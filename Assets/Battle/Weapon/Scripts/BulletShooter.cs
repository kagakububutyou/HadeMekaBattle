using UnityEngine;
using System.Collections;

// 球を打ち出す
public class BulletShooter : MonoBehaviour {
	[SerializeField]
	private BuildManager.WeaponID id;			// 武器名
	[SerializeField]
	private float fireRate;						// 連射速度
	[SerializeField]
	private GameObject bullet = null;			// 生成する弾のプレハブ

	private EnergyManager energyManager = null;	// 親オブジェクトからエネルギー値を受け取る

	private float createTimer = 0.0f;			// 弾生成時間管理
	private float createInterval = 0.0f;		// 生成間隔

	public BuildManager.WeaponID GetWeaponId{get{return id;}}

	// Use this for initialization
	void Start () {
		// 親オブジェクトに登録されたEnergyManagerを取得する
		try
		{
			energyManager = GetComponent<EnergyManager>();
		}
		catch//()
		{
			Debug.Log("親オブジェクトが存在していません");
			energyManager = null;
		}
		createInterval = (1.0f / fireRate);
	}
	
	// Update is called once per frame
	void Update () {

	}

	// ショットを打つ(基本外部使用限定)
	public void CreateBullet()
	{
		// クリエイトタイマーを増加させる
		createTimer += Time.deltaTime;

		// タイマーがインターバル値を超えたら生成する処理を呼ぶ
		while(createTimer >= createInterval)
		{
			///Debug.Log("ショット！");
			Create();						// 生成し
			createTimer -= createInterval;	// インターバルを減らす
		}
	}

	// 弾を生成する
	void Create()
	{
		// 生成する
		GameObject obj;
		obj = Instantiate (bullet, this.transform.position, this.transform.rotation) as GameObject;
	}
}
