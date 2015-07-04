using UnityEngine;
using System.Collections;

// 球を打ち出す
public class BulletShooter : MonoBehaviour {
	[SerializeField]
	private float fireRate;		// 連射速度
	[SerializeField]
	private float power;		// 火力
	[SerializeField]
	private GameObject bullet;	// 生成する弾のプレハブ
	//[SerializeField]
	//private EnergyManager energyManager = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Create();
	}

	// 弾を生成する
	void Create()
	{
		GameObject obj = Instantiate(bullet) as GameObject;
	}
}
