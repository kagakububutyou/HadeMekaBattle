using UnityEngine;
using System.Collections;

public class Elevater : MonoBehaviour {

    [SerializeField]
    Vector3 moveToPosition = Vector3.zero;
    
    [SerializeField]
    float delayTime = 1.0f;

    [SerializeField]
    float moveTime = 1.0f;

    [SerializeField]
    iTween.EaseType easeType = iTween.EaseType.linear;


	// Use this for initialization
	void Start () {
        Move();	   
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Move()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", moveToPosition, "delay", delayTime, "time", moveTime, "easetype", easeType,"looptype",iTween.LoopType.pingPong));
    }
}
