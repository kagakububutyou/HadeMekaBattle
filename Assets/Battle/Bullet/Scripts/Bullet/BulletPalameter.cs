using UnityEngine;
using System.Collections;

// 
public class BulletPalameter : BulletBasePalametar {
	enum TYPE
	{
		PHYSICAL,
		ENERGY,
	};

	[SerializeField]
	private TYPE attackType = TYPE.PHYSICAL;	// 攻撃タイプ

	public override void SetPalametar(float _power, float _energy, float _speed, GameObject _targetObject)
	{
		power = _power;
		energy = _energy;
		speed = _speed;
	}
}
