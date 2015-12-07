using UnityEngine;
using System.Collections;
using System;

public class PlayerIsDamageScript : IsDamageScript {
    public override void damageProc(DamageScript scr)
    {
        if (scr == null)
            return;
        hp -= scr.getDamage();
        if(hp < 1)
        {
            GameManager.gameover = true;
        }
    }
    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.tag.Equals("DynamicObject")) { 
            base.OnTriggerEnter2D(col);
        }
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
