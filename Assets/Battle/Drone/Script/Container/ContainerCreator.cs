using UnityEngine;
using System.Collections;

public class ContainerCreator : MonoBehaviour 
{


    /// <summary>
    /// コンテナのプレハブ
    /// </summary>
    [SerializeField]
    GameObject containerPrefab = null;
    GameObject containerClone = null;

    NetworkView netWork = null;

	// Use this for initialization
	void Start () 
    {
        netWork = GetComponent<NetworkView>();
    }

    void Create()
    {
        containerClone = (GameObject)Network.Instantiate(containerPrefab, gameObject.transform.position, Quaternion.identity, 0);
        containerClone.transform.parent = gameObject.transform;
    }

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Create();
        }
	
	}
}
