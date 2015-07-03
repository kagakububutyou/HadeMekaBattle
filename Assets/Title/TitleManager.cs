using UnityEngine;
using System.Collections;

public class TitleManager : IScene {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        // 仮
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.Instance.StartChange(SceneNameManager.Scene.CharacterSelect,fadeTime);
        }
	}
}
