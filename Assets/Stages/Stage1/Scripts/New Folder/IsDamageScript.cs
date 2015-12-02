using UnityEngine;
using System;
using System.Collections;

public abstract class IsDamageScript : MonoBehaviour {
    [SerializeField]
    protected int hp;

    public abstract void damageProc(DamageScript scr);

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        damageProc(col.gameObject.GetComponent<DamageScript>());
    }
    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        damageProc(col.gameObject.GetComponent<DamageScript>());
    }
}
