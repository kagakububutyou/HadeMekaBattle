using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 3.0f;

    /// <summary>
    /// 1フレームあたりに減算されるブーストの運動量
    /// </summary>
    [SerializeField]
    float decreaseBoostPerSecond = 0.1f;

    /// <summary>
    /// ブースト開始時のブーストの運動量
    /// </summary>
    [SerializeField]
    float defaultBoostPower = 1.0f;


    /// <summary>
    /// ブーストによって加算される移動量
    /// </summary>
    float boostPower = 0.0f;


    Rigidbody rigidBody = null;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	

    void FixedUpdate()
    {
        GetInput();
        Move();
        BoostMove();
    }

    /// <summary>
    /// 入力されている値を保存する変数
    /// </summary>
    float horizontalInput = 0.0f;
    float verticalInput = 0.0f;
    float boostInput = 0.0f;

    /// <summary>
    /// 入力の取得をする
    /// </summary>
    void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        boostInput = Input.GetAxisRaw("Boost");
    }

    void Move()
    {

        rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
        rigidBody.AddForce(verticalInput * moveSpeed * transform.forward, ForceMode.VelocityChange);
        rigidBody.AddForce(horizontalInput * moveSpeed * transform.right, ForceMode.VelocityChange);

    }

    void BoostMove()
    {

        if (boostInput == 0)
        {
            boostPower = defaultBoostPower;
            return;
        }
        else
        {
            boostPower -= decreaseBoostPerSecond;
            if (boostPower < 0) boostPower = 0;
        }

        rigidBody.AddForce(verticalInput * moveSpeed * transform.forward * boostPower, ForceMode.VelocityChange);
        rigidBody.AddForce(horizontalInput * moveSpeed * transform.right * boostPower, ForceMode.VelocityChange);
    }

}
