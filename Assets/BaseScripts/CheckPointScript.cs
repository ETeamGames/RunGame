using UnityEngine;
using System.Collections;

public class CheckPointScript : MonoBehaviour {
    public GameObject target;
    public GameObject buffer;
    public Animator anim;
    // Use this for initialization
    void Start () {
        anim = transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Vector3 getPos()
    {
        return transform.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Equals("Player"))
        {
            Debug.Log("チェックポイント通過!!");
            anim.SetBool("active" , true);
            GameManager.nowCheckPoint = gameObject;
            GameManager.checkPointPrefab = target;
        }
    }
}
