using UnityEngine;
using System.Collections;

public class DroneTypeManager : MonoBehaviour 
{
    enum Type
    {

        Gun,
        Jammer,
        Mine,
        Sensor,
    }

    Type dollType = Type.Gun;

	// Use this for initialization
	void Start () 
    {
        int _rand= Random.Range(0,4);

        switch(_rand)
        {
            case 0: dollType = Type.Gun; break;
            case 1: dollType = Type.Jammer; break;
            case 2: dollType = Type.Mine; break;
            case 3: dollType = Type.Sensor; break;
        }
        Debug.Log("type->" + dollType);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
