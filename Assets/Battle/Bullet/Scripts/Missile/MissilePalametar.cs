using UnityEngine;
using System.Collections;

// ミサイルのパラメータ
public class MissilePalametar : BulletBasePalametar {
	// ホーミング系パラメータ
	[SerializeField]
	private GameObject targetObject = null;	// 追尾する対象
	[SerializeField]
	private float rotationSpeed = 90.0f;	// 回転する速度(°/秒)
	[SerializeField]
	private float finalApproachRenge = 5.0f;// ホーミング処理を行わなくなる距離

	// プロパティ
	public GameObject TargetObject{get{return targetObject;} set{if(targetObject == null)targetObject = value;}}
	public float GetRotationSpeed{get{return rotationSpeed;}}
	public float GetApproachRenge{get{return finalApproachRenge;}}

    void Start()
    {
        this.gameObject.GetComponent<HitChecker>().Palametar = this;
    }
}
