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
	
	// ホーミング系パラメータ
	//[SerializeField]
	//private GameObject targetObject = null;	// 追尾する対象
	//[SerializeField]
	//private float rotationSpeed = 90.0f;	// 回転する速度(°/秒)
	
	
	// プロパティ
	public float GetSpeed{get{return speed;}}
	//public float GetRotationSpeed{get{return rotationSpeed;}}
}
