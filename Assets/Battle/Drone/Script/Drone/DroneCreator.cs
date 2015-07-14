using UnityEngine;
using System.Collections;


public class DroneCreator : MonoBehaviour 
{

    [SerializeField]
    GameObject Type_Gun = null;
    //[SerializeField]
    //GameObject Type_Jammer = null;
    [SerializeField]
    GameObject Type_Mine = null;

    //[SerializeField]
    //GameObject Type_Sensor = null;

    GameObject Clone = null;
    int dollTypeMax = 4;

    NetworkView netWork = null;

	// Use this for initialization
	void Start () 
    {
        netWork = GetComponent<NetworkView>();
        //_randはdebug用
        int _rand = Random.Range(0, dollTypeMax);
        DroneCreate(_rand);
        //Debug.Log("type->" + _rand);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void DroneCreate(int _rand)
    {
        Network.Instantiate(Type_Mine, gameObject.transform.position, gameObject.transform.rotation, 0);
        //Clone = Instantiate(Type_Mine);
        //Clone.transform.position = gameObject.transform.position;
        //Drone.transform.parent = gameObject.transform;
        //switch (_rand)
        //{
        //    case 0:
        //        Instantiate(Type_Gun);
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
