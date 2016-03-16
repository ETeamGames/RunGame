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
    private static bool gameover = false;
    public static float slowSpeed = 0.5f;
    public static float normalSpeed = 1.0f;
    public static Camera mainCamera;
    public static ColorFilter colorFilter;
    public static PlayerScript playerScript;
    public static Canvas goalCanvas;
    private IsCheckPointScript playerCheckScript;
    private Animator playerAnimator;
    public ColorFilter filter;
    public Camera cam;
    public Canvas gui;
    public Canvas goal;
    public float slow;
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
        normalSpeed = Time.timeScale;
        scoreText = GameObject.Find("ScoreText").gameObject.GetComponent<Text>();
        playerScript = GameObject.Find("_Player").GetComponent<PlayerScript>();
        score = 0;
        colorFilter = filter;
        state = CONTROL.GUI;
        gui.enabled = false;
        gameover = false;
        mainCamera = cam;
        slowSpeed = slow;
        goalCanvas = goal;
    }

	// Use this for initialization
	void Start ()
    {
    }

    public static void onSlow()
    {
        Time.timeScale = slowSpeed;
    }
    public static void offSlow()
    {
        Time.timeScale = normalSpeed;
    }

    public static void gameOver()
    {
        gameover = true;
        playerScript.gameObject.GetComponent<MoveScript>().enabled = false;
        InputManager.guiFlag = true;
    }

    public static bool getGameOverFlag()
    {
        return gameover;
    }

    public static void checkPoint()
    {
        score_buffer = score;
    }

    public void continueGame()
    {
        Application.LoadLevel(Application.loadedLevelName);
        /*state = CONTROL.GAME;
        gui.enabled = false;
        if (GameObject.Find("GameOverEffect").GetComponent<GameOverEffectScript>() != null)
            GameObject.Find("GameOverEffect").GetComponent<GameOverEffectScript>().stop();
        InputManager.input.init();
        playerCheckScript.continueCheckPoint();
        score = score_buffer;*/
    }

    public void returnStageSelect()
    {
        Application.LoadLevel("SelectStage");
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
