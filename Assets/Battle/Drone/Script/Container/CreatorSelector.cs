using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatorSelector : MonoBehaviour 
{
    [SerializeField]
    List<ContainerCreator> containerCreators = new List<ContainerCreator>();


    DronTypeSelector dronTypeSelector = null;

	// Update is called once per frame
	void Update () 
    {
        //Pキーを押したとき
        if (Input.GetKeyDown(KeyCode.P))
        {
            //0~containerCreatorsの最大数までのランダムな値をだす
            int _random = Random.Range(0, containerCreators.Count);
            SelectCreator(_random);
            //Debug.Log("Rand" + _random);
        }
	}
    /// <summary>
    /// どのCreatorが生成するか判別します
    /// </summary>
    /// <param name="_random">ランダム値</param>
    void SelectCreator(int _random)
    {   //総当たりでcontainerPrefabにあるIdと_randomの値を比較させます
        foreach (var _containerCreatorsPrefab in containerCreators)
        {
            if (_containerCreatorsPrefab.CanCreateContainer(_random))
            {
                //生成可能な場合コンテナを作ります。
                _containerCreatorsPrefab.Create();
                break;
            }
        }
    }
}















