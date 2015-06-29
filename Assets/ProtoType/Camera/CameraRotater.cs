using UnityEngine;
using System.Collections;

public class CameraRotater : MonoBehaviour {

    [SerializeField]
    Transform targetTransform = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.forward = targetTransform.forward - ((transform.position - targetTransform.position)).normalized;

	}
}
