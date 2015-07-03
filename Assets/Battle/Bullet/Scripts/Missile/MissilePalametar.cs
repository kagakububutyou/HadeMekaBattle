using UnityEngine;
using System.Collections;

public class MissilePalametar : BulletBasePalametar {
	// ホーミング系パラメータ
	[SerializeField]
	private GameObject targetObject = null;	// 追尾する対象
	[SerializeField]
	private float rotationSpeed = 90.0f;	// 回転する速度(°/秒)

	// プロパティ
	public GameObject GetTargetObject{get{return targetObject;}}
	public float GetRotationSpeed{get{return rotationSpeed;}}
}
