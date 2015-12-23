using UnityEngine;
using UnityEngine.EventSystems;

public class InputScript : MonoBehaviour {
    /// <summary>
    /// タッチ可能なデバイスの場合はtrue
    /// </summary>
    private static bool touchable = false;
    private static bool isTouch = false;
    private static Vector2 touchUpPosition = Vector2.zero;
    /// <summary>
    /// 入力があるかどうかを返します
    /// </summary>
    /// <returns>true＝あり　false=無し</returns>
    public static bool isInputDown()
    {
        if ((Input.GetMouseButtonDown(0) | (Input.touchCount != 0 & touchable)) & !isTouch)
        {
            isTouch = true;
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// 入力が解除されたかを返します
    /// </summary>
    /// <returns>true=解除 false=未解除</returns>
    public static bool isInputUp()
    {
        if((Input.GetMouseButtonUp(0) | (Input.touchCount == 0 & touchable)) & isTouch)
        {
            isTouch = false;
            if (Input.GetMouseButtonUp(0))
            {
                touchUpPosition = Input.mousePosition;
            }
            return true;
        }
        else
        {
            return false;
        }

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
    /// マウスポインタ、あるいはタッチされている場所を返します
    /// </summary>
    /// <returns>マウスポインタあるいはタッチされた座標</returns>
    public static Vector3 getPosition()
    {
        if (Input.touchCount != 0)
            return Input.GetTouch(0).position;
        else if (!Input.GetMouseButton(0))
            return Input.mousePosition;
        else
            return Input.mousePosition;
    }

    /// <summary>
    /// 入力が解除された場所を取得する
    /// </summary>
    /// <returns></returns>
    public static Vector3 getInputUp()
    {
        return touchUpPosition;
    }
    /// <summary>
    /// 入力状態のバッファをすべて初期化します。
    /// </summary>
    public static void refresh()
    {
        isTouch = false;
    }
    /// <summary>
    /// タッチされているかを返します
    /// </summary>
    /// <returns>タッチされているか,true or false</returns>
    public static bool getIsTouch()
    {
        return isTouch;
    }
    void Awake()
    {
        if (Application.platform == RuntimePlatform.Android | Application.platform == RuntimePlatform.IPhonePlayer)
        {
            touchable = true;
        }
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount != 0)
            touchUpPosition = Input.GetTouch(0).position;
	}
}
