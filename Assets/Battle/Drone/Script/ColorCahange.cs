using UnityEngine;
using System.Collections;

public class ColorCahange : MonoBehaviour
{
    [SerializeField]
    DroneStateManager drone = null;

    [SerializeField]
    Material _material;

	// Use this for initialization
	void Start ()
    {
        if (drone.IsNone) { _material.color = new Color(1, 255, 1); };
	}
	
	// Update is called once per frame
	void Update () 
    {
        CahangeColor();
	
	}

    void CahangeColor()
    {
        if (drone.IsMaine) { _material.color = new Color(1, 1, 255); };
        if (drone.IsNone) { _material.color = new Color(1, 255, 1); };
        if (drone.IsYour) { _material.color = new Color(255, 1, 1); };
    }
}
