using UnityEngine;
using System.Collections;


public class DroneCreator : MonoBehaviour 
{

    [SerializeField]
    GameObject Type_Gun = null;

    [SerializeField]
    GameObject Type_Mine = null;

    [SerializeField]
    GameObject Type_Sensor = null;

    //[SerializeField]
    //GameObject Type_Jammer = null;

    GameObject droneClone = null;

    NetworkView netWork = null;

    bool canCreate = true;

    public bool CanCreateDrone { get { return canCreate; } }

    public bool IsContainerDestroy()
    {
        return true;
    }

	// Use this for initialization
	void Start () 
    {
        netWork = GetComponent<NetworkView>();
	}

    public void CreateDrone(int _rand, Vector3 _objectPos)
    {
        switch (_rand)
        {
            case 0:
                droneClone = (GameObject)Network.Instantiate(Type_Gun, gameObject.transform.position, gameObject.transform.rotation, 0);
                break;
            case 1:
                droneClone = (GameObject)Network.Instantiate(Type_Mine, gameObject.transform.position, gameObject.transform.rotation, 0);
                break;
            case 2:
                droneClone = (GameObject)Network.Instantiate(Type_Sensor, gameObject.transform.position, gameObject.transform.rotation, 0);
                break;
            case 3:
                droneClone = (GameObject)Network.Instantiate(Type_Mine, gameObject.transform.position, gameObject.transform.rotation, 0);
                break;
        }
        droneClone.transform.parent = gameObject.transform;
        canCreate = false;
    }

    // Update is called once per frame
    void Update()
    {
        ;

    }

}
