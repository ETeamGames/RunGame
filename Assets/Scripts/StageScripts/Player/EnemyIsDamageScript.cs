using UnityEngine;
using System.Collections;
using System;

public class EnemyIsDamageScript : IsDamageScript
{
    private GameObject[] part;
    public Collider2D[] cc2d;
    public Animator animator;
    public MonoBehaviour script;
    public int score;
    private bool death;

    void Awake()
    {
        //子オブジェクトのキャッシュ作成
        part = new GameObject[transform.childCount];
        int n = 0;
        foreach(Transform child in transform)
        {
            part[n] = child.gameObject;
            n++;
        }
        death = false;
    }

    //子オブジェクトをバラバラにする
    public virtual void explosion()
    {
        if (script != null)
            script.enabled = true;
        if (cc2d != null)
        {
            foreach (Collider2D c in cc2d)
            {
                if(c != null)
                    c.enabled = false;
            }
        }
        if (animator != null)
            animator.enabled = false;
        foreach (GameObject c in part)
        {
            //c.GetComponent<CircleCollider2D>().enabled = true;
            float x = UnityEngine.Random.value - 0.5f;
            float y = UnityEngine.Random.value;
            Debug.Log("Ramdom x:" + x + " Ramdom y:" + y);
            c.GetComponent<Rigidbody2D>().velocity = new Vector2(x * 20f, y * 20f);
        }
    }

    public override void damageProc(DamageScript scr)
    {
        if (scr == null)
            return;
        hp -= scr.getDamage();
        if(hp < 1 & !death)
        {
            death = true;
            if (gameObject.GetComponent<KaboonScript>() != null)
            {
                gameObject.GetComponent<KaboonScript>().setKaboon();
            }
            //爆発アニメーション
            explosion();
            //スコアに追加
            GameManager.Score += score;
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
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
