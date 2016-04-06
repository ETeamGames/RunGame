using UnityEngine;
using System.Collections;

public class PlayerForDebug : MonoBehaviour {

	public float speed = 4f;
	public GameObject mainCamera;
	private Rigidbody2D rigidbody2D;
	private Animator anim;
	private Vector3 defaultScale;

	void Start () 
	{
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		defaultScale = gameObject.transform.localScale;
	}

	void FixedUpdate ()
	{
		float x = Input.GetAxisRaw ("Horizontal");
		if (x != 0) 
		{
			rigidbody2D.velocity = new Vector2 (x * speed, rigidbody2D.velocity.y);
			Vector2 temp = transform.localScale;
			if( x < 0 && temp.x > 0)temp.x *= x;
			else if(x > 0 && temp.x < 0)temp.x *= -x;
			transform.localScale = temp;
			//anim.SetBool ("run", true);
			if (transform.position.x > mainCamera.transform.position.x - 4) 
			{
				Vector3 cameraPos = mainCamera.transform.position;
				cameraPos.x = transform.position.x + 4;
				mainCamera.transform.position = cameraPos;
			}
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
			Vector2 pos = transform.position;
			pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
			transform.position = pos;
		} else {
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
			//anim.SetBool ("run", false);
		}
	}
}