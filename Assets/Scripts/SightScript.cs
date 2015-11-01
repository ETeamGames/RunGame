using UnityEngine;
using System.Collections;

public class SightScript : MonoBehaviour {
    /****************パブリック変数***************/
    [Header("プロパティ名にカーソルを置くと説明が表示されます")]
        [Tooltip("照準画像の大きさ")]
    public Vector2 sightScale;

        [Tooltip("指を離した後、消滅するまでの時間(秒)")]
    public float sightDelTime;

    /****************プライベート変数*************/
    [Space(10)]
    [Header("ここより下のプロパティはデバッグ用です。変更しないでください")]
        [SerializeField,Tooltip("画面がタッチされたかtrue or false")]
    private bool touchDown = false;

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

        [SerializeField,Tooltip("ゲームマネージャ")]
    private GameManager gameManager;

    void Awake()
    {
        transform.localScale = sightScale;
        initCol = GetComponent<SpriteRenderer>().color;
        alphaAttenuation = initCol.a / sightDelTime;
        initRot = transform.rotation;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //デバッグ用（マウスイベント）
        if (Input.GetMouseButtonDown(0))
        {
            testTime = 0;

            transform.rotation = initRot;
            touchDown = true;
            GetComponent<SpriteRenderer>().color = initCol;
            GetComponent<SpriteRenderer>().enabled = true;
            if (sightFlag)
                sightFlag = false;
            //if (gameManager.touchable)
                //gameManager.touchable = false;

        }
        else if (Input.GetMouseButtonUp(0) || !gameManager.touchable)
        {
            touchDown = false;
            sightFlag = true;
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
                transform.Rotate(0, 0, Time.deltaTime * 100, Space.Self);
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
                transform.Rotate(0, 0, Time.deltaTime * 100, Space.Self);
            }
        }
    }

    void scaling()
    {
        if ((testTime += Time.deltaTime) < (1 * gameManager.slowSpeed))
        {
            transform.localScale = new Vector3(sightScale.x + (10 - (10 / 1 * (testTime / gameManager.slowSpeed))), sightScale.y + (10 - (10 / 1 * (testTime / gameManager.slowSpeed))), 0);
        }
        else
        {
            transform.localScale = sightScale;
        }
    }
    float testTime;
}
