using UnityEngine;
using System.Collections;

public class PlayerJumper : MonoBehaviour {

    [SerializeField]
    float jumpPower = 1.0f;

    Rigidbody rigidBody = null;


    bool canJump = false;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();	
	}

	void FixedUpdate()
    {
        if (!canJump) return;
        if(Input.GetAxisRaw("Jump") != 0 )
        {
            Jump();
        }
    }

    void Jump()
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0, rigidBody.velocity.z);
        rigidBody.AddForce(0, jumpPower, 0, ForceMode.VelocityChange);
        canJump = false;
    }

    void OnTriggerEnter(Collider collObj)
    {
        canJump = true;
    }

}
