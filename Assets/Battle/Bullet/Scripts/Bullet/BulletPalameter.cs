using UnityEngine;
using System.Collections;

// 弾丸のパラメータ
public class BulletPalameter : BulletBasePalametar {
    void Start()
    {
        this.gameObject.GetComponent<HitChecker>().Palametar = this;
    }
}
