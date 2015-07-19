/////////////////////////////////////
//ドローン状態管理
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
        Destroy,
    }

    enum OwnerState
    {
        None,
        Maine,
        Your
    }

    NowState dollState;
    OwnerState owner;

    [SerializeField]
    int damageValue = 0;
    NetworkView netState = null;

    public bool IsStay { get { return dollState == NowState.Stay; } }
    public bool IsActive { get { return dollState == NowState.Active; } }
    public bool IsStop { get { return dollState == NowState.Destroy; } }

    public bool IsNone { get { return owner == OwnerState.None; } }
    public bool IsMaine{get { return owner == OwnerState.Maine;} }
    public bool IsYour { get { return owner == OwnerState.Your; } }

    public int HitDamage { get { return damageValue; } }

    // Use this for initialization
	void Start () 
    {
        dollState = NowState.Stay;
        owner = OwnerState.None;
        netState = GetComponent<NetworkView>();
	}

    public void ChangeActive()
    {
        //状態をActiveにする
        dollState = NowState.Active;
    }

    public void ChangeStop()
    {
        //状態をActiveにする
        dollState = NowState.Destroy;
        //Debug.Log("Good-By!!" );
    }

    public bool WhoIsOwner()
    {

        if (netState.isMine) return true;
        else return false;
    }

    //ドローンの所有者を判別する
    void ChangeOwner()
    {
        if (WhoIsOwner()) owner = OwnerState.Maine;
        else owner = OwnerState.Your; 
    }

	// Update is called once per frame
	void Update ()
    {
        //親オブジェクトを取得
        //Debug.Log("Parent:" + Clone.name);
        //Debug.Log("State->" + dollState);

        if (IsStop) Network.Destroy(gameObject);

        //ChangeOwner();
        //Debug.Log("Owner is->" + owner);
        
	}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ChangeOwner();
        }
    }
}
