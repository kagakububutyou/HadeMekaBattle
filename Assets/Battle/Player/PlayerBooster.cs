using UnityEngine;
using System.Collections;

public class PlayerBooster : MonoBehaviour {

    //ブーストの力
    [SerializeField]
    float boostPower = 1.0f;

    Rigidbody rigidBody = null;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	
	}
	

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Boost") != 0)
        {
            Boost();
        }
    }

    void Boost()
    {
        rigidBody.AddForce(Vector3.up * boostPower, ForceMode.VelocityChange);

    }
}
