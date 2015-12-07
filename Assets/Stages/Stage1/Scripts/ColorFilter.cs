using UnityEngine;
using System.Collections.Generic;

public class ColorFilter : MonoBehaviour {
    public SpriteRenderer filter;
    public Color filterColor;

    public void onFilter()
    {
        filter.enabled = true;
    }
    public void offFilter()
    {
        filter.enabled = false;
    }
    void Awake()
    {
        filter.color = filterColor;
    }

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
    }
}
