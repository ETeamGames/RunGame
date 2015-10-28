using UnityEngine;
using System.Collections;

public class staticObjectScript : MonoBehaviour {
    public float deleteTime = 2.0f;
    public float groundDeleteTime = 1.0f;

    public bool groundFlag = false;
    public bool activationFlag = false;
    public float speed = -3f;

    public Rigidbody2D rig;
    public float endScale = 0.0f;
    float totalTime = 0f;
    float groundTotalTime = 0f;
    public float scaleRate = 0f;
    Vector2 scale;

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.isKinematic = true;
        scaleRate = (transform.localScale.x - endScale) / groundDeleteTime;
        scale = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (activationFlag)//活性化
        {
            rig.isKinematic = false;
            if (groundFlag)//接地
            {
                if (groundTotalTime > groundDeleteTime)
                {
                    deleteObjct();
                }
                groundTotalTime += Time.deltaTime;
                scale.x -= scaleRate * Time.deltaTime;
                scale.y -= scaleRate * Time.deltaTime;
            }
            else if(totalTime > deleteTime)//時間切れ
            {
                deleteObjct();
            }
            transform.localScale = scale;
            totalTime += Time.deltaTime;
            transform.Translate(Time.deltaTime * speed, 0, 0, Space.World);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Road")
        {
            groundFlag = true;
        }
    }

    void deleteObjct()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        if (gameObject.transform.root.childCount <= 1)
        {//最後に一つならば、親も消去
            Destroy(transform.root.gameObject);
        }
    }
}
