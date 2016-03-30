using UnityEngine;
using System;
using System.Collections;

public class DamageScript : MonoBehaviour
{
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected Animator anim;
    protected EnemyMoveScript e;

    public int getDamage()
    {
        return damage;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (anim != null)
            {
                anim.SetTrigger("explosionTrigger");
            }
            if(e != null)
                gameObject.GetComponent<EnemyMoveScript>().StopPlayerMovement();
        }
    }

	// Use this for initialization
	protected virtual void Start ()
    {
        e = gameObject.GetComponent<EnemyMoveScript>();
    }
	
	// Update is called once per frame
	protected virtual void Update()
    {
    }
}
