using UnityEngine;
using System.Collections;

public class ContainerDestroyer : MonoBehaviour 
{

    [SerializeField]
    ContainerStateManager ContainerState = null;

    //int Count = 0;

	// Update is called once per frame
	void Update () 
    {
         //Count   = gameObject.transform.childCount;
         //Debug.Log("Count"+ Count);
	    if(ContainerState.IsOpened)
        {
            Destroy(gameObject); 
        }
    }

    //Playerに衝突した場合
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //コンテナを開ける
            ContainerState.ContainerOpene();
        }
    }


}
