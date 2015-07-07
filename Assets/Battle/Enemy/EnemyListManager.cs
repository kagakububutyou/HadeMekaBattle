using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyListManager : MonoBehaviour {

    /// <summary>
    /// 敵一覧を格納するリスト
    /// </summary>
    List<GameObject> enemyList = null;

    public void Add(GameObject _newObject)
    {
        enemyList.Add(_newObject);
    }

    public GameObject GetEnemy(int _id)
    {
        if(_id >= enemyList.Count)
        {
            Debug.Log("_id is Out of EnemyList's Length!");
            return null;
        }

        return enemyList[_id];
    }

    public List<GameObject> GetEnemyList()
    {
        return enemyList;
    }


}
