using UnityEngine;
using System.Collections;

public class NetworkManagerSetup : MonoBehaviour {

    [SerializeField]
    GameObject objectPrefab;
    
    [SerializeField]
    string ip = "localhost";

    [SerializeField]
    string port = "7777";
    
    bool connected = false;

    //サーバ立ち上げ時に呼ばれるメソッド
    public void OnServerInitialized()
    {
        connected = true;
        //ネットワーク内のすべてのPCでインスタンス化が行われるメソッド
        Network.Instantiate(objectPrefab, objectPrefab.transform.position, objectPrefab.transform.rotation, 1);
    }

    //サーバに接続したときに呼ばれるメソッド
    public void OnConnectedToServer()
    {
        connected = true;
        Network.Instantiate(objectPrefab, objectPrefab.transform.position, objectPrefab.transform.rotation, 2);
    }
		
	// Use this for initialization
	void Start () {
	}

    public void OnGUI()
    {
        if (!connected)
        {
            GUI.Label(new Rect(40, 250, 100, 30), "HOST IP");
            Rect rect1 = new Rect(100, 250, 250, 30);
            ip = GUI.TextField(rect1, ip, 32);

            if (GUI.Button(new Rect(10, 10, 90, 90), "Client"))
            {
                //(hostのIPアドレス,hostが接続を受け入れているポート番号)
                Network.Connect(ip, int.Parse(port));
            }

            if (GUI.Button(new Rect(10, 110, 90, 90), "Server"))
            {
                //(接続可能人数,接続を受け入れるポート番号,NATのパンチスルー機能の設定)
                Network.InitializeServer(10, int.Parse(port), false);
            }
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
