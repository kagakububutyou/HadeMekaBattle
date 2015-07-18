using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    /// <summary>
    /// 経過時間を観測する(単位:秒)
    /// </summary>
    static float nowTimeSecond = 0.0f;
    public static float NowTimeSecond
    {
        get
        {
            if (IsWaiting) return 0.0f;

            return nowTimeSecond;
        }

        private set
        {
            nowTimeSecond = value;
        }
    }

    public static float WaitTime { get; private set; }

    public static float WaitingTime { get; private set; }

    /// <summary>
    /// 待機状態化どうか
    /// </summary>
    public static bool IsWaiting { get; private set; }    

    void Awake()
    {
        ///待機時間の初期値
        ///↓ここを書き換える事。
        WaitTime = 5.0f;

        WaitingTime = 0.0f;
    }

    void Start()
    {
        IsWaiting = true;

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
        if(IsWaiting)
        {
            WaitingTime += Time.deltaTime;
        }
        else
        {
            NowTimeSecond += Time.deltaTime;
        }

        if (WaitingTime > WaitTime)
        {
            IsWaiting = false;
            NowTimeSecond = WaitingTime - WaitTime;
        }
    }

}
