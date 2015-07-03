using UnityEngine;
using System.Collections;

public class BulletValue : MonoBehaviour {
	// 攻撃系パラメータ
	[SerializeField]
	private float power = 5.0f;
	[SerializeField]
	private float energy = 0.0f;

	// 移動系パラメータ
	[SerializeField]
	private float speed = 5.0f;

	// ホーミング系パラメータ
	[SerializeField]
	private bool homingFlag = false;		// ホーミングするか否か
	[SerializeField]
	private float rotationSpeed = 90.0f;	// 回転する速度(°/秒)


	// プロパティ
	public float GetSpeed{get{return speed;} private set{speed = value;}}
	public bool  GetHomingFlag{get{return homingFlag;} private set{homingFlag = value;}}
	public float GetRotationSpeed{get{return rotationSpeed;} private set{rotationSpeed = value;}}
}
