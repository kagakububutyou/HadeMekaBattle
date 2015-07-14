using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BarButtonMover : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{

    [SerializeField]
    Camera padCamera = null;


    RectTransform parentRect = null;

    RectTransform myRect = null;


    public UnityEvent onLongPress = new UnityEvent();

    void Start()
    {
        parentRect = transform.parent.GetComponent<RectTransform>();
        myRect = GetComponent<RectTransform>();
    }

    float lastMouseX = 0.0f;
    float deltaMouseX = 0.0f;
    void Update()
    {
        
        onLongPress.Invoke();
        if(isPress)
        {
            deltaMouseX = Input.mousePosition.x - lastMouseX;
            MoveByMouse();
            lastMouseX = Input.mousePosition.x;
        }
    }

    /// <summary>
    /// マウスで移動する
    /// </summary>
    void MoveByMouse()
    {
        var newX = myRect.localPosition.x + deltaMouseX * (800.0f / (float)padCamera.pixelWidth);

        if (newX > parentRect.sizeDelta.x/2) newX = parentRect.sizeDelta.x/2;
        if (newX < -parentRect.sizeDelta.x / 2) newX = -parentRect.sizeDelta.x / 2;

        myRect.localPosition = new Vector3(newX, myRect.localPosition.y, myRect.localPosition.z);

    }

    /// <summary>
    /// 押されているかどうか
    /// </summary>
    bool isPress = false;

    /// <summary>
    /// 押した"瞬間"に実行される
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        isPress = true;
        lastMouseX = Input.mousePosition.x;
    }


    /// <summary>
    /// 離された"瞬間"に実行される
    /// </summary>
    public void OnPointerUp(PointerEventData eventData)
    {
        isPress = false;
    }


}
