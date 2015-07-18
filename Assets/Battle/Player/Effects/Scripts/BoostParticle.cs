using UnityEngine;
using System.Collections;

public class BoostParticle : MonoBehaviour {

    ParticleSystem particleSystem = null;

    // 追加部分
    private GameObject boostPrefav = null;
    private GameObject hasBoost = null;

	// Use this for initialization
	void Start () {
        particleSystem = GetComponent<ParticleSystem>();
        boostPrefav = (GameObject)Resources.Load("Effects/BoostWeak");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Boost") == 0)
        {
            particleSystem.emissionRate = 0;
            
            // 追加部分
            if (hasBoost != null)
            {
                Destroy(hasBoost);
                hasBoost = null;
            }
        }
        else
        {
            particleSystem.emissionRate = 100;

            // 追加部分
            if (hasBoost == null) 
            {
                hasBoost = EffekseerEmitter.Create(boostPrefav, this.transform.position);
            }
        }

	}
}
