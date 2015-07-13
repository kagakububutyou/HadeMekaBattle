using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPBarScaler : MonoBehaviour {

    Image image = null;

    HealthManager healthManager = null;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}

    /// <summary>
    /// HealthManagerをアタッチする。
    /// </summary>
    void AttachHealthManager()
    {
        var playerList = GameObject.FindGameObjectsWithTag("Player");
        foreach(var player in playerList)
        {
            if (player.GetComponent<NetworkView>().isMine)
            {
                healthManager = player.GetComponent<HealthManager>();
            }
        }

    }

	// Update is called once per frame
	void Update () 
    {
        if (healthManager == null)
        {
            AttachHealthManager();
        }
        else
        {

            var barLength = GetBarLength();
            image.fillAmount = barLength;
        }

	}

    float GetBarLength()
    {
       return (float)healthManager.Health / (float)healthManager.HealthMax;
    }

}
