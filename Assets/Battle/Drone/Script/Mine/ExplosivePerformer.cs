using UnityEngine;
using System.Collections;

public class ExplosivePerformer : MonoBehaviour 
{

    [SerializeField]
    DroneStateManager drone = null;
    HealthManager player = null;
    //タイマー
    float nowTime = 0.0f;

    //爆破までの時間
    [SerializeField]
    float waitingTime =0.0f;

    void Timer()
    {
        nowTime += Time.deltaTime;
    }

    bool IsTimeOut()
    {
        if (nowTime > waitingTime)
        {
            nowTime = 0;
            return true;
        }
        else return false;
    }

	// Update is called once per frame
	void Update () 
    {
        //起動したら
	    if(drone.IsActive)
        {
            //Debug.Log("Count:" + (int)(waitingTime - nowTime));
            Timer();

            //爆発処理
            if (IsTimeOut())
            {

                Explosion();
            }
        }
	}

    void Explosion()
    {
        //ダメージを与える
        player.PhysicalDamage(drone.HitDamage);

        //droneの活動を停止
        drone.ChangeStop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !drone.WhoIsOwner())
        {
            drone.ChangeActive();
            player = other.GetComponent<HealthManager>();
        }
    }

}
