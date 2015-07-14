using UnityEngine;
using System.Collections;


using UnityEngine.UI;

public class BagLog : MonoBehaviour 
{

    [SerializeField]
    DroneStateManager ownerLog;


    [SerializeField]
    Text ownerText;

	// Use this for initialization
	void Start () 
    {
        //if (ownerLog.IsNone)
            ownerText.text = "Owner: IsNone";
 
    }
	
	// Update is called once per frame
	void Update () 
    {

        if (ownerLog.IsMaine) ownerText.text = "Owner: IsMaine";
        else if (ownerLog.IsYour) ownerText.text = "Owner: IsYour";

	}
}
