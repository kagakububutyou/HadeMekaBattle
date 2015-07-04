using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {
    /// <summary>
    /// HPの最大値
    /// </summary>
    [SerializeField]
    int healthMax = 10000;

    /// <summary>
    /// HPの最小値
    /// </summary>
    [SerializeField]
    int healthMin = 0;

    /// <summary>
    /// いわゆるHP
    /// </summary>
    [SerializeField]
    int health = 10000;
    public int Health { get { return health; } }

    /// <summary>
    /// 死んだかどうか
    /// 死んでいる...true 死んでいない...false
    /// </summary>
    public bool IsDead { get; private set; }

    /// <summary>
    /// HPを加算する
    /// </summary>
    /// <param name="_addValue">加算する量</param>
    void AddHealth(int _addValue)
    {
        health += _addValue;

        CheckHealthValue();
    }

    /// <summary>
    /// 上限下限を超えていないかをチェック
    /// </summary>
    void CheckHealthValue()
    {
        if (health > healthMax) health = healthMax;
        if (health < healthMin)
        {
            health = healthMin;
            IsDead = true;
        }
    }
    
}
