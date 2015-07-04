﻿using UnityEngine;
using System.Collections;

public class NetworkManagerSetup : MonoBehaviour {

    [SerializeField]
    GameObject objectPrefab;
    
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

    bool connected = false;
    bool isInitializeServer = false;

    //サーバ立ち上げ時に呼ばれるメソッド
    public void OnServerInitialized()
    {
        Network.Instantiate(objectPrefab, objectPrefab.transform.position, objectPrefab.transform.rotation, 1);
    }

    //サーバに接続したときに呼ばれるメソッド
    public void OnConnectedToServer()
    {
        Network.Instantiate(objectPrefab, objectPrefab.transform.position, objectPrefab.transform.rotation, 2);
    }

    /// <summary>
    /// クライアントのプレーヤが切断した時に実行されます
    /// </summary>
    /// <param name="player"></param>
    public void OnPlayerDisconnected(NetworkPlayer player) 
    {
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
    }

	// Use this for initialization
    void Start()
    {
        StartCoroutine(WaitRequestHostList());
        StartCoroutine(WaitInitializeServer());
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