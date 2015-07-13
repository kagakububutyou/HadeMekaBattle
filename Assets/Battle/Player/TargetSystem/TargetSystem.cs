using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetSystem : MonoBehaviour {

    /// <summary>
    /// エネミー一覧のスクリプトを得る
    /// </summary>
    EnemyListManager enemyListManager = null;

    /// <summary>
    /// 探した結果
    /// </summary>
    List<GameObject> insideObjects = new List<GameObject>();
    public List<GameObject> InsideObjects { get { return insideObjects; } }

    /// <summary>
    /// ターゲットのわっかの中心位置
    /// </summary>
    Vector3 screenCenter = Vector3.zero;
    
    /// <summary>
    /// ターゲットサークルの半径
    /// </summary>
    float targetCircleRadius = 100.0f;

	// Use this for initialization
	void Start () {
        enemyListManager = GetComponent<EnemyListManager>();
        screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        

        RefreshInsideObjects();


	}

    /// <summary>
    /// ターゲットサークル内にいる敵一覧を更新する
    /// </summary>
    void RefreshInsideObjects()
    {
        targetCircleRadius = Screen.height / 3;

        ///削除
        InsideObjects.Clear();


        foreach (var enemy in enemyListManager.GetEnemyList())
        {
            var enemyScreenPoint = Camera.main.WorldToScreenPoint(enemy.transform.position);
            enemyScreenPoint.z = 0.0f;

            if (Vector3.Distance(enemyScreenPoint, screenCenter) < targetCircleRadius)
            {
                InsideObjects.Add(enemy);
            }
        }

    }
}
