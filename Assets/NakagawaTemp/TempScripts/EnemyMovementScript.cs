using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class EnemyMovementScript : MonoBehaviour {
	[SerializeField]
	private Rigidbody2D target;
	[SerializeField]
	private Vector3 velocity;
	// direction of the player's movement, should be given 1 or -1
	public float direction;
	private Vector2 myScale;
	// whether the player moves or not
	public bool moveOn = true;
	// use for player and camera movement
	public Vector3 nextVector;
	
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
	
	// Use this for initialization
	void Start () 
	{
		myScale = transform.localScale;
	}
	
	void FixedUpdate() 
	{
		nextVector = new Vector3 (Velocity.x * direction, target.velocity.y, 0);
		if (moveOn) 
		{
			// update direction of the player
			myScale.x *= direction;
			transform.localScale = myScale;
			target.velocity = nextVector;
		}
	}
}
