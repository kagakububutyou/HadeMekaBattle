using UnityEngine;
using System;
using System.Collections;

public class EffekseerEmitter : MonoBehaviour {
	
	public string effectName;
	public bool playOnStart = false;
	public bool loop = false;
	private EffekseerHandle? handle;

    /// <summary>
    /// エフェクト生成
    /// </summary>
    /// <param name="effect"></param>
    /// <param name="pos"></param>
    /// <returns></returns>
    static public GameObject Create(GameObject effect, Vector3 pos)
    {
        return (GameObject)Network.Instantiate(effect,pos,Quaternion.identity,0);
    }

	public void Play(string name)
	{
		effectName = name;
		Play();
	}
	
	public void Play()
	{
		handle = EffekseerSystem.PlayEffect(effectName, transform.position);
		UpdateTransform();
	}
	
	public void Stop()
	{
		if (handle.HasValue) {
			handle.Value.Stop();
			handle = null;
		}
	}
	
	public bool IsPlaying
	{
		get {
			return handle.HasValue && handle.Value.exists;
		}
	}
	
	void Start()
	{
		EffekseerSystem.LoadEffect(effectName);
		if (playOnStart) {
			Play();
		}
	}
	
	void OnDestroy()
	{
		Stop();
	}
	
	void Update()
	{
		if (handle.HasValue) {
			if (handle.Value.exists) {
				UpdateTransform();
			} else if (loop) {
				Play();
			} else {
				handle.Value.Stop();
			}
		}
	}

	void UpdateTransform() {
		if (handle.HasValue) {
			handle.Value.SetLocation(transform.position);
			handle.Value.SetRotation(transform.rotation);
			handle.Value.SetScale(transform.localScale);
		}
	}
}
