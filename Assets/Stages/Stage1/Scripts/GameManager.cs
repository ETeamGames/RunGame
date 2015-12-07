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
    ColorFilter colorFilter;

    void Awake()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        normalSpeed = Time.timeScale;
        colorFilter = GameObject.Find("ColorFilter").GetComponent<ColorFilter>();
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
	
	// Update is called once per frame
	void Update () {
        //debug
        if (gameover)
        {
            Debug.Log("GameOver!!");
            playerCheckScript.continueCheckPoint();
        }

        //

        //タッチ入力あり（マルチタッチは最初の一つのみを対象）
        /*if (Input.touches != null && Input.touches.Length != 0)
        {
            playerScript.attack(Input.touches[0].position);
        }
        else if (Input.GetMouseButtonDown(0) && touchable)
        {
            touchDown = true;
            Time.timeScale = slowSpeed;
            colorFilter.filter = true;
            playerAnimator.SetBool("jump", true);
        }*/
        //デバッグ用（マウスイベント）
        /*else if (Input.GetMouseButtonUp(0) || !touchable)
        {    
            Time.timeScale = normalSpeed;
            if (touchable)
                playerScript.attack(cam.ScreenToWorldPoint(Input.mousePosition));

            touchDown = false;
            colorFilter.filter = false;
            playerAnimator.SetBool("jump", false);
        }*/
    }
}
