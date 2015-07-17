using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManagerSetup : MonoBehaviour {

    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    List<GameObject> createPrefabs = new List<GameObject>();

    [SerializeField]
    string ip = "localhost";

    [SerializeField]
    string port = "7777";

    [SerializeField]
    int connectionNum = 2;

    [SerializeField]
    string roomName = "HadeMekaBattle";

    [SerializeField]
    string roomTypeName = "HadeMekaBattleType";

    [SerializeField]
    float connectTimeOver = 2.0f;

    EnemyListManager enemyListManager = null;

    bool connected = false;
    bool isInitializeServer = false;



    void CreatePrefab()
    {
        foreach (var obj in createPrefabs)
        {
            Network.Instantiate(obj, obj.transform.position, obj.transform.rotation, 0);
        }
    }

    //サーバ立ち上げ時に呼ばれるメソッド
    public void OnServerInitialized()
    {
        Network.Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation, 1);
    }

    //サーバに接続したときに呼ばれるメソッド
    public void OnConnectedToServer()
    {
        Network.Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation, 2);
    }

    /// <summary>
    /// クライアントのプレーヤが切断した時に実行されます
    /// </summary>
    /// <param name="player"></param>
    public void OnPlayerDisconnected(NetworkPlayer player) 
    {
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
        enemyListManager.RefreshList();
    }

	// Use this for initialization
    void Start()
    {
        StartCoroutine(WaitRequestHostList());
        StartCoroutine(WaitInitializeServer());
        enemyListManager = GameObject.Find("EnemyManager").GetComponent<EnemyListManager>();
    }

    public void OnGUI()
    {
        if (Network.isServer)
            GUI.Label(new Rect(0, 0, 200, 100), "Server");

        if (Network.isClient)
            GUI.Label(new Rect(0, 0, 200, 100), "Client");
    }

    IEnumerator WaitRequestHostList()
    {
        yield return new WaitForSeconds(1.0f);

        MasterServer.RequestHostList(roomTypeName);
    }

    IEnumerator WaitInitializeServer()
    {
        yield return new WaitForSeconds(connectTimeOver);

        isInitializeServer = true;
    }


    IEnumerator WaitConnect(HostData element)
    {
        yield return new WaitForSeconds(connectTimeOver);
        Network.Connect(element);
    }

    /// <summary>
    /// サーバー側を初期化し、部屋を作る。
    /// </summary>
    void InitializeServer()
    {
        if (isInitializeServer)
        {
            if (MasterServer.PollHostList().Length > 0) return;

            // セキュリティーを初期化
            Network.InitializeSecurity();
            //(接続可能人数,接続を受け入れるポート番号,NATのパンチスルー機能の設定)
            Network.InitializeServer(connectionNum - 1, int.Parse(port), !Network.HavePublicAddress());
            MasterServer.RegisterHost(roomTypeName, roomName);
            isInitializeServer = false;
        }
    }

    /// <summary>
    /// クライアント側を接続
    /// </summary>
    void ClientConnect()
    {
        HostData[] data = MasterServer.PollHostList();
        // Go through all the hosts in the host list
        foreach (var element in data)
        {
            if (!connected)
            {
                StartCoroutine(WaitConnect(element));
                connected = true;
            }
        }

    }
    // Update is called once per frame
	void Update () {
        InitializeServer();
        ClientConnect();
	}
}
