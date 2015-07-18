using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DronTypeSelector : MonoBehaviour 
{
    [SerializeField]
    DroneCreator droneCreator = null;

    [SerializeField]
    ContainerCreator containerCreator = null;

    Vector3 container = Vector3.zero;
    int droneTypeMax = 4;


    // Use this for initialization
	void Start () 
    {
        droneCreator = GetComponent<DroneCreator>();
        containerCreator = GetComponent<ContainerCreator>();
	}
	
    int GetDroneType()
    {
        return  Random.Range(0, droneTypeMax);
    }

	// Update is called once per frame
	void Update () 
    {
        if (containerCreator.IsContainerDestroy() && droneCreator.CanCreateDrone)
        {
            droneCreator.CreateDrone(GetDroneType(), container);
        }
	
	}
}
