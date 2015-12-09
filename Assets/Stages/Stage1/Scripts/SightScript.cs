using UnityEngine;
using System.Collections;

public class SightScript : MonoBehaviour {
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

    /****************プライベート変数*************/
    [Space(10)]
    [Header("ここより下のプロパティはデバッグ用です。変更しないでください")]

        [SerializeField, Tooltip("タッチしている間、照準をタッチ位置に移動させるためのフラグ")]
    private bool sightFlag;

        [SerializeField, Tooltip("単位時間当たりの減衰透明度量")]
    private float alphaAttenuation;

        [SerializeField, Tooltip("タッチ位置をゲーム内位置に変換するためのカメラ")]
    private Camera cam;

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

    [SerializeField, Tooltip("ゲージスクリプト")]
    private GageScript gageScript;

    [SerializeField, Tooltip("プレイヤートラップスクリプト")]
    private PlayerIsTrapScript piTrapScript;

    [SerializeField, Tooltip("プレイヤーアニメーション")]
    private Animator playerAnim;

    [SerializeField, Tooltip("プレイヤースクリプト")]
    private PlayerScript playerScript;

    [SerializeField, Tooltip("プレイヤーmoveScript")]
    private MoveScript moveScript;

    [SerializeField, Tooltip("フィルター")]
    private ColorFilter colorFilter;

    void Awake()
    {
        deltaScale = sightScaleInit - sightScale;
        deltaScale = deltaScale / scaleTime;
        transform.localScale = sightScaleInit;
        initCol = GetComponent<SpriteRenderer>().color;
        alphaAttenuation = initCol.a / sightDelTime;
        initRot = transform.rotation;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.state != GameManager.CONTROL.GAME)//ゲーム時以外は入力を受け付けない
            return;
        if (InputScript.isInputDown() & !piTrapScript.isTrap & !gageScript.empty)
        {
            scaleTimeBuffer = 0;
            playerAnim.SetBool("jump", true);
            transform.rotation = initRot;
            GetComponent<SpriteRenderer>().color = initCol;
            GetComponent<SpriteRenderer>().enabled = true;
            gageScript.mode = -1;
            moveScript.enabled = false;
            GameManager.onSlow();
            colorFilter.onFilter();
            
            if (sightFlag)
            {
                sightFlag = false;
            }
        }
        else if (InputScript.isInputUp() | gageScript.empty | piTrapScript.isTrap)
        {
            InputScript.refresh();
            gageScript.mode = 1;
            if (!piTrapScript.isTrap & playerAnim.GetBool("jump"))
            {
                playerScript.attack(cam.ScreenToWorldPoint(InputScript.getInputUp()));
            }
            playerAnim.SetBool("jump", false);
            sightFlag = true;
            GameManager.offSlow();
            colorFilter.offFilter();
            moveScript.enabled = true;
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
                sightPos = cam.ScreenToWorldPoint(Input.mousePosition);
                sightPos.z = 0;
                transform.position = sightPos;
                //テスト　回転を加え絵的にかっこよく
                transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
            }
        }
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
