using UnityEngine;
using System.Collections;

public class BoostManager : MonoBehaviour {

    /// <summary>
    /// ブースト残量の最小値
    /// </summary>
    const float quantityMin = 0.0f;

    /// <summary>
    /// ブースト残量の最大値
    /// </summary>
    const float quantityMax = 100.0f;
    public float QuantityMax { get { return quantityMax; } }

    public const float BoostRatioMin = 1.0f;
    public const float BoostRatioMax = 2.0f;

    /// <summary>
    /// エネルギー効率
    /// 1.0から2.0fで扱う
    /// </summary>
    [SerializeField,Range(BoostRatioMin,BoostRatioMax)]
    float boostRatio = BoostRatioMin;

    public float BoostRatio {
        get 
        {
            return boostRatio;
        }
        set
        {
            boostRatio = value;
            if (boostRatio > BoostRatioMax) boostRatio = BoostRatioMax;
            if (BoostRatio < BoostRatioMin) boostRatio = BoostRatioMin;
        }
    }

    /// <summary>
    /// ブーストできる残り量
    /// </summary>
    float quantity = quantityMax;
    public float Quantity { get { return quantity; }}

    /// <summary>
    /// 1秒に自動回復する量
    /// </summary>
    [SerializeField,Range(quantityMin,quantityMax)]
    float autoRegainPerSecond = 5.0f;

	// Update is called once per frame
	void Update () {

        AutoRegain();

	}

    /// <summary>
    /// 自然に回復する処理
    /// </summary>
    void AutoRegain()
    {
        quantity += autoRegainPerSecond * Time.deltaTime;

        if (quantity > quantityMax) quantity = quantityMax;
        if (quantity < quantityMin) quantity = quantityMin;

    }

    /// <summary>
    /// ブースト残量を加算する
    /// </summary>
    /// <param name="_addValue">加算する量(float)</param>
    /// <returns>加算後のブースト残量</returns>
    public float AddQuantity(float _addValue )
    {
        quantity += _addValue * boostRatio;

        if (quantity > quantityMax) quantity = quantityMax;
        if (quantity < quantityMin) quantity = quantityMin;


        return quantity;
    }

    public bool CanUseBoost(float _consumption)
    {
        if (_consumption * boostRatio > quantity) return false;

        return true;
    }
}
