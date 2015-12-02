using UnityEngine;
using System.Collections;
using System;

public class PlayerIsTrapScript : IsTrapScript{

    public override void callAnimation(TrapScript trap)
    {
        trapScript = trap;
        timeBuffer = trapScript.EffectiveTime;
        anim.SetBool(trap.TrapName, true);
        if (trap.TrapName.Equals("thunderTrap"))
        {
            GameManager.touchable = false;
            GetComponent<MoveScript>().enabled = false;
        }
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (timeBuffer > 0)
        {
            timeBuffer -= Time.deltaTime;
        }
        else if(timeBuffer < 0)
        {
            anim.SetBool(trapScript.TrapName, false);
            GameManager.touchable = true;
            GetComponent<MoveScript>().enabled = true;
        }
	}
}
