using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 3.0f;

    Rigidbody rigidBody = null;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	

    void FixedUpdate()
    {
        Move();
    }

    
    void Move()
    {
        //入力の取得
        var HorizontalValue = Input.GetAxis("Horizontal");
        var VerticalValue = Input.GetAxis("Vertical");

        if(HorizontalValue == 0 && VerticalValue == 0) return;


        //transform.localPosition = new Vector3(transform.localPosition.x + HorizontalValue * moveSpeed * Time.deltaTime,
        //                                      transform.localPosition.y,
        //                                      transform.localPosition.z + VerticalValue * moveSpeed * Time.deltaTime);

        rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
        rigidBody.AddForce(VerticalValue * moveSpeed * transform.forward, ForceMode.VelocityChange);
        rigidBody.AddForce(HorizontalValue * moveSpeed * transform.right, ForceMode.VelocityChange);
    }

}
