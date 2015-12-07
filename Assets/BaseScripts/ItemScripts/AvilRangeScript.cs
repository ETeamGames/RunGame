using UnityEngine;
using System.Collections;
using System;

public class AvilRangeScript : ItemScript{
    [SerializeField]
    protected float changeTime;
    [SerializeField]
    protected float effectTime;
    [SerializeField]
    protected float scale;
    protected override void addEffect(GameObject gameObject)
    {
        ItemAvilScaleScript s = gameObject.transform.GetChild(0).gameObject.AddComponent<ItemAvilScaleScript>();
        s.changeTime = this.changeTime;
        s.effectTime = this.effectTime;
        s.scale = this.scale;
        //s.start();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<IsItemScript>() != null)
        {
            addEffect(col.gameObject);
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
