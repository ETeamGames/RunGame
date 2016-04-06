using UnityEngine;
using System.Collections;
using System;

public class TrapIsSwitchScript : Switchable
{
    public override void onSwitch()
    {
        GetComponent<TrapScript>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
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
