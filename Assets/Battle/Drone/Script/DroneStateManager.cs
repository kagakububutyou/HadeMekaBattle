/////////////////////////////////////
//ドール状態管理
//
//
///////////////////////////////////////
using UnityEngine;
using System.Collections;

public class DroneStateManager : MonoBehaviour 
{
    enum NowState
    {
        Stay,
        Active,
        Stop
    }

    enum OwnerState
    {
        None,
        Maine,
        Your
    }

    NowState dollState;
    OwnerState owner;

    NetworkView netState;
    bool maine;


    public bool IsStay { get { return dollState == NowState.Stay; } }
    public bool IsActive { get { return dollState == NowState.Active; } }

    public bool IsNone { get { return owner == OwnerState.None; } }
    public bool IsMaine{ get { return owner == OwnerState.Maine;} }
    public bool IsYour { get { return owner == OwnerState.Your; } }
	
    // Use this for initialization
	void Start () 
    {
        dollState = NowState.Stay;
        owner = OwnerState.None;
        netState = GetComponent<NetworkView>();
        //Debug.Log("State->" + DollState);
	}

    public void ChangeActive()
    {
        gameObject.transform.parent = null;
        dollState = NowState.Active;
        owner = OwnerState.Maine;
        //Debug.Log("State->" + DollState);
    }
	
    //ドローンの所有者を判別する
    OwnerState WhoIsOwner()
    {
        if (owner == OwnerState.None)  return OwnerState.None;

        if (netState.isMine)  return OwnerState.Maine; 
        else  return OwnerState.Your; 
    }

	// Update is called once per frame
	void Update () 
    {

        Debug.Log("State->" + dollState);
	
	}
}
