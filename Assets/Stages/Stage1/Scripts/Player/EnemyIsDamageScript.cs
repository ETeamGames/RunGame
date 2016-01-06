using UnityEngine;
using System.Collections;
using System;

public class EnemyIsDamageScript : IsDamageScript{
    public override void damageProc(DamageScript scr)
    {
        if (scr == null)
            return;
        hp -= scr.getDamage();
        if(hp < 1)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        if(!col.gameObject.tag.Equals("EnemyBullet"))
            base.OnCollisionEnter2D(col);
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.tag.Equals("EnemyBullet"))
            base.OnTriggerEnter2D(col);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
