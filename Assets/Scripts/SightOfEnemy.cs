using UnityEngine;
using System.Collections;

public class SightOfEnemy : MonoBehaviour {
	public float radiusSize = 10.0f;
	CircleCollider2D c;
	[SerializeField]GameObject enemyObject;

	// Use this for initialization
	void Start () {
		c = this.GetComponent<CircleCollider2D> ();
		if(c != null)
		{
			c.radius = radiusSize;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Update...");
		this.transform.position = enemyObject.transform.position;
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("OnTriggerEnter...");
		enemyObject.GetComponent<EnemyMoveScript> ().ResumePlayerMovement();
	}

	void OnTriggerStay2D(Collider2D other) {
		//Debug.Log ("OnTriggerStay...");
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("OnTriggerExit...");
		enemyObject.GetComponent<EnemyMoveScript> ().StopPlayerMovement();
	}
}
