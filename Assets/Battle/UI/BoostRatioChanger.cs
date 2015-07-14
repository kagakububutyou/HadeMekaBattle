using UnityEngine;
using System.Collections;

public class BoostRatioChanger : MonoBehaviour {

    BoostManager boostManager = null;

    RectTransform parentRect = null;

    RectTransform myRect = null;

    void Initialize()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        boostManager = player.GetComponent<BoostManager>();

        parentRect = transform.parent.GetComponent<RectTransform>();

        myRect = GetComponent<RectTransform>();

    }
	
	// Update is called once per frame
	void Update () {

        if (boostManager == null)
        {
            Initialize();
        }
        else
        {
            boostManager.BoostRatio = BoostManager.BoostRatioMin + (myRect.localPosition.x + (parentRect.sizeDelta.x / 2)) / parentRect.sizeDelta.x;
        }
	}
}
