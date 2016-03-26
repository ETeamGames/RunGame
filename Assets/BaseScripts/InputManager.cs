using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    public static InputScript input
    {
        protected set;
        get;
    }
    /// <summary>
    /// GUI表示中の制限有無 true:制限中
    /// </summary>
    public static bool guiFlag
    {
        set;
        get;
    }
    /// <summary>
    /// ゲージによる制限有無 true:制限中
    /// </summary>
    public static bool emptyGageFlag
    {
        set;
        get;
    }
    // Use this for initialization
    void Start () {
        if (Application.platform == RuntimePlatform.Android | Application.platform == RuntimePlatform.IPhonePlayer)
        {
            input = new TouchInputScript();
        }
        else
        {
            input = new MouseInputScript();
        }
    }
	
	void Update () {
        if (guiFlag | emptyGageFlag)
            input.init();
        else
            input.process();
	}
}
