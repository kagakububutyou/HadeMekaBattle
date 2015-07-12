using UnityEngine;
using System.Collections;

public class PlayerRotater : MonoBehaviour {


	// Update is called once per frame
	void Update () {
        HorizontalRotate();
	}

    /// <summary>
    /// 左右の視点移動
    /// </summary>
    void HorizontalRotate ()
    {
        var xValue = Input.GetAxis("Mouse X");

        if (xValue == 0 ) return;

        transform.Rotate(Vector3.up, xValue);

    }

    /// <summary>
    /// 上下の視点移動
    /// </summary>
    void VerticalRotate()
    {
        var yValue = Input.GetAxis("Mouse Y");

        if (yValue == 0) return;
    }

}
