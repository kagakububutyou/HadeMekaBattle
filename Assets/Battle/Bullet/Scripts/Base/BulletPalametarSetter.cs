using UnityEngine;
using System.Collections;

// バレット系クラスにパラメータを入れる仲介クラス
public class BulletPalametarSetter : MonoBehaviour {
	public enum BulletType
	{
		Bullet,
		Missile,
		Lancher,
	};

	[SerializeField]
	private BulletType bulletType;			// 弾丸のタイプ

	private BulletBasePalametar palametar;	// 弾丸のパラメータクラス

	// 外部からパラメータを入れるクラス
	public void SetPalametar(float _power, float _energy, float _speed, GameObject _targetObject)
	{
		SwitchClass ();
		palametar.SetPalametar (_power, _energy, _speed, _targetObject);
	}

	// バレットタイプからGetCompornentするクラスを選定する
	void SwitchClass()
	{
		switch(bulletType)
		{
		case BulletType.Bullet:
			palametar = this.gameObject.GetComponent<BulletPalameter>();
			break;

		case BulletType.Missile:
			palametar = this.gameObject.GetComponent<MissilePalametar>();
			break;

		case BulletType.Lancher:
			palametar = this.gameObject.GetComponent<LancherPalametar>();
			break;
		}
	}
}
