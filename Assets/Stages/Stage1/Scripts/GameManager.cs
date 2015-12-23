using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public enum CONTROL
    {
        NON,
        GAME,
        GUI
    }

    public static CONTROL state = CONTROL.GAME;
    public static PlayerScript playerScript;
    public static bool gameover = false;
    public IsCheckPointScript playerCheckScript;
    public Animator playerAnimator;
    public Camera cam;
    public static float slowSpeed = 0.5f;
    public static float normalSpeed = 1.0f;
    public bool touchDown = false;
    public static bool touchable = true;
    public GameObject player;
    public Canvas gui;
    public static GameObject checkPointParent;
    public static GameObject nowCheckPoint;
    public static GameObject checkPointPrefab;
    //ColorFilter colorFilter;

    void Awake()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        normalSpeed = Time.timeScale;
        //colorFilter = GameObject.Find("ColorFilter").GetComponent<ColorFilter>();
        checkPointParent = GameObject.Find("CheckPoints");
    }

	// Use this for initialization
	void Start () {
        state = CONTROL.GAME;
	}

    public static void onSlow()
    {
        Time.timeScale = slowSpeed;
    }
    public static void offSlow()
    {
        Time.timeScale = normalSpeed;
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
        player.GetComponent<MoveScript>().ResumePlayerMovement();
    }
	
	// Update is called once per frame
	void Update () {
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
