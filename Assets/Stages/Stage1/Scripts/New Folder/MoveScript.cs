using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class MoveScript : MonoBehaviour {
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Rigidbody2D target;
    [SerializeField]
    private Vector3 velocity;
    [SerializeField]
    private Vector3 cameraOffset;
    [SerializeField]
    private int camMoveDelay;

    public Vector3 CameraOffset
    {
        get
        {
            return cameraOffset;
        }
        set
        {
            cameraOffset = value;
        }
    }

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
	void Start () {
        target.velocity = new Vector3(Velocity.x,target.velocity.y,0);
    }

    void FixedUpdate()
    {
        target.velocity = new Vector3(Velocity.x, target.velocity.y, 0);
    }

	// Update is called once per frame
	void Update () {
        if(cam != null)
        {
            cam.transform.position = (new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10)) +cameraOffset;
        }
    }
}
