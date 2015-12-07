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

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
