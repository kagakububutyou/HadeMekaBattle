using UnityEngine;
using System.Collections;

public class ContainerCreator : MonoBehaviour 
{


    [SerializeField]
    GameObject containerPrefab = null;
    GameObject containerClone = null;

    NetworkView netWork = null;

	// Use this for initialization
	void Start () 
    {
        netWork = GetComponent<NetworkView>();
        //コンテナ生成しを親にする
        containerClone = (GameObject) Network.Instantiate(containerPrefab, gameObject.transform.position, Quaternion.identity, 1);
        gameObject.transform.parent = containerClone.transform;
    

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
