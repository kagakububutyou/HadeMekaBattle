using UnityEngine;
using System.Collections;

// 弾の挙動を行うクラス
// 同じオブジェクトに "BulletValue.cs" を適用していないと動かない
public class BulletMover : MonoBehaviour {
	BulletValue bulletValue = null;

	// Use this for initialization
	void Start () {
		bulletValue = this.gameObject.GetComponent<BulletValue>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position += this.transform.TransformDirection(Vector3.forward) * bulletValue.GetSpeed * Time.deltaTime ;
	}
}
