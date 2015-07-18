using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FpsMeasure : MonoBehaviour {

    int frameCount;
    float nextTime;

    Text text = null;

	// Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        nextTime = Time.time + 1;
	}
	
	// Update is called once per frame
	void Update () 
    {
        frameCount++;

        if (Time.time >= nextTime)
        {
            text.text = "FPS : " + frameCount;
            frameCount = 0;
            nextTime += 1;
        }
	}
}
