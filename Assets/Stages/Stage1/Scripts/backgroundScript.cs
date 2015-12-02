using UnityEngine;
using System.Collections;

public class backgroundScript : MonoBehaviour {
    public float scrollSpeed = 0f;

    void Awake()
    {
        //nextBackground.GetComponent<backgroundScript>().scrollSpeed = scrollSpeed;
    }
	// Use this for initialization
	void Start () {
        //nextBackground = GameObject.Find("background");
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Time.deltaTime * scrollSpeed, 0, 0, Space.World);
	}
    
}
