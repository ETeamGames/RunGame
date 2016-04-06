using UnityEngine;
using System.Collections;

public abstract class IsTrapScript : MonoBehaviour
{
    /// <summary>
    /// 罠に掛かった時に再生するアニメーション用キャッシュ
    /// </summary>
    protected Animator anim;
    /// <summary>
    /// 拘束時間観測用
    /// </summary>
    protected float timeBuffer = 0;
    /// <summary>
    /// 掛かった罠のキャッシュ
    /// </summary>
    protected TrapScript trapScript;

    /// <summary>
    /// TrapScriptから呼び出される関数
    /// </summary>
    /// <param name="trap">呼び出す側の罠スクリプト</param>
    public abstract void callAnimation(TrapScript trap);

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
