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

    //衝突した場合箱を削除
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void  Destroy()
    {
        ;
    }

}
