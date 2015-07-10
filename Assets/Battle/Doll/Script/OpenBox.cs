using UnityEngine;
using System.Collections;

public class OpenBox : MonoBehaviour 
{
    [SerializeField]
    DollStateManager doll = null;

	// Use this for initialization
	void Start () 
    {
        //GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    //衝突した場合箱を削除
    private void OnTriggerEnter(Collider other)
    {
        //後にプレイヤーとの接触判定も追加します
        if (doll.IsWaiting) { Destroy(gameObject); }

        if(doll.IsAiring){ doll.ChangeWaiting(); return; }
        //Debug.Log("State->" + DollState);
    }
}
