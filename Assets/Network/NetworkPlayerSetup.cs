using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkPlayerSetup : MonoBehaviour {

    GameObject sceneCamera = null;
    NetworkView myNetworkView = null;
    GameObject enemyManager = null;
    AttachCamera attachCamera = null;
    // Use this for initialization
	void Start () {
        myNetworkView = GetComponent<NetworkView>();
        sceneCamera =  GameObject.Find("Scene Camera");
        enemyManager = GameObject.Find("EnemyManager");
        attachCamera = GetComponent<AttachCamera>();

        OpponentDestroy();

        if(sceneCamera != null)
            sceneCamera.SetActive(false);

        if (myNetworkView.isMine)
        {
            transform.FindChild("Main Camera").parent = null;
            attachCamera.Initialize();
            attachCamera.Attach();
        }
	}

    /// <summary>
    /// 対戦相手でいらないComponentやGameObjectを削除する。
    /// </summary>
    void OpponentDestroy()
    {
        if (!myNetworkView.isMine)
        {
            tag = "Enemy";
            Destroy(GetComponent<PlayerMover>());
            Destroy(GetComponent<PlayerJumper>());
          //  Destroy(GetComponent<PlayerShooter>());
            Destroy(transform.FindChild("Main Camera").gameObject);
            Destroy(GetComponent<PlayerRespawner>());

            Destroy(GetComponent<AttachCamera>());
            enemyManager.GetComponent<EnemyListManager>().Add(gameObject);
        }
    }

    // Update is called once per frame
	void Update () {
	
	}
}
