using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var scene = SceneManager.Instance;
        var bgm = BGMPlayer.Instance;
        Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
