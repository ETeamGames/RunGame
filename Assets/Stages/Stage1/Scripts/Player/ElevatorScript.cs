using UnityEngine;
using System;
using System.Collections;

public class ElevatorScript : Switchable{
    public GameObject player;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float time;
    [SerializeField]
    private bool flag;

    private float timeBuffer;
    private Vector3 delta;

    public override void onSwitch()
    {
        flag = true;
        timeBuffer = 0;
    }

	// Use this for initialization
	void Start () {
        flag = false;
        if (offset.x != 0)
            delta.x = (offset.x - transform.position.x) / time;
        if(offset.y != 0)
            delta.y = (offset.y - transform.position.y) / time;
        if(offset.z != 0)
            delta.z = (offset.z - transform.position.z) / time;
	}

    void FixedUpdate()
    {
        if (flag && timeBuffer < time)
        {
            transform.position += delta * Time.fixedDeltaTime;
            timeBuffer += Time.fixedDeltaTime;
        }
        else if(timeBuffer >= time)
        {
            player.GetComponent<MoveScript>().ResumePlayerMovement();
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
