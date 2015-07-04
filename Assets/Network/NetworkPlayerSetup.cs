using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkPlayerSetup : NetworkBehaviour {

    GameObject sceneCamera = null;

	// Use this for initialization
	void Start () {
        sceneCamera =  GameObject.Find("Scene Camera");
        OpponentDestroy();

        if(sceneCamera != null)
            sceneCamera.SetActive(false);

        if (isLocalPlayer)
        {
            transform.FindChild("Main Camera").parent = null;
        }
	}

    /// <summary>
    /// 対戦相手でいらないComponentやGameObjectを削除する。
    /// </summary>
    void OpponentDestroy()
    {
        if (!isLocalPlayer)
        {
            Destroy(GetComponent<PlayerMover>());
            Destroy(GetComponent<PlayerJumper>());
            Destroy(transform.FindChild("Main Camera").gameObject);
        }
    }

    // Update is called once per frame
	void Update () {
	
	}
}
