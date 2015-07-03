using UnityEngine;
using System.Collections;

public class BoostParticle : MonoBehaviour {

    ParticleSystem particleSystem = null;

	// Use this for initialization
	void Start () {
        particleSystem = GetComponent<ParticleSystem>();	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Boost") == 0)
        {
            particleSystem.emissionRate = 0;
        }
        else
        {
            particleSystem.emissionRate = 100;
        }

	}
}
