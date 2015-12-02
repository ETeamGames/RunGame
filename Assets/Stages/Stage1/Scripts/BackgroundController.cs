using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
    public GameObject nextBackground;
    public SpriteRenderer spriteRender;
    static float scale = -1f;

    ColorFilter filter;
    Vector3 instansPos;


    void Awake()
    {
        //フィルターのキャッシュを作成
        filter = GameObject.Find("ColorFilter").GetComponent<ColorFilter>();
    }
    // Use this for initialization
    void Start () {
        GameObject go = (GameObject)Instantiate(nextBackground,Vector3.zero , transform.rotation);
        filter.sprite.AddLast(go.GetComponent<SpriteRenderer>());
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("<backgroundScript:OnTriggerEnter2D>" + col);
        if (col.gameObject.tag == "BackGround")
        {
            BoxCollider2D boxCol = col.gameObject.GetComponent<BoxCollider2D>();
            //Debug.Log("<backgroundScript:OnTriggerEnter2D:BackgroundControll_Enter>:" + collider2D.size.x);
            instansPos = new Vector3(col.gameObject.transform.position.x + Mathf.Abs(boxCol.size.x) * Mathf.Abs(col.gameObject.transform.localScale.x)
                                    , transform.position.y
                                    , 0);
            nextBackground.transform.localScale = new Vector3(-nextBackground.transform.localScale.x
                , nextBackground.transform.localScale.y
                , nextBackground.transform.localScale.z);
            GameObject go = (GameObject)Instantiate(nextBackground, instansPos, transform.rotation);
            filter.sprite.AddLast(go.GetComponent<SpriteRenderer>());
            scale *= -1;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "BackGround")
        {
            filter.sprite.Remove(col.gameObject.GetComponent<SpriteRenderer>());
            Destroy(col.gameObject);
        }
    }
}
