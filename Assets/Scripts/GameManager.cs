using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public PlayerScript playerScript;
    public Camera cam;
    public float slowSpeed = 1.0f;
    public float normalSpeed = 0;
    public GameObject blueGage;
    public GameObject redGage;
    public float attenuation = 0.01f;
    public float increment = 0.05f;

    Vector2 gageScale;
    bool touchDown = false;
    bool touchable = true;
    ColorFilter colorFilter;

    void Awake()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        normalSpeed = Time.timeScale;
        blueGage = GameObject.Find("blueGage");
        redGage = GameObject.Find("redGage");
        gageScale = new Vector2();
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
        }
        if (touchDown)
        {
            gageProc(-1);
        }
        else
        {
            gageProc(1);
        }
    }

    void gageProc(float op)
    {
        gageScale.x = blueGage.transform.localScale.x;
        if (touchDown)
        {
            gageScale.x += op * Time.deltaTime * attenuation * redGage.transform.localScale.x * (1f / slowSpeed);
        }
        else
        {
            gageScale.x += op * Time.deltaTime * increment * redGage.transform.localScale.x;
        }
        gageScale.y = blueGage.transform.localScale.y;
        blueGage.transform.localScale = gageScale;
        if(blueGage.transform.localScale.x < 0)
        {
            blueGage.transform.localScale = new Vector2(0,blueGage.transform.localScale.y);
            touchable = false;
        }
        else if(blueGage.transform.localScale.x > redGage.transform.localScale.x)
        {
            blueGage.transform.localScale = new Vector2(redGage.transform.localScale.x, redGage.transform.localScale.y);
            touchable = true;
        }
    }
}
