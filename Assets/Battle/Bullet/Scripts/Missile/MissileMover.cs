using UnityEngine;
using System.Collections;

// ミサイルの移動クラス
// MissileParameter.csが同じオブジェクトにないと動かない
public class MissileMover : MonoBehaviour {
	MissilePalametar missilePalametar = null;
	
	// Use this for initialization
	void Start () {
		missilePalametar = this.gameObject.GetComponent<MissilePalametar>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// missileParameter が null なら処理をしない
		if(missilePalametar == null) return;

		// 向いている方向に移動
		this.transform.position += this.transform.TransformDirection(Vector3.forward) * missilePalametar.GetSpeed * Time.deltaTime ;
	}
}
