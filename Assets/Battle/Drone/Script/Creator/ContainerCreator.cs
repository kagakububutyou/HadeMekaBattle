using UnityEngine;
using System.Collections;


public class ContainerCreator : MonoBehaviour 
{
    /// <summary>
    /// コンテナのプレハブ
    /// </summary>
    [SerializeField]
    GameObject containerPrefab = null;

    bool canCreate = true;

    void Update()
    {
        //デバッグKye
        if (Input.GetKeyDown(KeyCode.P))
        {
            if ( canCreate/*&& TimeManager.IsWaiting*/)
            {
                ContainerDrop();
            }
        }
    }

    void ContainerDrop()
    {
        //var childrenTransform = GetComponentsInChildren<Transform>();

        var childrenTransform = gameObject.GetComponentsInChildrenWithoutSelf<Transform>();
      
        var index = Random.Range(0, gameObject.transform.childCount);

        //Debug.Log("Length" + childrenTransform.Length);
        //Debug.Log("childCount_" + childrenTransform.Length);
        //Debug.Log("index" + index);

        Create(childrenTransform[index]);
    }

    void Create(Transform _positionObjct)
    {
        var clone = Network.Instantiate(containerPrefab,_positionObjct.position, Quaternion.identity, 0);
    }

}

