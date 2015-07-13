using UnityEngine;
using System.Collections;

public class ColorCahange : MonoBehaviour
{
    [SerializeField]
    DroneStateManager drone = null;

    [SerializeField]
    Material material = null;

	// Use this for initialization
	void Start ()
    {
        if (drone.IsNone) { material.color = new Color(1, 255, 1); };
	}
	
	// Update is called once per frame
	void Update () 
    {
        CahangeColor();
	
	}

    void CahangeColor()
    {
        if (drone.IsMaine) { material.color = new Color(1, 1, 255); };
        if (drone.IsNone) { material.color = new Color(1, 255, 1); };
        if (drone.IsYour) { material.color = new Color(255, 1, 1); };
    }
}
