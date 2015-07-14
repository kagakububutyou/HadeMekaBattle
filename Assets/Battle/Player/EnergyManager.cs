using UnityEngine;
using System.Collections;

public class EnergyManager : MonoBehaviour {

    public const float EnergyRatioMin = -1.0f;
    public const float EnergyRatioMax = 1.0f;

    [SerializeField, Range(EnergyRatioMin, EnergyRatioMax)]
    float energyRatio = 0.0f;
    public float EnergyRatio { 
        get
        {
            return energyRatio; 
        }
        set
        {
            energyRatio = value;
            if (energyRatio > EnergyRatioMax) energyRatio = EnergyRatioMax;
            if (energyRatio < EnergyRatioMin) energyRatio = EnergyRatioMin;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
