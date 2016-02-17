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
        Destroy(GameManager.nowCheckPoint.GetComponent<CheckPointScript>().buffer.gameObject);
        GameObject temp = Instantiate(GameManager.checkPointPrefab);
        temp.transform.parent = GameManager.checkPointParent.transform;
        GameManager.nowCheckPoint.GetComponent<CheckPointScript>().buffer = temp;
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
