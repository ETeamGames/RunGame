using UnityEngine;
using System.Collections;
using System;

public class ElevatorSwitchScript : SwitchScript
{
    protected override void OnCollisionEnter2D(Collision2D col)
    {
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            foreach(Switchable s in target)
            {
                s.onSwitch();
                ((ElevatorScript)s).setPlayer(col.gameObject);
            }
            if(!on)
                col.GetComponent<MoveScript>().StopPlayerMovement();
            on = true;
        }
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
