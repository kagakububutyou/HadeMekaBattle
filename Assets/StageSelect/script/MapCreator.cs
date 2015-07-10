using UnityEngine;
using System.Collections;

public class MapCreator : MonoBehaviour 
{
    [SerializeField]
    MapSelectManegr stateManager = null;

    GameObject clone = null;

    void Start()
    {
        
    }

   public void Create(GameObject _prefab, GameObject _position)
    {
        clone = (GameObject)Instantiate(_prefab, _position.transform.position, _position.transform.rotation);
        clone.transform.parent = _position.transform;
    }

}

