/////////////////////////////////////
//ドール状態管理
//
//
///////////////////////////////////////
using UnityEngine;
using System.Collections;

public class DollStateManager : MonoBehaviour 
{
    enum NowState
    {
        Air,
        Wait,
        Stop
    }
    NowState DollState;

    public bool IsAiring { get { return DollState == NowState.Air; } }
    public bool IsWaiting { get { return DollState == NowState.Wait; } }

	// Use this for initialization
	void Start () 
    {
        DollState = NowState.Air;
        //Debug.Log("State->" + DollState);
	}

    public void ChangeWaiting()
    {
        DollState = NowState.Wait;
        //Debug.Log("State->" + DollState);
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
