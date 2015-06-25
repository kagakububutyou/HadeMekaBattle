/// ------------------------------------------------------
/// SEプレイヤー
///
/// SEの再生機です。
///
/// code by Yamada Masamitsu
/// -----------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SEPlayer : MonoBehaviour {

    public struct Data
    {
        public Data(string resName):this()
        {
            this.resName = resName;
            clip = Resources.Load("SE/" + resName) as AudioClip;
        }
        public string resName;
        public AudioClip clip;
    }

    List<AudioSource> sources = new List<AudioSource>();
    Dictionary<string, Data> audioMap = new Dictionary<string, Data>();
    public const float maxVolume = 0.6f;

    private static SEPlayer instance = null;
    public static SEPlayer Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject instanceObject = new GameObject("SEPlayer");
                instance = instanceObject.AddComponent<SEPlayer>();
            }
            return instance;
        }
    }

    /// <summary>
    /// 再生
    /// </summary>
    /// <param name="resName">Resource名</param>
    public void Play(string resName, float pitch = 1.0f, bool loop = false)
    {
        if (!audioMap.ContainsKey(resName))
        {
            audioMap.Add(resName, new Data(resName));
        }

        sources.Add(gameObject.AddComponent<AudioSource>());
        var index = sources.Count - 1;
        sources[index].clip = audioMap[resName].clip;
        sources[index].pitch = pitch;
        sources[index].loop = loop;
        sources[index].volume = maxVolume;
        sources[index].Play();
    }

    /// <summary>
    /// 音量を変える
    /// </summary>
    /// <param name="resName"></param>
    /// <param name="volume"></param>
    public void ChangeVolume(string resName,float volume)
    {
        foreach (var source in sources)
        {
            if (source.clip.name == resName)
            {
                source.volume = volume;
                break;
            }
        }
    }


    /// <summary>
    /// 停止
    /// </summary>
    /// <param name="resName">Resource名</param>
    public void Stop(string resName, float time = 0.0f)
    {
        StartCoroutine(WaitStop(resName,time));
    }


    /// <summary>
    /// 停止
    /// </summary>
    /// <param name="resName">Resource名</param>
    IEnumerator WaitStop(string resName,float time)
    {
        yield return new WaitForSeconds(time);

        foreach (var source in sources)
        {
            if (source.clip.name == resName)
            {
                source.Stop();
                break;
            }
        }

    }


    /// <summary>
    /// すべて停止
    /// </summary>
    /// <param name="resName">Resource名</param>
    public void AllStop()
    {
        foreach (var source in sources)
        {
            source.Stop();
        }
    }

    void Update()
    {
        foreach (var source in sources)
        {
            if (!source.isPlaying)
            {
                Destroy(source);
                sources.Remove(source);
                break;
            }
        }

    }

    /// <summary>
    /// 再生中かどうか
    /// </summary>
    /// <param name="resName">Resource名</param>
    /// <returns></returns>
    public bool IsPlaying(string resName)
    {
        foreach (var source in sources)
        {
            if (source.isPlaying && source.clip.name == resName)
            {
                return true;
            }
        }

        return false;
    }

}
