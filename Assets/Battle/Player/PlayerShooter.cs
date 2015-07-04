using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour {

    [SerializeField]
    GameObject bullet = null;

    /// <summary>
    /// クールタイム
    /// </summary>
    [SerializeField]
    const float NeedCoolTime = 0.5f;

    /// <summary>
    /// 前回打ってからの時間
    /// </summary>
    float shotDeltaTime = 0.0f;

	// Update is called once per frame
	void Update () {
	    if(Input.GetAxis("Fire1") != 0 && shotDeltaTime < 0.0f)
        {
            var clone = (GameObject)Instantiate(bullet,transform.position,Quaternion.identity);
            clone.transform.forward = transform.forward;
            shotDeltaTime = NeedCoolTime;
        }
        shotDeltaTime -= Time.deltaTime;
	}
}
