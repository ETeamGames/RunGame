using UnityEngine;
using System.Collections;
using System;

public class doorScript : Switchable
{
    public Animator anim;

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
    }
}
