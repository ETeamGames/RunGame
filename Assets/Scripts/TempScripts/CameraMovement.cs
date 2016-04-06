using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	// a distance to the player
	[SerializeField]
	public static float Z_DIST = -10;
	[SerializeField]
	public GameObject target;
	[SerializeField]
	private Vector3 cameraOffset;
	
	public Vector3 CameraOffset 
	{
		get { return cameraOffset; }
		set { cameraOffset = value; }
	}

	void FixedUpdate ()
	{
		GetComponent<Transform>().position = target.GetComponent<Transform>().position+CameraOffset;
		GetComponent<Transform> ().Translate (0,0,Z_DIST);
	}
}
