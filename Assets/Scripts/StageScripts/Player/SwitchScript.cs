using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class SwitchScript : MonoBehaviour
{
    [SerializeField]
    protected bool on;
    [SerializeField]
    protected Switchable[] target;

	// Use this for initialization
	void Start () {
        on = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected abstract void OnTriggerEnter2D(Collider2D col);
    protected abstract void OnCollisionEnter2D(Collision2D col);
}
