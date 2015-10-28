using UnityEngine;
using System.Collections;

public class PlayerColliderScript : MonoBehaviour {

    public GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
	}
}
