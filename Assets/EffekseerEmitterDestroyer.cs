using UnityEngine;
using System.Collections;

public class EffekseerEmitterDestroyer : MonoBehaviour {

    EffekseerEmitter effect = null;

	// Use this for initialization
	void Start () {
        effect = GetComponent<EffekseerEmitter>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!effect.IsPlaying)
        {
            Destroy(gameObject);
        }
	}
}
