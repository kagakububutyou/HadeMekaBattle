using UnityEngine;
using System.Collections;

public class ContainerCreator : MonoBehaviour 
{
    /// <summary>
    /// コンテナのプレハブ
    /// </summary>
    [SerializeField]
    GameObject containerPrefab = null;

    NetworkView netWork = null;


    [SerializeField]
    int myId = 0;

    bool canCreate = true;

    Vector3 containerPosition = Vector3.zero;
    GameObject containerClone = null;
	// Use this for initialization
	void Start () 
    {
        netWork = GetComponent<NetworkView>();
    }


    /// <summary>
    /// CreatorSelectorで作られたランダム値と比較します。
    /// </summary>
    /// <param name="_random"></param>
    public bool CanCreateContainer(int _random)
    {
        //canCreate = false の時は生成されません
        if (_random == myId && canCreate)
        {
           return true;
        }

        else return false;
    }

    //コンテナが消えたか
    public bool IsContainerDestroy()
    {
        //コンテナが再度生成できず、さらに子オブジェクト(コンテナ)が存在していない場合 
        if (!canCreate && gameObject.transform.childCount == 0)
        {
            return true; 
        }
        else return false;
    }

    public void Create()
    {
        containerClone = (GameObject)Network.Instantiate(containerPrefab, gameObject.transform.position, Quaternion.identity, 0);
        containerClone.transform.parent = gameObject.transform;

        //再度生成されるのを防ぎます
        canCreate = false;
    }


    void Update()
    {
        //if (!canCreate) containerPosition = containerClone.transform.position;
    }

}
