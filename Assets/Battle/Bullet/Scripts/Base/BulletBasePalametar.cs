using UnityEngine;
using System.Collections;

public class BulletBasePalametar : MonoBehaviour {
	// 攻撃系パラメータ
	[SerializeField]
	protected float power = 1.0f;
	//[SerializeField]
	protected float energy = -1.0f;
	[SerializeField]
	private float fireRate = 1.0f;
	
	// 移動系パラメータ
	[SerializeField]
	protected float speed = 1.0f;
	
	// プロパティ
	public float GetSpeed{get{return speed;}}
    public float GetEnergy { get { return energy; } set { if(energy == -1.0f)energy = value; } }
}
