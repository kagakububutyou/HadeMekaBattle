using UnityEngine;
using System.Collections;

public class DroneHealthManager : MonoBehaviour
{

    /// <summary>
    /// HPの最大値
    /// </summary>
    [SerializeField]
    int healthMax = 10000;
    public int HealthMax { get { return healthMax; } }

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

    void Start()
    {
        ;
    }

    /// <summary>
    /// HPを加算する
    /// </summary>
    /// <param name="_addValue">加算する量</param>
    public void AddHealth(int _addValue)
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

    /// <summary>
    /// 物理ダメージの計算
    /// </summary>
    /// <param name="_damageValue">自然数のダメージ値</param>
    public void PhysicalDamage(int _damageValue)
    {
        AddHealth(-_damageValue);
    }

}
