using UnityEngine;
using System.Collections;

// ミサイルの移動クラス
// MissileParameter.csが同じオブジェクトにないと動かない
public class MissileMover : MonoBehaviour {

	MissilePalametar missilePalametar = null;
	Rigidbody rigidbody = null;

	// Use this for initialization
	void Start () {
		missilePalametar = this.gameObject.GetComponent<MissilePalametar>();
		rigidbody = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// missileParameter が null なら処理をしない
		if(missilePalametar == null) return;

		// 向いている方向に移動
		rigidbody.velocity = this.transform.TransformDirection(Vector3.forward) * missilePalametar.Speed;
	}
}
