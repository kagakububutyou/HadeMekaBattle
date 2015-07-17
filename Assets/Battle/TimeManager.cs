using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    /// <summary>
    /// 経過時間を観測する(単位:秒)
    /// </summary>
    float nowTimeSecond = 0;
    public float NowTimeSecond { get { return nowTimeSecond; } }

    void Start()
    {
        nowTimeSecond = 0;
    }

    void Update()
    {
        AddTime();
    }

    /// <summary>
    /// 時間を加算する(単位:秒)
    /// </summary>
    void AddTime()
    {
        nowTimeSecond += Time.deltaTime;
    }


}
