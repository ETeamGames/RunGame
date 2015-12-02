using UnityEngine;
using System.Collections;

public class staticGrupeScript : MonoBehaviour {
    public float speed = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Time.deltaTime * speed, 0, 0, Space.World);
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "DynamicObject")
        {
            Debug.Log("<staticGrupeScript:OnTriggerEnter2D>" + col.name);
            speed = 0;
            foreach(Transform child in transform)
            {
                //child.GetComponent<staticObjectScript>().rig.isKinematic = false;
                child.GetComponent < staticObjectScript > ().activationFlag = true;
            }
        }
    }
}
