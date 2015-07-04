﻿using UnityEngine;
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

    const float boostRatioMin = 1.0f;
    const float boostRatioMax = 2.0f;

    /// <summary>
    /// エネルギー効率
    /// 1.0から2.0fで扱う
    /// </summary>
    [SerializeField,Range(boostRatioMin,boostRatioMax)]
    float boostRatio = boostRatioMin;

    public float BoostRatio {
        get 
        {
            return boostRatio;
        }
        set
        {
            boostRatio = value;
            if (boostRatio > boostRatioMax) boostRatio = boostRatioMax;
            if (BoostRatio < boostRatioMin) boostRatio = boostRatioMin;
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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        AutoRegain();

        Debug.Log(Quantity);
	}

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