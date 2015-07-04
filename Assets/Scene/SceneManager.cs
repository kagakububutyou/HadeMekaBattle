/// -------------------------------------------------------
/// シーン管理者
///
/// code by yamada masamitsu
/// -------------------------------------------------------
using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    static SceneManager instance = null;
    static FadeManager fadeInstance = null;

    /// <summary>
    /// シーンマネージャーのインスタンス
    /// </summary>
    static public SceneManager Instance 
    {   
        get 
        {
            if (instance == null)
            {
                var obj = new GameObject("SceneManager");
                instance = obj.AddComponent<SceneManager>();
                fadeInstance = obj.AddComponent<FadeManager>();
            }
            return instance;
        }
    }

    SceneNameManager.Scene nextScene = SceneNameManager.Scene.Title;

    void Start()
    { 
        // GameObjectを消さないようにする。
        Object.DontDestroyOnLoad(gameObject);
    }
  
    /// <summary>
    /// 切り替える
    /// </summary>
    public void StartChange(SceneNameManager.Scene changeScene,FadeTimeData changeTime)
    {
        nextScene = changeScene;
        fadeInstance.StartFade(changeTime);
    }

    void Update()
    {
        if (!fadeInstance.IsFadeInFinish) return;

        Application.LoadLevel((int)nextScene);
    }

    /// <summary>
    /// シーンを切り替えたかどうか
    /// false...まだ切り替わっていない。
    /// true... 切り替わった。
    /// </summary>
    /// <returns>切り替わったかどうか</returns>
    public bool IsChanged()
    {

        return false;
    }


}
