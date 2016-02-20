using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public enum CONTROL
    {
        NON,
        GAME,
        GUI
    }
    private static int score;
    //チェックポイント追加時のスコア
    private static int score_buffer;
    public static float startTime;
    public static CONTROL state = CONTROL.NON;
    public static PlayerScript playerScript;
    public static bool gameover = false;
    public static float slowSpeed = 0.5f;
    public static float normalSpeed = 1.0f;
    private IsCheckPointScript playerCheckScript;
    private Animator playerAnimator;
    public GameObject player;
    public Camera cam;
    private bool touchDown = false;
    public static bool touchable = true;
    public Canvas gui;
    public static GameObject checkPointParent;
    public static GameObject nowCheckPoint;
    public static GameObject checkPointPrefab;
    public static Text scoreText;
    
    public static int Score
    {
        set{
            score = value;
            scoreText.text = score.ToString();
        }
        get
        {
            return score;
        }
    }

    void Awake()
    {
        //画面解像度を設定
        Screen.SetResolution(1920,1080, false, 60);
        playerScript = player.GetComponent<PlayerScript>();
        playerCheckScript = player.GetComponent<IsCheckPointScript>();
        playerAnimator = player.GetComponent<Animator>();
        normalSpeed = Time.timeScale;
        checkPointParent = GameObject.Find("CheckPoints");
        scoreText = GameObject.Find("ScoreText").gameObject.GetComponent<Text>();
        score = 0;
    }

	// Use this for initialization
	void Start ()
    {
        state = CONTROL.NON;
        playerScript.gameObject.GetComponent<MoveScript>().StopPlayerMovement();
        gui.enabled = false;
        gameover = false;
        player.GetComponent<MoveScript>().cam = cam;
    }

    public static void onSlow()
    {
        Time.timeScale = slowSpeed;
    }
    public static void offSlow()
    {
        Time.timeScale = normalSpeed;
    }

    public static void checkPoint()
    {
        score_buffer = score;
    }

    public void continueGame()
    {
        playerScript.gameObject.GetComponent<Animator>().enabled = true;
        playerScript.gameObject.GetComponent<MoveScript>().enabled = true;
        state = CONTROL.GAME;
        gui.enabled = false;
        if (GameObject.Find("GameOverEffect").GetComponent<GameOverEffectScript>() != null)
            GameObject.Find("GameOverEffect").GetComponent<GameOverEffectScript>().stop();
        InputScript.refresh();
        playerCheckScript.continueCheckPoint();
        score = score_buffer;
        player.GetComponent<MoveScript>().ResumePlayerMovement();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //debug
        if (gameover)
        {
            state = CONTROL.GUI;
            if (!gui.enabled)
            {
                GameObject.Find("GameOverEffect").AddComponent<GameOverEffectScript>();
            }
            gui.enabled = true;
        }
    }
}
