using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartEffectScript : MonoBehaviour
{
    /// <summary>
    /// エフェクト用
    /// </summary>
    [SerializeField]
    private SpriteRenderer colorFilter;
    /// <summary>
    /// ステージ名表示用
    /// </summary>
    [SerializeField]
    private Text textRender;
    /// <summary>
    /// ステージ名。ゲーム開始時に中央に表示される
    /// </summary>
    [SerializeField]
    private string stageName = "no_name";
    /// <summary>
    /// ステージ名のフェードイン時間
    /// </summary>
    [SerializeField]
    private float dispOffset;
    /// <summary>
    /// 暗転時間
    /// </summary>
    [SerializeField]
    private float freezeTime = 5f;
    /// <summary>
    /// ゲーム開始時の暗転解除用
    /// </summary>
    [SerializeField]
    private float background_Fade_out_Time = 0;
    /// <summary>
    /// 時間計測用
    /// </summary>
    [SerializeField]
    private float timeBuffer = 0;
	// Use this for initialization
	void Start ()
    {
        //入力を受け付けない
        InputManager.guiFlag = true;
        textRender.text = stageName;
        textRender.color = new Color(textRender.color.r, textRender.color.g, textRender.color.b,0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timeBuffer >= 0)
        {
            timeBuffer += Time.deltaTime;
            //暗転に関しての処理
            if (timeBuffer >= (freezeTime + background_Fade_out_Time))
            {
                GameManager.state = GameManager.CONTROL.GAME;
                GameManager.playerScript.gameObject.GetComponent<MoveScript>().ResumePlayerMovement();
                colorFilter.enabled = false;
                GameManager.startTime = Time.time;
                InputManager.guiFlag = false;
            }
            else if (timeBuffer > freezeTime)
            {
                colorFilter.color = Color.Lerp(Color.clear, Color.black, 1f - ((timeBuffer - freezeTime) / background_Fade_out_Time));
            }
            //ステージ名に関しての処理
            //ステージ名を非表示
            if(timeBuffer >= (dispOffset+freezeTime+background_Fade_out_Time))
            {
                textRender.enabled = false;
                timeBuffer = -1;
                InputManager.guiFlag = false;
                GameManager.playerScript.gameObject.GetComponent<MoveScript>().enabled = true;
            }
            //ステージ名のフェードアウト
            else if (timeBuffer >= (dispOffset + freezeTime))
            {
                textRender.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, 1f - ((timeBuffer - dispOffset - freezeTime) / background_Fade_out_Time));
            }
            //ステージ名のフェードイン
            else if (timeBuffer >= dispOffset & timeBuffer <= (dispOffset+freezeTime))
            {
                textRender.color = Color.Lerp(Color.white,new Color(1, 1, 1, 0), 1f - ((timeBuffer - dispOffset) / background_Fade_out_Time));
            }
        }
	}
}
