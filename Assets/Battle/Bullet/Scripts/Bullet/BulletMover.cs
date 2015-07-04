using UnityEngine;
using System.Collections;

// 弾の挙動を行うクラス
// 同じオブジェクトに "BulletParameter.cs" を適用していないと動かない
public class BulletMover : MonoBehaviour {
	BulletPalameter bulletPalametar = null;
	Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		bulletPalametar = this.gameObject.GetComponent<BulletPalameter>();
		rigidbody = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// bulletParameter が null なら処理をしない
		if(bulletPalametar == null) return;

		// 向いている方向に進む
		GetComponent<Rigidbody>().velocity = this.transform.TransformDirection(Vector3.forward) * bulletPalametar.GetSpeed;
		//this.transform.position += this.transform.TransformDirection(Vector3.forward) * bulletPalametar.GetSpeed * Time.deltaTime ;
	}
}
