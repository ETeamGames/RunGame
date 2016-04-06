using UnityEngine;
using System.Collections;

public class AttackableList : MonoBehaviour
{
    private AttackableList prev;
    private AttackableList next;

    public virtual void attack(Vector3 t_pos,float power)
    {
        unroop();
        if (next != null)
            next.attack(t_pos,power);
    }
    public void add()
    {
        unroop();
        if (GameManager.playerScript.first == null && GameManager.playerScript.end == null)
        {
            GameManager.playerScript.first = this;
            GameManager.playerScript.end = this;
        }
        else
        {
            prev = GameManager.playerScript.end;
            GameManager.playerScript.end.next = this;
            GameManager.playerScript.end = this;
        }
    }
    public void remove()
    {
        unroop();
        if (prev == null && next == null)
        {
            GameManager.playerScript.first = null;
            GameManager.playerScript.end = null;
        }
        if (prev != null)
            prev.next = next;
        if (next != null)
            next.prev = prev;
    }

    public void unroop()
    {
        if (next != null && next.Equals(this))
            next = null;
        if (prev != null && prev.Equals(this))
            prev = null;
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
