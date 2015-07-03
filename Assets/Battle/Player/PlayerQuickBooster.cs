using UnityEngine;
using System.Collections;

public class PlayerQuickBooster : MonoBehaviour {

    /// <summary>
    /// 1フレームあたりに減算されるブーストの運動量
    /// </summary>
    [SerializeField]
    float decreaseBoostPerFrame = 0.1f;

    /// <summary>
    /// ブースト開始時のブーストの運動量
    /// </summary>
    [SerializeField]
    float defaultBoostPower = 1.0f;

    /// <summary>
    /// ブーストの力
    /// </summary>
    float boostPower = 1.0f;

    /// <summary>
    /// ブースト中かどうか
    /// true...ブースト中である false...ブースト中ではない
    /// </summary>
    bool isBoost = false;

    float quickBoostInput = 0.0f;

    /// <summary>
    /// 右にクイックブーストするか、左にクイックブーストするか
    /// 1.0f...右　-1.0f...左
    /// </summary>
    float velocity = 1.0f;


    Rigidbody rigidBody = null;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        GetInput();

        if (!isBoost && quickBoostInput != 0)
        {
            isBoost = true;
            velocity = quickBoostInput;
            boostPower = defaultBoostPower;
        }
        
        if (isBoost)
        {
            QuickBoost();
        }
	}
    void GetInput()
    {
        quickBoostInput = Input.GetAxisRaw("QuickBoost");
    }

    void QuickBoost()
    {
        boostPower -= decreaseBoostPerFrame;
        if (boostPower < 0)
        {
            boostPower = 0;
            isBoost = false;
        }

        rigidBody.AddForce(transform.right * boostPower * velocity, ForceMode.VelocityChange);

    }
}
