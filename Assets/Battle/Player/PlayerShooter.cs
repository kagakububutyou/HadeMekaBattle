using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerShooter : MonoBehaviour {

    /// <summary>
    /// クールタイム
    /// </summary>
    [SerializeField]
    const float NeedCoolTime = 0.5f;

    /// <summary>
    /// 前回打ってからの時間
    /// </summary>
    float shotDeltaTime = 0.0f;

    NetworkView myNetworkView = null;

    BulletShooter bulletShooter = null;

    void Start()
    {
        myNetworkView = GetComponent<NetworkView>();
        bulletShooter = GetComponent<BulletShooter>();
    }

	// Update is called once per frame
	void Update () {

        if (IsCheckCreate())
        {
            bulletShooter.CreateBullet();
        }
	}

    /// <summary>
    /// 生成できるかどうかをチェックする。
    /// </summary>
    /// <returns></returns>
    bool IsCheckCreate()
    {
        if (!myNetworkView.isMine) return false;

        if (Input.GetAxis("Fire1") != 0 )
        {
            return true;
        }
        return false;
    }




}
