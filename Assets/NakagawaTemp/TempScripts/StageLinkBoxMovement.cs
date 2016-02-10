using UnityEngine;
using System.Collections;

public class StageLinkBoxMovement : MonoBehaviour {
	int count = 0;
	bool up = false;
	float y = 0.01f;
	public bool movable = false;

	void Update(){
		if (!movable) return;
		if (count == 30 && up) {
			up = false;
			count = 0;
		} else if (count == 30) {
			up = true;
			count = 0;
		}
		if (up) {
			gameObject.transform.position += new Vector3 (0, y, 0);
			count++;
		} else {
			gameObject.transform.position -= new Vector3 (0, y, 0);
			count++;
		}
	}
}
