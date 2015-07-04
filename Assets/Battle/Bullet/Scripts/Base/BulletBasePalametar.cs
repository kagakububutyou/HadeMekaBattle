using UnityEngine;
using System.Collections;

public class BulletBasePalametar : MonoBehaviour {
	// 攻撃系パラメータ
	[SerializeField]
	protected float power = 5.0f;
	[SerializeField]
	protected float energy = 0.0f;
	
	// 移動系パラメータ
	[SerializeField]
	protected float speed = 5.0f;
	
	// プロパティ
	public float GetSpeed{get{return speed;}}
}
