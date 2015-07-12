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
        Mine,
        Your
    }

    NowState dollState = NowState.Stay;
    OwnerState owner = OwnerState.None;

    NetworkView netState = null;
    bool mine = false;


    public bool IsStay { get { return dollState == NowState.Stay; } }
    public bool IsActive { get { return dollState == NowState.Active; } }

    public bool IsNone { get { return owner == OwnerState.None; } }
    public bool IsMaine { get { return owner == OwnerState.Mine; } }
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
        owner = OwnerState.Mine;
        //Debug.Log("State->" + DollState);
    }
	
    //ドローンの所有者を判別する
    OwnerState WhoIsOwner()
    {
        if (owner == OwnerState.None)  return OwnerState.None;

        if (netState.isMine) return OwnerState.Mine;
        else return OwnerState.Your; 
    }

	// Update is called once per frame
	void Update () 
    {

        Debug.Log("State->" + dollState);
	
	}
}
