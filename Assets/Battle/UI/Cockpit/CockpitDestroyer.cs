using UnityEngine;
using System.Collections;

public class CockpitDestroyer : MonoBehaviour
{

    SpriteRenderer spriteRenderer = null;

    [SerializeField]
    iTween.EaseType easeType = iTween.EaseType.linear;

    [SerializeField]
    float delayTime = 0.0f;

    [SerializeField]
    float fadeTime = 5.0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        iTween.ValueTo(gameObject, iTween.Hash("from", 1.0f, "to", 0.0f, "delay", delayTime, "time", fadeTime - delayTime, "easetype", easeType, "onupdate", "UpdateHandler"));
    }

    private void UpdateHandler(float value)
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, value);
    }

    void Update()
    {
        if (TimeManager.NowTimeSecond > fadeTime - delayTime) Destroy(gameObject);
    }

}