using UnityEngine;
using System.Collections;

public class ScalingScript : MonoBehaviour
{
    //時間による大きさの変化を制御します
    /// <summary>
    /// 大きさの変更後、オブジェクトをどうするかを指定します
    /// </summary>
    public enum MODE
    {
        DEATH,
        ALIVE
    }
    public enum TARGET
    {
        PARENT,
        CHILD
    }
    public TARGET target;
    public MODE mode;
    /// <summary>
    /// 大きさを変化させる時間
    /// </summary>
    public float effectTime;
    /// <summary>
    /// 変更後の大きさ
    /// </summary>
    public Vector3 scale;
    //単位時間当たりの拡縮量
    private Vector3 deltaScale;
    //時間計測用
    private float timeBuffer;


	// Use this for initialization
	void Start ()
    {
        deltaScale = (scale - transform.localScale) / effectTime;
        timeBuffer = 0;
	}
	
	void FixedUpdate ()
    {
        if (timeBuffer > effectTime)
        {
            if (mode == MODE.DEATH)
                Destroy(gameObject);
        }
        else
        {
            if (target == TARGET.CHILD)
            {
                foreach (Transform child in transform)
                {
                    child.localScale = child.localScale + deltaScale * Time.fixedDeltaTime;
                }
            }
            else if (target == TARGET.PARENT)
            {
                transform.localScale = transform.localScale + deltaScale * Time.fixedDeltaTime;
            }
            timeBuffer += Time.fixedDeltaTime;
        }
	}
}
