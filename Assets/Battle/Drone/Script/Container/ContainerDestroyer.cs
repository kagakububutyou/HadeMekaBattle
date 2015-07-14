using UnityEngine;
using System.Collections;

public class ContainerDestroyer : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
        //ContainerState = GetComponent<ContainerStateManager>();
    }

	// Update is called once per frame
	void Update () 
    {
 
	}

    //衝突した場合箱を削除
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //子オブジェクトから切り離し
            //ContainerState.ContainerOpene();
            gameObject.transform.DetachChildren();
            Destroy(gameObject);
        }
    }

}
