using UnityEngine;
using System.Collections;

// ミサイルの回転クラス
// MissileParameter.csが同じオブジェクトにないと動かない
public class MissileRotater : MonoBehaviour {

	MissilePalametar missilePalametar = null;
 
    // ホーミングをするか否か
	private bool homingFlag = true;	

	// Use this for initialization
	void Start () {
		missilePalametar = this.gameObject.GetComponent<MissilePalametar>();
	}
	
	// Update is called once per frame
	void Update () {
		// フラグが成立していないなら処理をしない
		if(!homingFlag) return;

		// missileParameter が null なら処理をしない
		if(missilePalametar == null) return;

		// ターゲットが無いなら曲がらない
		//if(missilePalametar.GetTargetObject == null) return;

		// 回転処理
        Vector3 vectorTarget = Vector3.zero;
        //Vector3 vectorTarget = missilePalametar.GetTargetObject.transform.position - this.transform.position;	// ターゲットへのベクトル
        Vector3		vectorForward = this.transform.TransformDirection(Vector3.forward);								// 弾の正面ベクトル
		float		angleDifference = Vector3.Angle(vectorTarget,vectorForward);									// ターゲットまでの角度
		float		angleAdd = (missilePalametar.RotationSpeed * Time.deltaTime);								// 回転角
		Quaternion	rotationTarget = Quaternion.LookRotation(vectorTarget);											// ターゲットへ向けるクォータニオン

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

		// 一定距離まで近づいたら追尾対象を放棄する
		//if(Vector3.Distance(this.transform.position, missilePalametar.GetTargetObject.transform.position) <= missilePalametar.GetApproachRenge) homingFlag = false;
	}
}
