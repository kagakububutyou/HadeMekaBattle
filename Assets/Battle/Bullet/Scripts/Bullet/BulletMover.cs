using UnityEngine;
using System.Collections;

// 弾の挙動を行うクラス
// 同じオブジェクトに "BulletParameter.cs" を適用していないと動かない
public class BulletMover : MonoBehaviour {
	BulletPalameter bulletPalameter = null;

	// Use this for initialization
	void Start () {
		bulletPalameter = this.gameObject.GetComponent<BulletPalameter>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// bulletParameter が null なら処理をしない
		if(bulletPalameter == null) return;

		// 向いている方向に進む
		this.transform.position += this.transform.TransformDirection(Vector3.forward) * bulletPalameter.GetSpeed * Time.deltaTime ;
	}
}
