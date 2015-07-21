using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletDataBase : MonoBehaviour {

    static List<BulletPalamaterData> data = new List<BulletPalamaterData>();

	// Use this for initialization
	void Awake () {
        var json = Resources.Load("DataBase/BulletData") as TextAsset;

        if (string.IsNullOrEmpty(json.text))
        {
            Debug.LogError("MachineGun DataBaseが空です");
            return;
        }

        data = LitJson.JsonMapper.ToObject<List<BulletPalamaterData>>(json.text);

        /*
        foreach (var bullet in data)
        {
            Debug.Log("WeaponID : " + bullet.weaponID);
            Debug.Log("タイプ : " + bullet.attackType);
            Debug.Log("速度 : " + bullet.speed);
            Debug.Log("発射レート : " + bullet.fireRate);
            Debug.Log("攻撃 : " + bullet.power);
            Debug.Log("弾数 : " + bullet.bulletNumber);
        }
        */

    }

    public static BulletPalamaterData GetData(BuildManager.WeaponID id)
    {
        var weapon = data.Find(i => i.weaponID == id);

        return weapon;
    }
}
