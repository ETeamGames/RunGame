using UnityEngine;
using System.Collections;
public enum SWITCHFLAG
{
    ON,
    OFF,
    NON
}

public class switchScript : MonoBehaviour {
	public SWITCHFLAG on;
    public Switchable[] list;

	void Awake () {
	}
	// Use this for initialization
	void Start () {
		on = SWITCHFLAG.OFF;
	}
	
	// Update is called once per frame
	void Update () {
        if (on == SWITCHFLAG.ON)
        {
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
		if(col.gameObject.name == "Player")
		{ 
			on = SWITCHFLAG.ON;
		}
	}

}
