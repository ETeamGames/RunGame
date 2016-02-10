using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoalScript : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer colorFilter;
    [SerializeField]
    private float fadeTime;
    [SerializeField]
    private Color afterColor;
    [SerializeField]
    private Canvas goalCanvas;
    private bool goalFlag = false;
    private bool retryFlag = false;
    private float timeBuffer = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("GoalScript : OnTriggerdEnter2D :" + col.gameObject.tag);
        if (col.gameObject.tag.Equals("Player"))
        {
            col.gameObject.GetComponent<MoveScript>().StopPlayerMovement();
            GameManager.state = GameManager.CONTROL.GUI;
            goalFlag = true;
            colorFilter.enabled = true;
            GameManager.checkPoint();
            goalCanvas.transform.FindChild("score_value").GetComponent<Text>().text = GameManager.scoreText.text;
            int i_time = (int)(Time.time - GameManager.startTime);
            int min = i_time / 60;
            int sec = i_time - min * 60;
            string s_time = min + ":" + sec;
            goalCanvas.transform.FindChild("time_value").GetComponent<Text>().text = s_time;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (goalFlag & timeBuffer <= fadeTime)
        {
            timeBuffer += Time.deltaTime;
            colorFilter.color = Color.Lerp(afterColor, Color.clear, 1f - timeBuffer / fadeTime);
        }
        else if (goalFlag)
        {
            goalCanvas.enabled = true;
        }
        if(retryFlag & timeBuffer <= fadeTime)
        {
            timeBuffer += Time.deltaTime;
            colorFilter.color = Color.Lerp(Color.black, afterColor, 1f - timeBuffer / fadeTime);
        }
        else if (retryFlag)
        {
            Application.LoadLevel("main");
        }
	}

    //GUIイベント関数
    public void Retry()
    {
        timeBuffer = 0;
        retryFlag = true;
        goalFlag = false;
        goalCanvas.enabled = false;
    }

    public void End()
    {
        Application.LoadLevel("SelectStage");
    }
}
