using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public PlayerScript playerScript;
    public Animator playerAnimator;
    public Camera cam;
    public float slowSpeed = 1.0f;
    public float normalSpeed = 0;
    public GameObject blueGage;
    public GameObject redGage;
    public float attenuation = 0.01f;
    public float increment = 0.05f;
    public GameObject eim;
    public Vector2 eimScale;
    public float eimDelTime;
    public float alphaAttenuation;

    Vector2 gageScale;
    Vector3 eimPos;
    Color col;
    Color initCol;
    bool eimFlag;
    public bool touchDown = false;
    public bool touchable = true;
    ColorFilter colorFilter;

    void Awake()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        normalSpeed = Time.timeScale;
        blueGage = GameObject.Find("blueGage");
        redGage = GameObject.Find("redGage");
        gageScale = new Vector2();
        colorFilter = GameObject.Find("ColorFilter").GetComponent<ColorFilter>();
        eim.transform.localScale = eimScale;
        eimPos = new Vector3();
        eimFlag = false;
        alphaAttenuation = eim.GetComponent<SpriteRenderer>().color.a / eimDelTime;
        initCol = eim.GetComponent<SpriteRenderer>().color;
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
            eim.GetComponent<SpriteRenderer>().color = initCol;
            eim.GetComponent<SpriteRenderer>().enabled = true;
            if (eimFlag)
                eimFlag = false;
            
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
            eimFlag = true;
        }

        if (eimFlag)
        {
            if(eim.GetComponent<SpriteRenderer>().color.a >= 0)
            {
                col = eim.GetComponent<SpriteRenderer>().color;
                col.a -= alphaAttenuation * Time.deltaTime;
                eim.GetComponent<SpriteRenderer>().color = col;
            }
            else
            {
                eim.GetComponent<SpriteRenderer>().enabled = false;
                eimFlag = false;
            }
        }
        else
        {
            if (eim.GetComponent<SpriteRenderer>().enabled)
            {
                eimPos = cam.ScreenToWorldPoint(Input.mousePosition);
                eimPos.z = 0;
                eim.transform.position = eimPos;
            }
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
