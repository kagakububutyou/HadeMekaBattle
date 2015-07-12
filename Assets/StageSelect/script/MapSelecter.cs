using UnityEngine;
using System.Collections;

public class MapSelecter : MonoBehaviour 
{

    [SerializeField]
    GameObject prefab = null;

    [SerializeField]
    GameObject pos = null;

    [SerializeField]
    MapCreator creator = null;


    public int mapNumber
    {
        get;
        private set;
    }


    public void OnClick(int _mopNumber)
    {
        Debug.Log("Clicked->." + _mopNumber);
        if (mapNumber == _mopNumber) { return; }
        else
        {
            creator.Create(prefab, pos);
        }
        // プレハブからインスタンスを生成
    }


}
