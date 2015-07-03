using UnityEngine;
using System.Collections;

public class PlayerBooster : MonoBehaviour {

    //ブーストの力
    [SerializeField]
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
        if (Input.GetAxisRaw("Boost") != 0 && boostConsumption < boostManager.Quantity )
        {
            Boost();
        }
    }

    void Boost()
    {
        boostManager.AddQuantity(-boostConsumption);
        rigidBody.AddForce(Vector3.up * boostPower, ForceMode.VelocityChange);
    }
}
