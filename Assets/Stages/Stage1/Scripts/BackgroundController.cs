using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
    public GameObject nextBackground;
    public SpriteRenderer spriteRender;

    ColorFilter filter;
    Vector3 instansPos;


    void Awake()
    {
    }
    // Use this for initialization
    void Start () {
        Instantiate(nextBackground,Vector3.zero , transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
       
    }
    void OnTriggerExit2D(Collider2D col)
    {

    }
}
