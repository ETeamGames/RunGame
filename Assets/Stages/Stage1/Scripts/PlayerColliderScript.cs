using UnityEngine;
using System.Collections;

public class PlayerColliderScript : MonoBehaviour
{

    public GameObject player;
    public Vector3 normalScale;

    void Awake()
    {
        player = GameObject.Find("Player");
        normalScale = player.transform.lossyScale;
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
