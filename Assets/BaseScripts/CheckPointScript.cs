using UnityEngine;
using System.Collections;

public class CheckPointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
            col.GetComponent<IsCheckPointScript>().checkPoint = this;
        }
    }
}
