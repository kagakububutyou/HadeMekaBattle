using UnityEngine;
using System.Collections;

public class PlayerHider : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (!TimeManager.IsWaiting)
        {
            Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Player"));
            Destroy(this);
        }
	}
}
