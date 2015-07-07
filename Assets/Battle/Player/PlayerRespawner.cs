using UnityEngine;
using System.Collections;

public class PlayerRespawner : MonoBehaviour {

    /// <summary>
    /// 死ぬ高さ。この高さよりYが小さくなった場合にリスポンする
    /// </summary>
    [SerializeField]
    float deadHeight = -30.0f;


    /// <summary>
    /// リスポンする場所
    /// </summary>
    [SerializeField]
    Vector3 spawnPosition = Vector3.zero;


    Rigidbody rigidBody = null;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.R) || deadHeight > transform.position.y )
        {
            Respawn();
        }
	}

    /// <summary>
    /// 再度生成する
    /// </summary>
    void Respawn()
    {
        rigidBody.velocity = Vector3.zero;
        transform.position = spawnPosition;
    }

}
