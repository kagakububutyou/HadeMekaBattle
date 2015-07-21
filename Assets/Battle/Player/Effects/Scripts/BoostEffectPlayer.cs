using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoostEffectPlayer : MonoBehaviour {

    [SerializeField]
    List<ParticleSystem> particleSystem = new List<ParticleSystem>();


    void PlayParticle(int emissionRate)
    {
    }

    /// <summary>
    /// 再生する
    /// </summary>
    public void Play(bool canLoop)
    {
        foreach (var boost in particleSystem)
        {
            boost.loop = canLoop;
            boost.Play(true);
        }
    }

    /// <summary>
    /// 停止する
    /// </summary>
    public void Stop()
    {
        foreach (var boost in particleSystem)
        {
            boost.time = 0;
            boost.Stop(true);
        }
    }

}
