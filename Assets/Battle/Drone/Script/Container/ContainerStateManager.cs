using UnityEngine;
using System.Collections;

public class ContainerStateManager : MonoBehaviour 
{
    enum NowState
    {
        Stay,
        Active,
        Destroy,
    }
    DroneCreator droneCreator = null;

    bool isOpened = false;

    public bool IsOpened { get { return isOpened; } }

    public void ContainerOpene()
    {
        droneCreator = GetComponent<DroneCreator>();
        droneCreator.Create();
        isOpened = true ;
    }

	// Update is called once per frame
	void Update () 
    {
        ;
	}
}
