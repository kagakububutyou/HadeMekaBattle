using UnityEngine;
using System.Collections;

public class BulletPalamaterData : MonoBehaviour {
    public enum TYPE
    {
        PHYSICAL,
        ENERGY,
    };

    /*-------------バレットID------------------*/
    [SerializeField]
    public BuildManager.WeaponID weaponID;

    /*-------------攻撃系パラメータ-------------*/
    [SerializeField]
    public float power = 1.0f;

    //[SerializeField]
    public float energy = -1.0f;

    [SerializeField]
    public float fireRate = 1.0f;

    /*-------------移動系パラメータ-------------*/
    [SerializeField]
    public float speed = 1.0f;


    /*--------------属性パラメータ--------------*/
    [SerializeField]
    public TYPE attackType = TYPE.PHYSICAL;
}
