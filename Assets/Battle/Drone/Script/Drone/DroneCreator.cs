using UnityEngine;
using System.Collections;


public class DroneCreator : MonoBehaviour 
{

    [SerializeField]
    GameObject DroneCore = null;

    [SerializeField]
    GameObject Type_Gun = null;

    [SerializeField]
    GameObject Type_Mine = null;

    //[SerializeField]
    //GameObject Type_Jammer = null;

    //[SerializeField]
    //GameObject Type_Sensor = null;

    GameObject droneClone = null;

    int droneTypeMax = 4;

    NetworkView netWork = null;

    [SerializeField]
    ContainerStateManager ContainerState = null;

	// Use this for initialization
	void Start () 
    {
        netWork = GetComponent<NetworkView>();
        //Create(_rand);
        //Debug.Log("type->" + _rand);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (ContainerState.IsOpened)
       {
           Create(Random.Range(0, droneTypeMax));
       }
       
	}

    void Create(int _rand)
    {
        droneClone = (GameObject)Network.Instantiate(DroneCore, gameObject.transform.position, gameObject.transform.rotation, 0);
        droneClone.transform.parent = gameObject.transform;
        //switch (_rand)
        //{
        //    case 0:
        //        droneClone = (GameObject)Network.InstantiateInstantiate(Type_Gun,gameObject.transform.position, gameObject.transform.rotation, 0);
        //        break;
        //    case 1:
        //        Instantiate(Type_Gun);
        //        break;
        //    case 2:
        //        Instantiate(Type_Mine);
        //        break;
        //    case 3:
        //        Instantiate(Type_Gun);
        //        break;
        //}
    }
}
