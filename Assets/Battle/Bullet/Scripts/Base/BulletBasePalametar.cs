﻿using UnityEngine;
using System.Collections;

public class BulletBasePalametar : MonoBehaviour {

    public enum TYPE
    {
        PHYSICAL,
        ENERGY,
    };

    /*-------------攻撃系パラメータ-------------*/
	[SerializeField]
	protected float power = 1.0f;

	//[SerializeField]
	protected float energy = -1.0f;

	[SerializeField]
	private float fireRate = 1.0f;

    /*-------------移動系パラメータ-------------*/
    [SerializeField]
	protected float speed = 1.0f;


    /*--------------属性パラメータ--------------*/
    [SerializeField]
    private TYPE attackType = TYPE.PHYSICAL;

    /*------------------------------------------*/


	// プロパティ
    public float Power { get { return power; } }
	public float Speed{get{return speed;}}
    public float Energy { get { return energy; } set { if(energy == -1.0f)energy = value; } }
    public float Firerate { get { return fireRate; } }
    public TYPE AttackType { get { return attackType; } }
}
