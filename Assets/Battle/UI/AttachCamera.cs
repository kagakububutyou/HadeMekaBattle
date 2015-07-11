using UnityEngine;
using System.Collections;

public class AttachCamera : MonoBehaviour {

    /// <summary>
    /// キャンバスのゲームオブジェクト
    /// </summary>
    GameObject canvasUI = null;

    /// <summary>
    /// キャンバスのコンポーネント
    /// </summary>
    Canvas canvasCompornent = null;


    /// <summary>
    /// 各コンポーネントを得る。
    /// </summary>
    public void Initialize()
    {
        canvasUI = GameObject.Find("UICanvas");
        canvasCompornent = canvasUI.GetComponent<Canvas>();
    }

    public void Attach()
    {
        if(canvasUI == null || canvasCompornent == null)
        {
            Debug.Log("get canvas is failed!!");
        }
        canvasCompornent.renderMode = RenderMode.ScreenSpaceCamera;
        canvasCompornent.worldCamera = Camera.main;
        canvasCompornent.planeDistance = 1.0f;
    }
}
