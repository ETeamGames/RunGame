using UnityEngine;
using System.Collections;

public class ShootingScript : AttackableList {
    private SpriteRenderer s_render;
    private Rigidbody2D rigidBody;
    public SpriteRenderer S_render
    {
        get
        {
            return s_render ?? (s_render = GetComponent<SpriteRenderer>());
        }
    }
    public Rigidbody2D RigidBody
    {
        get
        {
            return rigidBody ?? (rigidBody = GetComponent<Rigidbody2D>());
        }
    }
    public override void attack(Vector3 t_pos,float power)
    {
        Vector2 direction = t_pos - transform.position;
        RigidBody.gravityScale = 0;
        RigidBody.velocity= direction.normalized * power;
        base.attack(t_pos,power);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("PlayerCollider"))
        {
            S_render.color = new Color(1, 0, 0, 1);
            add();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("PlayerCollider"))
        {
            S_render.color = new Color(1, 1, 1, 1);
            remove();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        RigidBody.gravityScale = 3;
    }
}
