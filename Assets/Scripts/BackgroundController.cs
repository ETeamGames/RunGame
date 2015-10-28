using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
    public GameObject nextBackground;
    static float scale = -1f;
    Vector3 instansPos;
    void Awake()
    {
    }
    // Use this for initialization
    void Start () {
	
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
            Instantiate(nextBackground, instansPos, transform.rotation);
            scale *= -1;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "BackGround")
        {
            Destroy(col.gameObject);
        }
    }
}
