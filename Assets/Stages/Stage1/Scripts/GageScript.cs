using UnityEngine;
using System.Collections;

public class GageScript : MonoBehaviour
{
    public enum GAGE_STATE
    {
        INCREMENT,
        ATTENUATION,
        STOP
    }
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
    public static GAGE_STATE mode;
    /// <summary>
    /// ゲージ全消費じtrue
    /// </summary>
    private Vector2 gageScale = new Vector2();

    // Use this for initialization
    void Start ()
    {
        blueGage.transform.localScale = redGage.transform.localScale;
        gageScale = blueGage.transform.localScale;
        mode = GAGE_STATE.STOP;
    }
	
	// Update is called once per frame
	void Update ()
    {
        gageProc();
    }

    void gageProc()
    {
        //ゲージが空で無いかモードが増加の場合
        if (InputManager.emptyGageFlag | mode == GAGE_STATE.INCREMENT)
        {
            gageScale.x += Time.deltaTime * increment * redGage.transform.localScale.x;
        }
        //モードが減少の場合
        else if (mode == GAGE_STATE.ATTENUATION)
        {
            gageScale.x -= Time.deltaTime * attenuation * redGage.transform.localScale.x * (1f / GameManager.slowSpeed);
        }
        //モードが停止の場合
        if (mode != GAGE_STATE.STOP)
        {
            blueGage.transform.localScale = gageScale;
        }
        //スケールが0より小さい（ゲージがすべて赤）時に空フラグをtrueにする
        if (blueGage.transform.localScale.x < 0)
        {
            InputManager.emptyGageFlag = true;
        }
        //ゲージがすべて青になったら空フラグをfalseにし、モードをストップに
        else if (blueGage.transform.localScale.x > redGage.transform.localScale.x)
        {
            blueGage.transform.localScale = redGage.transform.localScale;
            gageScale = blueGage.transform.localScale;
            mode = GAGE_STATE.STOP;
            InputManager.emptyGageFlag = false;
        }
    }
}
