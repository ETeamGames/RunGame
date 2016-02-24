using UnityEngine;
using System.Collections;

public class IsCheckPointScript : MonoBehaviour
{
    public PlayerIsDamageScript pidScript;

    public void continueCheckPoint()
    {
        GameManager.gameover = false;
        pidScript.init();
        gameObject.GetComponent<PlayerScript>().init();
        pidScript.transform.position = GameManager.nowCheckPoint.transform.position;
        Destroy(GameManager.nowCheckPoint);
        GameObject temp = Instantiate(GameManager.checkPointPrefab);
        if (GameObject.Find("Generator"))
            Debug.Log("Generator found");
        else
            Debug.Log("Generator not round");
        temp.transform.parent = GameObject.Find("Generator").transform;
        GameManager.nowCheckPoint = temp;
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
