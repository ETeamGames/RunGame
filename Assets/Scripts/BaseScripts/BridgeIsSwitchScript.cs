using UnityEngine;
using System.Collections;
using System;

public class BridgeIsSwitchScript : Switchable
{
    public Animator targetAnimator;
    public override void onSwitch()
    {
        targetAnimator.enabled = true;
    }

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
