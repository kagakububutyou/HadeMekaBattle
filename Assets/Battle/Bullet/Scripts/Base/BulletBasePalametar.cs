using UnityEngine;
using System.Collections;

public class BulletBasePalametar : MonoBehaviour {
	// 攻撃系パラメータ
	//[SerializeField]
	protected float power;
	//[SerializeField]
	protected float energy;
	
	// 移動系パラメータ
	//[SerializeField]
	protected float speed;
	
	// プロパティ
	public float GetSpeed{get{return speed;}}

	public virtual void SetPalametar(float _power, float _energy, float _speed, GameObject _targetObject)
	{
		power = _power;
		energy = _energy;
		speed = _speed;
	}
}
