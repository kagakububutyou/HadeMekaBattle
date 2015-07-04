using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

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

    NetworkView myNetworkView = null;

    void Start()
    {
        myNetworkView = GetComponent<NetworkView>();
    }

	// Update is called once per frame
	void Update () {

        if (IsCheckCreate())
        {
            shotDeltaTime = NeedCoolTime;

            var clone = (GameObject)Network.Instantiate(bullet,transform.position,Quaternion.identity,1);
            clone.transform.forward = transform.forward;
        }
	}

    /// <summary>
    /// 生成できるかどうかをチェックする。
    /// </summary>
    /// <returns></returns>
    bool IsCheckCreate()
    {
        if (!myNetworkView.isMine) return false;

        shotDeltaTime -= Time.deltaTime;
        if (Input.GetAxis("Fire1") != 0 && shotDeltaTime < 0.0f)
        {
            return true;
        }
        return false;
    }




}
