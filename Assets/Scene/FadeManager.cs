using UnityEngine;
using System.Collections;

public class FadeManager : MonoBehaviour {

    Texture2D texture = null;
    float alpha = 0;
    float fadeTime = 0;
    public bool IsFading { get; private set; }
    public bool IsFadeInFinish { get { return (!IsFading && state == State.FadeOut); } }

    FadeTimeData fadeTimeData = new FadeTimeData(0, 0);

    enum State
    { 
        Stop,
        FadeIn,
        FadeOut,
    }

    State state = State.Stop;

    void Awake()
    {
        texture = new Texture2D(32, 32, TextureFormat.RGB24, false);
        texture.SetPixel(0, 0, Color.white);
        texture.Apply();
    }

    void OnGUI()
    {
        GUI.color = new Color(0, 0, 0, alpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);

    }

    void Update()
    {
        if (IsFading) return;

        if (state == State.FadeOut)
        {
            StartFadeOut();
        }
    }

    /// <summary>
    /// フェード開始
    /// </summary>
    /// <param name="time"></param>
    public void StartFade(FadeTimeData fadeTimeData)
    {
        if (state != State.Stop) return;

        IsFading = true;
        state = State.FadeIn;
        this.fadeTimeData = fadeTimeData;
        fadeTime = fadeTimeData.inTime;
        iTween.ValueTo(gameObject, iTween.Hash("from", 0, "to", 1, "time", fadeTime, "onupdate", "FadeInUpdateHandler"));
    }

    /// <summary>
    /// フェードアウト開始
    /// </summary>
    /// <param name="time"></param>
    void StartFadeOut()
    {
        IsFading = true;
        fadeTime = fadeTimeData.outTime;
        iTween.ValueTo(gameObject, iTween.Hash("from", 1, "to", 0, "time", fadeTime, "onupdate", "FadeOutUpdateHandler"));
    }

    /// <summary>
    /// 時間によって状態を切り替える
    /// </summary>
    /// <param name="nextState"></param>
    void ChangeTimeState(State nextState)
    {
        fadeTime -= Time.deltaTime;
        if (fadeTime <= 0)
        {
            state = nextState;
            IsFading = false;

        }
    }


    void FadeInUpdateHandler(float value)
    {
        alpha = value;
        ChangeTimeState(State.FadeOut);
    }

    void FadeOutUpdateHandler(float value)
    {
        alpha = value;
        ChangeTimeState(State.Stop);
    }
}
