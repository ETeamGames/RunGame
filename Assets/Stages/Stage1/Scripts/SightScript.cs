using UnityEngine;
using System.Collections;

public class SightScript : MonoBehaviour
{
    /****************パブリック変数***************/
    [Header("プロパティ名にカーソルを置くと説明が表示されます")]
        [Tooltip("照準画像の大きさ")]
    public Vector3 sightScale = Vector3.one;

    [Tooltip("画像初期の大きさ")]
    public Vector3 sightScaleInit = Vector3.one;

    [Tooltip("縮小の時間")]
    public float scaleTime;

        [Tooltip("指を離した後、消滅するまでの時間(秒)")]
    public float sightDelTime;

        [Tooltip("回転速度　度/秒")]
    public float rotateSpeed;
        [Tooltip("エフェクト")]
    public GameObject effect;

    /****************プライベート変数*************/
    [Space(10)]
    [Header("ここより下のプロパティはデバッグ用です。変更しないでください")]

        [SerializeField, Tooltip("タッチしている間、照準をタッチ位置に移動させるためのフラグ")]
    private bool sightFlag;

        [SerializeField, Tooltip("単位時間当たりの減衰透明度量")]
    private float alphaAttenuation;

        [SerializeField, Tooltip("照準の位置")]
    private Vector3 sightPos;

        [SerializeField, Tooltip("消滅する間使用する色")]
    private Color col;

        [SerializeField, Tooltip("初期色")]
    private Color initCol;

        [SerializeField, Tooltip("初期角度")]
    private Quaternion initRot;

        [SerializeField, Tooltip("初期サイズ")]
    private Vector3 initScale;

    [SerializeField, Tooltip("差分スケール")]
    private Vector3 deltaScale;

    [SerializeField, Tooltip("差分スケール")]
    private float scaleTimeBuffer;

    [SerializeField, Tooltip("プレイヤー")]
    private GameObject player;

    
    private PlayerIsTrapScript piTrapScript;

    
    private Animator playerAnim;

    
    private PlayerScript playerScript;

    
    private MoveScript moveScript;

    [SerializeField]
    private SightLineScript[] effects;

    private bool flag = false;

    void Awake()
    {
    }

    // Use this for initialization
    void Start ()
    {
        player = GameManager.playerScript.gameObject;
        piTrapScript = player.GetComponent<PlayerIsTrapScript>();
        playerAnim = player.GetComponent<Animator>();
        playerScript = player.GetComponent<PlayerScript>();
        moveScript = player.GetComponent<MoveScript>();
        deltaScale = sightScaleInit - sightScale;
        deltaScale = deltaScale / scaleTime;
        transform.localScale = sightScaleInit;
        initCol = GetComponent<SpriteRenderer>().color;
        alphaAttenuation = initCol.a / sightDelTime;
        initRot = transform.rotation;

        effects = new SightLineScript[7];
        for (int n = 0; n < effects.Length; n++)
        {
           effects[n] = ((GameObject)Instantiate(effect, Vector3.zero, playerScript.transform.rotation)).GetComponent<SightLineScript>();
           effects[n].render.enabled = false;
        }
    }

    

	// Update is called once per frame
	void Update ()
    {
        if(InputManager.input.isInputDown() & !piTrapScript.isTrap)
        {
            if (!flag)
            {
                //タッチされた、かつトラップに掛かっていない
                scaleTimeBuffer = 0;
                GameManager.onSlow();
                GameManager.colorFilter.onFilter();
                GetComponent<SpriteRenderer>().color = initCol;
                GetComponent<SpriteRenderer>().enabled = true;
                transform.rotation = initRot;
                flag = true;
            }
            else
            {
                scaling();
                sightPos = GameManager.mainCamera.ScreenToWorldPoint(InputManager.input.getPosition());
                sightPos.z = 0;
                transform.position = sightPos;
                //テスト　回転を加え絵的にかっこよく
                transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
            }
        }
        else if (InputManager.input.isInputUp() | InputManager.emptyGageFlag | InputManager.guiFlag)
        {
            if (GetComponent<SpriteRenderer>().color.a > 0)
            {
                scaling();
                GameManager.offSlow();
                GameManager.colorFilter.offFilter();
                col = GetComponent<SpriteRenderer>().color;
                col.a -= alphaAttenuation * Time.deltaTime;
                GetComponent<SpriteRenderer>().color = col;

                //テスト　回転を加え絵的にかっこよく
                transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            flag = false;
        }

        /*if (InputManager.input.isInputDown() & !piTrapScript.isTrap)
        {
            transform.rotation = initRot;
            GetComponent<SpriteRenderer>().initcolor = ;Col
            GetComponent<SpriteRenderer>().enabled = true;
            moveScript.enabled = false;
            GameManager.onSlow();
            GameManager.colorFilter.onFilter();
            Debug.Log("タッチダウン!!");          
            if (sightFlag)
            {
                scaleTimeBuffer = 0;
                sightFlag = false;
            }
        }
        else if (InputManager.input.isInputUp() | piTrapScript.isTrap)
        {
            sightFlag = true;
            GameManager.offSlow();
            GameManager.colorFilter.offFilter();
            moveScript.enabled = true;
            Debug.Log("LineEffect Enabled");
            for (int n = 0; n < effects.Length; n++)
            {
                effects[n].render.enabled = false;
            }
        }
        if (sightFlag)
        {
            if (GetComponent<SpriteRenderer>().color.a >= 0)
            {
                col = GetComponent<SpriteRenderer>().color;
                col.a -= alphaAttenuation * Time.deltaTime;
                GetComponent<SpriteRenderer>().color = col;

                //テスト　回転を加え絵的にかっこよく
                scaling();
                transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = false;
                sightFlag = false;
            }
        }
        else
        {
            if (GetComponent<SpriteRenderer>().enabled)
            {
                scaling();
                sightPos = GameManager.mainCamera.ScreenToWorldPoint(InputManager.input.getPosition());
                sightPos.z = 0;
                transform.position = sightPos;
                //テスト　回転を加え絵的にかっこよく
                transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
            }
            if (InputManager.input.isInputDown())
            {
                int m = (int)(Vector3.Distance(playerScript.transform.position, transform.position) / 2f);
                for (int n = 0; n < effects.Length; n++)
                {
                    if (n < m)
                    {
                        effects[n].render.enabled = true;
                        effects[n].Proc(transform, transform.position, playerScript.transform.position, n, m);
                    }
                    else
                        effects[n].render.enabled = false;
                }
            }
        }*/
    }

    void scaling()
    {
        if (scaleTimeBuffer < scaleTime)
        {
            transform.localScale = sightScaleInit - deltaScale*scaleTimeBuffer;
            scaleTimeBuffer += (Time.deltaTime/GameManager.slowSpeed);
        }
        else
        {
            transform.localScale = sightScale;
            //scaleTimeBuffer = 0;
        }
    }

    //inspector
    private void OnValidate()
    {
        scaleTime = Mathf.Clamp(scaleTime,0.00000001f,float.MaxValue);
    }
}
