using UnityEngine;
using System.Collections;

public class PlayerHider : MonoBehaviour {

    [SerializeField]
    GameObject player = null;

	// Update is called once per frame
	void Update () {
        if (!TimeManager.IsWaiting )
        {
            if (player.tag == "Player")
            {
                Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Player"));
            }

            Destroy(this);
        }
	}
}
