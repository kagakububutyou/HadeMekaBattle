using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 3.0f;

    /// <summary>
    /// ブーストによって加算される移動量
    /// </summary>
    float boostPower = 1.0f;

    /// <summary>
    /// ブースト使用時の消費量
    /// </summary>
    [SerializeField]
    float boostConsumption = 0.03f;


    Rigidbody rigidBody = null;

    BoostManager boostManager = null;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        boostManager = GetComponent<BoostManager>();
	}
	

    void FixedUpdate()
    {
        GetInput();
        Move();

        if (boostInput != 0 && boostManager.CanUseBoost(boostConsumption))
        {
            BoostMove();
        }

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

        boostManager.AddQuantity(-boostConsumption);
        rigidBody.AddForce(verticalInput * moveSpeed * transform.forward * boostPower * boostManager.BoostRatio, ForceMode.VelocityChange);
        rigidBody.AddForce(horizontalInput * moveSpeed * transform.right * boostPower * boostManager.BoostRatio, ForceMode.VelocityChange);

 
    }

}
