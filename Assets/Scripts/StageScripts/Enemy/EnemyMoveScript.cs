using UnityEngine;
using System.Collections;

public class EnemyMoveScript : MoveScript
{
    public Animator anim;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        anim.SetTrigger("walkTrigger");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
