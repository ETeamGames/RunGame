using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class MoveScript : MonoBehaviour {
	[SerializeField]
	private Rigidbody2D target;
	[SerializeField]
	private Vector3 velocity;
	// direction of the player's movement, should be given 1 or -1
	public float direction;
	private Vector2 myScale;
	// whether the player moves or not
	public bool moveOn = true;
	
	public Vector3 Velocity
	{
		get
		{
			return velocity;
		}
		set
		{
			this.velocity = value;
			target.velocity = value;
		}
	}
	void Awake()
	{
		
	}
	
	// Use this for initialization
	protected virtual void Start () {
		target.velocity = new Vector3(Velocity.x,target.velocity.y,0);
		myScale = transform.localScale;
	}
	
	void FixedUpdate()
	{
		if (moveOn) {
			target.velocity = new Vector3(Velocity.x*direction, target.velocity.y, 0);
			// update direction of the player
			myScale.x *= direction;
			transform.localScale = myScale;
		}
	}
	
	// Update is called once per frame
	void Update () {   
	}
	
	// stop the player's movement
	public void StopPlayerMovement () {
		moveOn = false;
		Debug.Log ("call StopPlayerMovement ()");
	}
	
	// resume the player's movement
	public void ResumePlayerMovement () {
		moveOn = true;
		Debug.Log ("call ResumePlayerMovement ()");
	}
	
	// use this when the player get to the Goal
	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Goal") {
			Debug.Log("Collision Goal");
			direction = -1;
		}
		// use for test
		if (col.gameObject.tag == "Test") {
			Debug.Log("Collision Test Object.");
		}
	}
}
