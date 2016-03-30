using UnityEngine;
using System.Collections;
public enum SWITCHFLAG
{
    ON,
    OFF,
    NON
}
public enum COLLISIONMODE
{
    COLLISION,
    TRIGGER,
    BOTH
}

public class switchScript : MonoBehaviour
{
	public SWITCHFLAG on;
    public COLLISIONMODE triggerMode;
    public Switchable[] list;
    public string targetTagName;
    public Animator anim;

	void Awake ()
    {
	}
	// Use this for initialization
	void Start ()
    {
		on = SWITCHFLAG.OFF;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (on == SWITCHFLAG.ON)
        {
            if (anim != null)
                anim.enabled = true;
            foreach (Switchable s in list)
            {
                if(s != null)
                    s.onSwitch();
            }
            on = SWITCHFLAG.NON;
        }
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == targetTagName & (triggerMode == COLLISIONMODE.TRIGGER | triggerMode == COLLISIONMODE.BOTH))
		{ 
			on = SWITCHFLAG.ON;
		}
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == targetTagName & (triggerMode == COLLISIONMODE.COLLISION | triggerMode == COLLISIONMODE.BOTH))
        {
            on = SWITCHFLAG.ON;
        }
    }

}
