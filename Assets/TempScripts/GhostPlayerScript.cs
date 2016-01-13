using UnityEngine;
using System.Collections;

public class GhostPlayerScript : MonoBehaviour {
	[SerializeField]
	public GameObject target;
	// whether the player moves or not
	public bool moveOn = true;

	// Use this for initialization
	void Start () {
		GetComponent<Transform>().position = target.GetComponent<Transform>().position;
		GetComponent<Rigidbody2D> ().velocity = target.GetComponent<MoveScript> ().Velocity;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void FixedUpdate () {
		if (moveOn) {
			GetComponent<Rigidbody2D> ().velocity = target.GetComponent<MoveScript> ().Velocity;
			GetComponent<Transform> ().position = new Vector2 (GetComponent<Transform> ().position.x, target.GetComponent<Transform> ().position.y);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2(0,0);
			GetComponent<Transform> ().position = new Vector2 (GetComponent<Transform> ().position.x, target.GetComponent<Transform> ().position.y);
		}
		//Debug.Log ("GhostPlayer = "+GetComponent<Rigidbody2D>().velocity.x);
	}

	// stop the player's movement
	public void StopGhostPlayerMovement () {
		moveOn = false;
		Debug.Log ("call StopGhostPlayerMovement ()");
	}
	
	// resume the player's movement
	public void ResumeGhostPlayerMovement () {
		moveOn = true;
		Debug.Log ("call ResumeGhostPlayerMovement ()");
	}
}
