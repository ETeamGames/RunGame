using UnityEngine;
using System.Collections;

public class KaboonScript : MonoBehaviour {
    /// <summary>
    /// 爆発用オブジェクト
    /// </summary>
    public GameObject kaboon;
    /// <summary>
    /// 表示する際の大きさ
    /// </summary>
    public Vector2 scale;
    /// <summary>
    /// 消えるまでの時間
    /// </summary>
    public float alphaEffectTime;
    /// <summary>
    /// 大きさを変化させる時間
    /// </summary>
    public float scaleEffectTime;
    private GameObject go;
    private bool flag;
    private SpriteRenderer sr;
    private float timeBuffer;
    public void setKaboon()
    {
        go = (GameObject)Instantiate(kaboon, transform.position, transform.rotation);
        go.transform.localScale = Vector2.zero;
        sr = go.GetComponent<SpriteRenderer>();
        flag = true;
    }

	// Use this for initialization
	void Start () {
        flag = false;
        timeBuffer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(flag & scaleEffectTime > timeBuffer)
        {
            go.transform.localScale = (scale / scaleEffectTime) * timeBuffer;
        }
        else if (flag & alphaEffectTime+scaleEffectTime > timeBuffer)
        {
            sr.color = new Color(sr.color.r,sr.color.g,sr.color.b,1.0f - (timeBuffer/alphaEffectTime));
        }
        if (flag)
        {
            timeBuffer += Time.deltaTime;
        }
    }
}
