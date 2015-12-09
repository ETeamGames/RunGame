using UnityEngine;
using System.Collections;
using System;

public class CanonScript : Switchable {
    /// <summary>
    /// 発射する弾のプレハブ
    /// </summary>
    public GameObject bullet;
    /// <summary>
    /// 発射間隔
    /// </summary>
    public float deltaTime;
    /// <summary>
    /// 発射する弾数。-1 = 無限
    /// </summary>
    public int maxBullet;
    /// <summary>
    /// 弾速
    /// </summary>
    public float speed;
    private bool coroutineRunnable = false;

    private int bulletBuffer = 0;

    public override void onSwitch()
    {
        if (!coroutineRunnable)
        {
            StartCoroutine("shot");
            coroutineRunnable = true;
        }
    }
    private IEnumerator shot()
    {
        while (bulletBuffer < maxBullet)
        {
            GameObject go = (GameObject)Instantiate(bullet, transform.position-(new Vector3(0,0.8f,0)), bullet.transform.rotation);
            go.transform.parent = transform;
            Rigidbody2D rg = go.GetComponent<Rigidbody2D>();
            rg.gravityScale = 0;
            rg.velocity = (GameManager.playerScript.transform.position - transform.position).normalized * speed;
            bulletBuffer++;
            yield return new WaitForSeconds(deltaTime);
        }
        yield break;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
