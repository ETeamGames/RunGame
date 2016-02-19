using UnityEngine;
using System.Collections;
using System;

public class doorScript : Switchable
{
    public Animator anim;
    public BoxCollider2D col;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public override void onSwitch()
    {
        anim.enabled = true;
        col.enabled = false;
    }
}
