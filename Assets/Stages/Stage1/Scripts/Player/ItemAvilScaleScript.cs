using UnityEngine;
using System.Collections;

public class ItemAvilScaleScript : MonoBehaviour
{
    /// <summary>
    /// 変化が終わるまでの時間
    /// </summary>
    public float changeTime;
    /// <summary>
    /// 変化が続く時間
    /// </summary>
    public float effectTime;
    /// <summary>
    /// 変化後の大きさ
    /// </summary>
    public float scale;
    /// <summary>
    /// 大きさの初期値
    /// </summary>
    public Vector3 initScale;
    /// <summary>
    /// 変化時間測定用
    /// </summary>
    private float timeBuffer;
    /// <summary>
    /// 状態
    /// 0:変化はじめ
    /// 1:変化中
    /// 2:変化終わり
    /// </summary>
    private int flag = 0;

	// Use this for initialization
	void Start () {
        initScale = transform.localScale;
	}

    public void start()
    {
        flag = 0;
    }
	
	// Update is called once per frame
	void Update ()
    { 
        if(flag == 0)
        {
            timeBuffer += Time.deltaTime;
            transform.localScale = initScale + (initScale * ((scale-1) / changeTime) * timeBuffer);
            if(timeBuffer >= changeTime)
            {
                timeBuffer = 0;
                flag = 1;
            }
        }
        else if(flag == 1)
        {
            if(timeBuffer >= effectTime)
            {
                timeBuffer = 0;
                flag = 2;
            }
            timeBuffer += Time.deltaTime;
        }
        else if(flag == 2)
        {
            timeBuffer += Time.deltaTime;
            transform.localScale = (initScale*scale)-(initScale * ((scale-1) / changeTime) * timeBuffer);
            if (timeBuffer >= changeTime)
            {
                Destroy(this);
            }
        }
	}
}

