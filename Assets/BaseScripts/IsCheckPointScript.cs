using UnityEngine;
using System.Collections;

public class IsCheckPointScript : MonoBehaviour {
    public CheckPointScript checkPoint;
    public PlayerIsDamageScript pidScript;

    public void continueCheckPoint()
    {
        GameManager.gameover = false;
        pidScript.init();
        gameObject.transform.position = checkPoint.transform.position;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
