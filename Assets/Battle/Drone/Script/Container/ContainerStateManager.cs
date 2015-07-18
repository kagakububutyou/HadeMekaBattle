using UnityEngine;
using System.Collections;

public class ContainerStateManager : MonoBehaviour 
{

    bool isOpened = false;

    public bool IsOpened { get { return isOpened; } }

    public void ContainerOpene()
    {
        isOpened = true ;
    }

	// Update is called once per frame
	void Update () 
    {
        ;
	}
}
