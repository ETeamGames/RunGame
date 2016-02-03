using UnityEngine;
using System.Collections;

public class GhostPlayerScript : MonoBehaviour {
	[SerializeField]
	public GameObject target;

	// Use this for initialization
	void Start () {
		GetComponent<Transform>().position = target.GetComponent<Transform>().position;
		GetComponent<Rigidbody2D> ().velocity = target.GetComponent<MoveScript> ().Velocity;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void FixedUpdate () {
		GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x,target.GetComponent<Transform>().position.y);
		//Debug.Log ("GhostPlayer = "+GetComponent<Rigidbody2D>().velocity.x);
	}
}
