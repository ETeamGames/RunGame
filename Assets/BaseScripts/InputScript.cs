using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour {
    private static bool isTouch = false;
    /// <summary>
    /// 入力があるかどうかを返します
    /// </summary>
    /// <returns>true＝あり　false=無し</returns>
    public static bool isInputDown()
    {
        return (Input.GetMouseButtonDown(0) || Input.touchCount != 0);
    }
    /// <summary>
    /// 入力が解除されたかを返します
    /// </summary>
    /// <returns>true=解除 false=未解除</returns>
    public static bool isInputUp()
    {
        return (Input.GetMouseButtonUp(0) || (Input.touchCount == 0 && isTouch));
    }
    /// <summary>
    /// 入力された場所を取得します
    /// </summary>
    /// <returns>入力された場所（スクリーン座標）</returns>
    public static Vector3 getInputDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return Input.mousePosition;
        }
        else if(isInputDown())
        {
            return Input.GetTouch(0).position;
        }
        return Vector3.zero;
    }

    /// <summary>
    /// 入力が解除された場所を取得する
    /// </summary>
    /// <returns></returns>
    public static Vector3 getInputUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            return Input.mousePosition;
        }
        else if(isInputUp())
        {
            return Input.GetTouch(0).position;
        }
        return Vector3.zero;
    }
    /// <summary>
    /// 入力状態のバッファをすべて初期化します。
    /// </summary>
    public static void refresh()
    {
        isTouch = false;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
