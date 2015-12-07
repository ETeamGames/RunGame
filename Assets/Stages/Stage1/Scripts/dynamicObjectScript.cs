using UnityEngine;
using System.Collections;

public class dynamicObjectScript : MonoBehaviour {
    public dynamicObjectDebug debugScript;
    public PlayerScript playerScript;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D objectRigidbody;
    void Awake()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        objectRigidbody = GetComponent<Rigidbody2D>();
        debugScript = GetComponent<dynamicObjectDebug>();
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frameameObject
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
    }
    void OnTriggerExit2D(Collider2D col)
    {

    }
}
