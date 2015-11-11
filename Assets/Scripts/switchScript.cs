using UnityEngine;
using System.Collections;

public class switchScript : MonoBehaviour {
	public bool On;
	public doorScript doorScr;

	void Awake () {
		doorScr = GameObject.Find("Door").GetComponent<doorScript>();
	}
	// Use this for initialization
	void Start () {
		On = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (On)
			doorScr.SetOpenFlag();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "dynamic")
		{ 
			On = true;
		}
	}

}
