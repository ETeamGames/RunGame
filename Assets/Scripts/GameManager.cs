﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public PlayerScript playerScript;
    public Animator playerAnimator;
    public Camera cam;
    public float slowSpeed = 1.0f;
    public float normalSpeed = 0;

    public bool touchDown = false;
    public bool touchable = true;
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
	
	}
	
	// Update is called once per frame
	void Update () {
        //タッチ入力あり（マルチタッチは最初の一つのみを対象）
        if (Input.touches != null && Input.touches.Length != 0)
        {
            playerScript.attack(Input.touches[0].position);
        }
        else if (Input.GetMouseButtonDown(0) && touchable)
        {
            touchDown = true;
            Time.timeScale = slowSpeed;
            colorFilter.filter = true;
            playerAnimator.SetBool("jump", true);
        }
        //デバッグ用（マウスイベント）
        else if (Input.GetMouseButtonUp(0) || !touchable)
        {    
            Debug.Log(cam.ScreenToWorldPoint(Input.mousePosition));
            Time.timeScale = normalSpeed;
            if (touchable)
                playerScript.attack(cam.ScreenToWorldPoint(Input.mousePosition));

            touchDown = false;
            colorFilter.filter = false;
            playerAnimator.SetBool("jump", false);
        }
    }
}
