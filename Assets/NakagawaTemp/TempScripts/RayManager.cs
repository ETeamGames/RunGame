using UnityEngine;
using System.Collections;

public class RayManager : MonoBehaviour {
	void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			Debug.Log (Input.mousePosition);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit))
			{
				GameObject obj = hit.collider.gameObject;
				if (obj.tag == "StageLinkBox") 
				{
					Debug.Log(obj.GetComponent<StageLinkBox>().nextStageName);
					if (obj.GetComponent<StageLinkBox> ().movable)
						Application.LoadLevel (obj.GetComponent<StageLinkBox>().nextStageName);
				}
			}
		}
	}
}
