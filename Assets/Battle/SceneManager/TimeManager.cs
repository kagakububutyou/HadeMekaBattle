using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    /// <summary>
    /// 経過時間を観測する(単位:秒)
    /// </summary>
    public static float NowTimeSecond { get; private set; }

    void Start()
    {
        NowTimeSecond = 0;
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
        NowTimeSecond += Time.deltaTime;
    }


}
