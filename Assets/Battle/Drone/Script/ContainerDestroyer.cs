using UnityEngine;
using System.Collections;

public class ContainerDestroyer : MonoBehaviour 
{
    [SerializeField]
    DroneStateManager drone = null;

	// Use this for initialization
	void Start () 
    {
        //Debug.Log("State->" + doll.DollState);
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    //衝突した場合箱を削除
    private void OnTriggerStay(Collider other)
    {
        if (drone.IsActive) return; 
        //Player
        if (other.tag == "Player")
        {
            if (drone.IsStay) 
            {
                drone.ChangeActive();
                Destroy(gameObject);
            }
            //後にプレイヤーとの接触判定も追加します
        }
    }
}
