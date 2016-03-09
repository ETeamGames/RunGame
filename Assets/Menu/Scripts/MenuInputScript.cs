using UnityEngine;
using System.Collections;

public class MenuInputScript : MonoBehaviour
{
    private Ray ray;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        ray = Camera.main.ScreenPointToRay(InputManager.input.getPosition());
        RaycastHit hit = new RaycastHit();
        if(Physics.Raycast(ray,out hit))
        {
            if(hit.collider.gameObject.GetComponent<MenuHitScript>() != null)
                hit.collider.gameObject.GetComponent<MenuHitScript>().proc();
        }
	}
}
