using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DroneCreator : MonoBehaviour 
{

    [SerializeField]
    List<GameObject> DroneType = new List<GameObject>();
    

    bool canCreate = true;
    public bool CanCreateDrone { get { return canCreate; } }


    public void Create()
    {
        if (canCreate)
        {
            var index = Random.Range(0, DroneType.Count);
            //Debug.Log("TypeCount" + DroneType.Count);

            var clone = Network.Instantiate(DroneType[index], gameObject.transform.position, Quaternion.identity, 0);

            canCreate = false;
        }
    }

}
