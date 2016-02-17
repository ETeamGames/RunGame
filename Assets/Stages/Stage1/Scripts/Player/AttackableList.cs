using UnityEngine;
using System.Collections;

public class AttackableList : MonoBehaviour
{
    private AttackableList prev;
    private AttackableList next;

    public virtual void attack(Vector3 t_pos,float power)
    {
        if (next != null)
            next.attack(t_pos,power);
    }
    public void add()
    {
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

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
