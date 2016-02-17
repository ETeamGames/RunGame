using UnityEngine;
using System.Collections;

public class CircleAnimScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public float rotateSpeed;
    public Color col;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	void FixedUpdate ()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.fixedDeltaTime, Space.Self);
	}
}
