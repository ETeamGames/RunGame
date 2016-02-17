using UnityEngine;
using System.Collections;

public class outOfFieldScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnTriggerExit2D(Collider2D col)
    {
        //触れた物体を消去
        Debug.Log("<OutOfField:OnTriggerExit2D>" + col.gameObject.name);
        Destroy(col.gameObject);
    }
}
