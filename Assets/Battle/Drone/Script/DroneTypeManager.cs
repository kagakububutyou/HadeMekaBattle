using UnityEngine;
using System.Collections;

public class DroneTypeManager : MonoBehaviour 
{
    enum type
    {

        Gun,
        Jammer,
        Mine,
        Sensor,
    }

    type dollType;
	// Use this for initialization
	void Start () 
    {
        int _rand= Random.Range(0,4);

        switch(_rand)
        {
            case 0: dollType = type.Gun; break;
            case 1: dollType = type.Jammer; break;
            case 2: dollType = type.Mine; break;
            case 3: dollType = type.Sensor; break;
        }
        Debug.Log("type->" + dollType);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
