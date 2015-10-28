using UnityEngine;
using System.Collections;

public class dynamicObjectDebug : MonoBehaviour {

    public float initVelosityX = 0.0f;
    public float initVelosityY = 0.0f;
    public float initPowerX = 0.0f;
    public float initPowerY = 0.0f;
    public bool debug = true;
    //public bool debug = true;
    void Awake()
    {
    }

	// Use this for initialization
	void Start () {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(initVelosityX, initVelosityY);
	}
	
	// Update is called once per frame
	void Update () {
        if (debug)
            transform.Translate(initVelosityX * Time.deltaTime, initVelosityY * Time.deltaTime, 0f, Space.World);
	}
   void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Road")
        {
            debug = true;
        }
    }
}
