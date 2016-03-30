using UnityEngine;
using System.Collections;

/*  control player's movement */
public class PlayerAutoMovement : MonoBehaviour
{	
	/* a player's movement speed */
	public float speed = 4f;
	/*  the direction of the movement */
	public float direction = 1;// -1<-o->1
	public GameObject mainCamera;

	private Rigidbody2D rigidbody2D;
	private Animator animator;
	
	void Start ()
    {
		animator = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {

	}
	
	void FixedUpdate ()
    {
		// update a player and camera position based on the horizontal speed
		if (direction != 0) {
			rigidbody2D.velocity = new Vector2 (direction * speed, rigidbody2D.velocity.y);
			Vector2 temp = transform.localScale;
			temp.x = direction;
			transform.localScale = temp;
			animator.SetBool ("Dash", true);
			Vector3 cameraPos = mainCamera.transform.position;
			cameraPos.x = transform.position.x;
			mainCamera.transform.position = cameraPos;
			
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
			Vector2 pos = transform.position;
			// restrict coordinates of the position
			pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
			transform.position = pos;
		} else {
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
			animator.SetBool ("Dash", false);
		}
	}

	/*  */
	void OnTriggerEnter2D (Collider2D col)
    {
		if (col.gameObject.tag == "GOAL") {
			Debug.Log("Collision");
			direction = -1;
		}
	}
}