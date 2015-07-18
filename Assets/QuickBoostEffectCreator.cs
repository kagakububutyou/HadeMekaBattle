using UnityEngine;
using System.Collections;

public class QuickBoostEffectCreator : MonoBehaviour {

    [SerializeField]
    GameObject effect = null;
 
	// Use this for initialization
	void Start () {
	
	}

    public void Play()
    {
        var clone = (GameObject)Network.Instantiate(effect,Vector3.zero,Quaternion.identity,0);
        clone.transform.SetParent(transform);
        clone.transform.position = transform.position;
        clone.transform.rotation = transform.rotation;

        StartCoroutine(WaitDestory(clone));
    }

    IEnumerator WaitDestory(GameObject clone)
    {
        yield return new WaitForSeconds(clone.GetComponent<ParticleSystem>().startLifetime);

        Network.Destroy(clone);
    }
}
