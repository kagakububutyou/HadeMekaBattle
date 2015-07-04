using UnityEngine;
using System.Collections;

public class EnergyManager : MonoBehaviour {

    const float energyRatioMin = -1.0f;
    const float energyRatioMax = 1.0f;

    [SerializeField]
    float energyRatio = 0.0f;
    public float EnergyRatio { 
        get
        {
            return energyRatio; 
        }
        set
        {
            energyRatio = value;
            if (energyRatio > energyRatioMax) energyRatio = energyRatioMax;
            if (energyRatio < energyRatioMin) energyRatio = energyRatioMin;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
