using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

    /// <summary>
    /// 追う対象のtransform
    /// </summary>
    [SerializeField]
    Transform targetTransform = null;

    /// <summary>
    /// 追尾速度の倍率
    /// </summary>
    [SerializeField]
    float moveSpeed = 1.0f;

    [SerializeField]
    float distanceFromTarget = -4;

    [SerializeField]
    float addHeight = 0.0f;

    Vector3 followingPosition = Vector3.zero;

    Rigidbody rigidBody = null;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //カメラの移動先の算出
        followingPosition = targetTransform.position + distanceFromTarget * targetTransform.forward;
        followingPosition.y += addHeight;

        rigidBody.velocity = Vector3.zero;
        rigidBody.AddForce(moveSpeed * (followingPosition - transform.position), ForceMode.VelocityChange);
//        transform.position += moveDivideValue * (followingPosition - transform.position);
    }
}
