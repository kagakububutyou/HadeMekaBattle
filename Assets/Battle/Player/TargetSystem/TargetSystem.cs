using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetSystem : MonoBehaviour {

    /// <summary>
    /// エネミー一覧のスクリプトを得る
    /// </summary>
    EnemyListManager enemyListManager = null;

	// Use this for initialization
	void Start () {
        enemyListManager = GetComponent<EnemyListManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// 探した結果
    /// </summary>
    List<GameObject> insideObjects = null;
    public List<GameObject> InsideObjects { get { return insideObjects; } }

    /// <summary>
    /// ターゲットのわっかの中心位置
    /// </summary>
    [SerializeField]
    Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0.0f);


    /// <summary>
    /// ターゲットサークルの半径
    /// </summary>
    [SerializeField]
    float targetCircleRadius = 100.0f;

    public List<GameObject> IsInsideSight()
    {
        ///削除
        InsideObjects.Clear();

        foreach(var enemy in enemyListManager.GetEnemyList())
        {
            if (Vector3.Distance(Camera.main.WorldToScreenPoint(enemy.transform.position), screenCenter) < targetCircleRadius)
            {
                InsideObjects.Add(enemy);
            }
        }
        
        return InsideObjects;
    }

}
