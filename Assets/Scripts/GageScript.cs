using UnityEngine;
using System.Collections;

public class GageScript : MonoBehaviour {
    [Header("プロパティ名にカーソルを合わせると説明が表示されます")]
    [Tooltip("青いゲージ")]
    public GameObject blueGage;
    [Tooltip("赤いゲージ")]
    public GameObject redGage;
    [Tooltip("減衰量/秒")]
    public float attenuation;
    [Tooltip("回復量/秒")]
    public float increment;

    [Header("ここより下はデバッグ用のプロパティです")]
    [Header("変更しないでください")]
    [SerializeField,Tooltip("タッチされたか")]
    private bool touchDown = false;
    [SerializeField, Tooltip("回復用フラグandスロー解除用フラグ")]
    private GameManager touchable;
    [SerializeField, Tooltip("青ゲージ用縮尺")]
    private Vector2 gageScale = new Vector2();

    void Awake()
    {
        touchable = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && touchable.touchable)
        {
            touchDown = true;
        }
        //デバッグ用（マウスイベント）
        else if (Input.GetMouseButtonUp(0) || !touchable.touchable)
        {
            touchDown = false;
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
            gageScale.x += op * Time.deltaTime * attenuation * redGage.transform.localScale.x * (1f / touchable.slowSpeed);
        }
        else
        {
            gageScale.x += op * Time.deltaTime * increment * redGage.transform.localScale.x;
        }
        gageScale.y = blueGage.transform.localScale.y;
        blueGage.transform.localScale = gageScale;
        if (blueGage.transform.localScale.x < 0)
        {
            blueGage.transform.localScale = new Vector2(0, blueGage.transform.localScale.y);
            touchable.touchable = false;
        }
        else if (blueGage.transform.localScale.x > redGage.transform.localScale.x)
        {
            blueGage.transform.localScale = new Vector2(redGage.transform.localScale.x, redGage.transform.localScale.y);
            touchable.touchable = true;
        }
    }
}
