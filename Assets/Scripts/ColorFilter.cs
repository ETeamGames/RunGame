using UnityEngine;
using System.Collections.Generic;

public class ColorFilter : MonoBehaviour {
    public LinkedList<SpriteRenderer> sprite;
    public bool filter = false;
    public Color filterColor;

    bool one = false;

    void Awake()
    {
        sprite = new LinkedList<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (filter && !one)
        {
            foreach(SpriteRenderer s in sprite)
            {
                if (s == null || s.color == null || filterColor == null)
                {

                }
                else
                {
                    s.color = filterColor;
                }
            }
            one = true;
        }
        else if(!filter && one)
        {
            foreach (SpriteRenderer s in sprite)
            {
                if (s != null && s.color != null)
                {
                    s.color = Color.white;
                }
            }
            one = false;
        }
	}
}
