using UnityEngine;
using System.Collections;
using System;

public class PlayerIsTrapScript : IsTrapScript{
	[SerializeField]
	public bool isTrap; //false=掛かってない true=掛かってる
	
	public override void callAnimation(TrapScript trap)
	{
		trapScript = trap;
		timeBuffer = trapScript.EffectiveTime;
		isTrap = true;
		anim.SetBool(trap.TrapName, true);
	}
	
	void Awake()
	{
		anim = GetComponent<Animator>();
	}
	
	// Use this for initialization
	void Start ()
    {
		isTrap = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isTrap)
        {
            if (timeBuffer > 0)
            {
                timeBuffer -= Time.deltaTime;
            }
            else if (timeBuffer < 0)
            {
                isTrap = false;
                anim.SetBool(trapScript.TrapName, false);
                GetComponent<MoveScript>().ResumePlayerMovement();
            }
        }
	}
}
