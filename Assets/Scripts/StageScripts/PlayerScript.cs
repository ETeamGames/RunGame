using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    [Header("プロパティ名にカーソルを合わせると、説明が表示されます")]
    [Tooltip("物体を飛ばす力")]
    public float power;

    public SpriteRenderer sight;
    public Vector3 cameraOffset;

    public GameObject colliderBuffer;
    public GameObject colliderPrefab;

    [Header("ここより下はデバッグ用の表示です")]
    [Header("変更を加えないでください")]
    [Tooltip("飛ばす物体のリスト")]
    public AttackableList end;
    public AttackableList first;
    public Vector3 pos;
    private MoveScript moveScript;
    private bool attackFlag = false;

    //攻撃可能物体を座標に飛ばす
    public void attack(Vector3 vec)
    {
        if(first != null)
            first.attack(vec, power);
    }

    public void init()
    {
        Destroy(colliderBuffer);
        colliderBuffer = Instantiate(colliderPrefab);
    }

	// Use this for initialization
	void Start ()
    {
        moveScript = GetComponent<MoveScript>();
	}
	void FixedUpdate ()
    {
        colliderBuffer.transform.position = transform.position;
	}
    void Update()
    {
        if (InputManager.input.isInputDown())//入力あり
        {
            GageScript.mode = GageScript.GAGE_STATE.ATTENUATION;
            GetComponent<Animator>().SetBool("jump", true);
            moveScript.enabled = false;
            attackFlag = true;
        }
        else if ((InputManager.input.isInputUp() | InputManager.emptyGageFlag) & attackFlag)//入力解除
        {
            GageScript.mode = GageScript.GAGE_STATE.INCREMENT;
            GetComponent<Animator>().SetBool("jump", false);
            moveScript.enabled = true;
            attack(GameManager.mainCamera.ScreenToWorldPoint(InputManager.input.getUpPosition()));
            attackFlag = false;
        }
        else
        {
            GetComponent<Animator>().SetBool("jump", false);
        }
        GameManager.mainCamera.transform.position = (new Vector3(transform.position.x, transform.position.y, -10))+cameraOffset;
    }
}
