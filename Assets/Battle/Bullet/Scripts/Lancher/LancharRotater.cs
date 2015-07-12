using UnityEngine;
using System.Collections;

// ランチャー弾の回転処理
public class LancharRotater : MonoBehaviour {

	LancherPalametar lancherPalametar = null;

	// Use this for initialization
	void Start () {
		lancherPalametar = this.gameObject.GetComponent<LancherPalametar>();
	}
	
	// Update is called once per frame
	void Update () {
		// lancherParametar が null なら処理をしない
		if(lancherPalametar == null) return;

		// 回転処理
		Vector3		vectorTarget = new Vector3(this.transform.TransformDirection(Vector3.forward).x,
		                                    lancherPalametar.VectorRotationY,
		                                    this.transform.TransformDirection(Vector3.forward).z);		// ターゲットへのベクトル

		Vector3		vectorForward = this.transform.TransformDirection(Vector3.forward);					// 弾の正面ベクトル

		float		angleDifference = Vector3.Angle(vectorTarget,vectorForward);						// ターゲットまでの角度

		float		angleAdd = (lancherPalametar.RotationSpeed * Time.deltaTime);					// 回転角

		Quaternion	rotationTarget = Quaternion.LookRotation(vectorTarget);								// ターゲットへ向けるクォータニオン

		if(angleDifference <= angleAdd)
		{
			// ターゲットが回転角以内なら完全にターゲットの方を向く
			this.transform.rotation = rotationTarget;
		}
		else
		{
			// ターゲットが回転角の外なら、指定角度だけターゲットに向ける
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotationTarget, (angleAdd / angleDifference));
		}
	}
}
