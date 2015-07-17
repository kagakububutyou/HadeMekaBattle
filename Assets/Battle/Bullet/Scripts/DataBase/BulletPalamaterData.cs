using UnityEngine;
using System.Collections;

// 生成されても固定のパラメータ
public class BulletPalamaterData : MonoBehaviour {
    public enum TYPE
    {
        PHYSICAL,
        ENERGY,
    };

    /*-------------バレットID------------------*/
    public BuildManager.WeaponID weaponID;

    /*-------------攻撃系パラメータ-------------*/
    public float power = 1.0f;
    public float fireRate = 1.0f;

    /*-------------移動系パラメータ-------------*/
    public float speed = 1.0f;

    /*--------------属性パラメータ--------------*/
    public TYPE attackType = TYPE.PHYSICAL;
}
