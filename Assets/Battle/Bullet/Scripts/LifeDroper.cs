using UnityEngine;
using System.Collections;

// 弾丸の寿命設定
public class LifeDroper : MonoBehaviour {

	[SerializeField]
	private float lifeTime = 5.0f;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {

		lifeTime -= Time.deltaTime;

		if(lifeTime <= 0.0f) Destroy(this.gameObject);
	}
}
