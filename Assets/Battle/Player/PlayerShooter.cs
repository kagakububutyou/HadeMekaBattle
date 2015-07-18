using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerShooter : MonoBehaviour {


    BulletShooter[] bulletShooter = new BulletShooter[2];

    void Start()
    {
        bulletShooter = GetComponents<BulletShooter>();
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Fire1") != 0)
        {
            bulletShooter[0].CreateBullet();
        }

        if(Input.GetAxis("Fire2") != 0)
        {
            bulletShooter[1].CreateBullet();
        }
	}

}
