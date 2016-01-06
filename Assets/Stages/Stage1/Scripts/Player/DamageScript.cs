using UnityEngine;
using System;
using System.Collections;

public class DamageScript : MonoBehaviour {
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected Animator anim;

    public int getDamage()
    {
        return damage;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(anim!=null)
                anim.SetTrigger("explosionTrigger");
            gameObject.GetComponent<EnemyMoveScript>().StopPlayerMovement();
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
