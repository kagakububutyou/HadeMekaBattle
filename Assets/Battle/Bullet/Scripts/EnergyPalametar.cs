using UnityEngine;
using System.Collections;

public class EnergyPalametar : MonoBehaviour {
    // 生成された際に取得する必要のあるパラメータ
    private float energy = -2.0f;
    public float Energy { get { return energy; } set { if (energy == -2.0f)energy = value; } }
}
