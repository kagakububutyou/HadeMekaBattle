using UnityEngine;
using System.Collections;

public class ExplosivePerformer : MonoBehaviour 
{

    [SerializeField]
    DroneStateManager drone = null;

    //タイマー
    float nowTime = 0.0f;

    //爆破までの時間
    [SerializeField]
    float waitingTime =0.0f;

	// Use this for initialization
	void Start () 
    {
        ;
	}

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
        drone.ChangeStop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !drone.WhoIsOwner())
        {
            drone.ChangeActive();
        }
    }

}
