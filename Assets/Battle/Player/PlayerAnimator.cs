using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAnimator : MonoBehaviour {
    
    public enum AnimationType
    {
        Idling = 0,
        Jamping,
        Moving,
        Shooting
    };

    [System.Serializable]
    public struct AnimationData
    { 
        public AnimationData(AnimationClip clip,AnimationType type):this()
        {
            this.clip = clip;
            this.type = type;
        }

        public AnimationClip clip;
        public AnimationType type;
    }

    [SerializeField]
    Animation animation = null;

    [SerializeField]
    List<AnimationData> animationData = new List<AnimationData>();


    /// <summary>
    /// アニメーションを再生
    /// Listで設定したアニメーションデータを引数で設定する
    /// </summary>
    /// <param name="animationType">アニメーションのタイプ</param>
    public void StartAnimation(AnimationType animationType)
    {
        var clip = animationData.Find(i => i.type == animationType).clip;
        animation.PlayQueued(clip.name);
    }

    /// <summary>
    /// 再生停止
    /// </summary>
    public void Stop()
    {
        animation.Stop();
    }

    /// <summary>
    /// 再生中かどうか？
    /// </summary>
    public bool IsPlaying()
    {
        return animation.isPlaying;
    }


}
