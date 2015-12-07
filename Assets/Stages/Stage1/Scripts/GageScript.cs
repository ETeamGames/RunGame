using UnityEngine;
using System.Collections;

public class GageScript : MonoBehaviour {
    [Header("プロパティ名にカーソルを合わせると説明が表示されます")]
    [Tooltip("青いゲージ")]
    public GameObject blueGage;
    [Tooltip("赤いゲージ")]
    public GameObject redGage;
    [Tooltip("減衰量/秒")]
    public float attenuation;
    [Tooltip("回復量/秒")]
    public float increment;
    /// <summary>
    /// ゲージの増減を制御 1=回復 -1=減少 0=停止
    /// </summary>
    public int mode;
    /// <summary>
    /// ゲージ全消費じtrue
    /// </summary>
    public bool empty;
    private Vector2 gageScale = new Vector2();

    // Use this for initialization
    void Start () {
        blueGage.transform.localScale = redGage.transform.localScale;
        gageScale = blueGage.transform.localScale;
        mode = 0;
        empty = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        gageProc();
    }

    void gageProc()
    {
        if (empty | mode == 1)
        {
            gageScale.x += Time.deltaTime * increment * redGage.transform.localScale.x;
        }
        else if (mode == -1)
        {
            gageScale.x -= Time.deltaTime * attenuation * redGage.transform.localScale.x * (1f / GameManager.slowSpeed);
        }
        if (mode != 0)
        {
            blueGage.transform.localScale = gageScale;
        }
        if (blueGage.transform.localScale.x < 0)
        {
            empty = true;
        }
        else if (blueGage.transform.localScale.x > redGage.transform.localScale.x)
        {
            blueGage.transform.localScale = redGage.transform.localScale;
            gageScale = blueGage.transform.localScale;
            mode = 0;
            empty = false;
        }
    }
}
