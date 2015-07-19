using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class RrtMeasure : MonoBehaviour {

    int frameCount;
    float nextTime;

    Text text = null;
    NetworkView networkView = null;

    // Use this for initialization
    void Start()
    {
        networkView = new NetworkView();
        text = GetComponent<Text>();
        nextTime = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        networkView.RPC("Measure", RPCMode.All);
        text.text = "RTT : " + frameCount;
    
    }


    [RPC]
    void Measure()
    {
        frameCount++;

        if (Time.time >= nextTime)
        {
            text.text = "RTT : " + frameCount;
            frameCount = 0;
            nextTime += 1;
        }
    }
}
