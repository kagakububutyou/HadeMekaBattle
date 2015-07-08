using UnityEngine;
using System.Collections;

public class PlayerQuickBooster : MonoBehaviour {

    /// <summary>
    /// ブースト使用時の消費量
    /// </summary>
    [SerializeField]
    float boostConsumption = 20.0f;

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


    /// <summary>
    /// ちょうど押されたフレームかどうかを調べる用のカウント変数
    /// </summary>
    int pushingTime = 0;

    Rigidbody rigidBody = null;

    BoostManager boostManager = null;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        boostManager = GetComponent<BoostManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        GetInput();

        if (pushingTime == 1 && boostManager.CanUseBoost(boostConsumption))
        {
            isBoost = true;
            velocity = quickBoostInput;
            boostPower = defaultBoostPower;

            rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);

            boostManager.AddQuantity(-boostConsumption);
                        
        }
        
        if (isBoost)
        {
            QuickBoost();
        }
	}
    void GetInput()
    {

        quickBoostInput = Input.GetAxisRaw("QuickBoost");

        if(quickBoostInput != 0)
        {
            ++pushingTime;
        }
        else
        {
            pushingTime = 0;
        }
    }

    void QuickBoost()
    {
        boostPower -= decreaseBoostPerFrame;
        if (boostPower < 0)
        {
            boostPower = 0;
            isBoost = false;
        }
        rigidBody.AddForce(transform.right * boostPower * velocity * boostManager.BoostRatio, ForceMode.VelocityChange);

    }
}
