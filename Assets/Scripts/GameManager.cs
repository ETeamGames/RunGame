using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public PlayerScript playerScript;
    public Camera cam;
    public float slowSpeed = 1.0f;
    public float normalSpeed = 0;

    void Awake()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        //cam = GameObject.Find("MainCamera").GetComponent<Camera>();
        normalSpeed = Time.timeScale;
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
        else if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = slowSpeed;
        }
        //デバッグ用（マウスイベント）
        else if (Input.GetMouseButtonUp(0))
        {    
            Debug.Log(cam.ScreenToWorldPoint(Input.mousePosition));
            Time.timeScale = normalSpeed;
            playerScript.attack(cam.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
