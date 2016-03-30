using UnityEngine;
using System.Collections;

public class IsCheckPointScript : MonoBehaviour
{
    public PlayerIsDamageScript pidScript;

    public void continueCheckPoint()
    {
        GameManager.gameOver();
        pidScript.init();
        gameObject.GetComponent<PlayerScript>().init();
        if (GameObject.Find("Generator"))
            Debug.Log("Generator found");
        else
            Debug.Log("Generator not found");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
