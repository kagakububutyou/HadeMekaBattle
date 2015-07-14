using UnityEngine;
using System.Collections;

public class EnergyRatioChanger : MonoBehaviour
{

    EnergyManager energyManager = null;

    RectTransform parentRect = null;

    RectTransform myRect = null;

    void Initialize()
    {
        var player =  GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        energyManager = player.GetComponent<EnergyManager>();

        parentRect = transform.parent.GetComponent<RectTransform>();

        myRect = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {

        if (energyManager == null)
        {
            Initialize();
        }
        else
        {
            energyManager.EnergyRatio = myRect.localPosition.x  / parentRect.sizeDelta.x * 2;
        }
    }
}
