using UnityEngine;
using System.Collections;

public class LancherMover : MonoBehaviour {
	LancherPalametar lancherPalametar = null;
	Rigidbody rigidbody = null;

	// Use this for initialization
	void Start () {
		lancherPalametar = this.gameObject.GetComponent<LancherPalametar>();
		rigidbody = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// lancherParametar が null なら処理をしない
		if(lancherPalametar == null) return;

		// 向いている方向に進む
		rigidbody.velocity = this.transform.TransformDirection(Vector3.forward) * lancherPalametar.GetSpeed;
		//this.transform.position += this.transform.TransformDirection(Vector3.forward) * lancherPalametar.GetSpeed * Time.deltaTime ;
	}
}
