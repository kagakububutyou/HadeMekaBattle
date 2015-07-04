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
}
