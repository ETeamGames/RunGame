using UnityEngine;
using System.Collections;

public class doorScript : MonoBehaviour {
	public bool openFlag;


	// Use this for initialization
	void Start () {
		openFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (openFlag)
			DoorOpened ();
	}

	void DoorOpened () {
		Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		// collision to the player
		if(col.gameObject.name == "Player")
		{ 
			Debug.Log ("collision to the player");
			openFlag = true;
		}
	}

	public void SetOpenFlag(){
		this.openFlag = true;
	}

}
