using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoostBarScaler : MonoBehaviour {

    Image image = null;

    BoostManager boostManager = null;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}

    /// <summary>
    /// HealthManagerをアタッチする。
    /// </summary>
    void AttachBoostManager()
    {
        var playerList = GameObject.FindGameObjectsWithTag("Player");
        foreach(var player in playerList)
        {
            if (player.GetComponent<NetworkView>().isMine)
            {
                boostManager = player.GetComponent<BoostManager>();
            }
        }

    }

	// Update is called once per frame
	void Update () 
    {
        if (boostManager == null)
        {
            AttachBoostManager();
        }
        else
        {

            var barLength = GetBarLength();
            image.fillAmount = barLength;

            if (BoostManager.IsShowingError)
            {
                image.color = Color.red;
            }
            else
            {
                image.color = Color.white;
            }
        }


	}

    float GetBarLength()
    {
        return boostManager.Quantity / boostManager.QuantityMax;
    }

}
