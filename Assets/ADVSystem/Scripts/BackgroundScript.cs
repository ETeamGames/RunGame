using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundScript : MonoBehaviour {
    public Vector2 pivot;
    public Vector2 velocity;
    public Vector3 scale;
    public float angle;


	// Use this for initialization
	void Start () {
        GetComponent<Image>().material.mainTextureOffset = Vector2.zero;
        GetComponent<RectTransform>().pivot = pivot;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Image>().material.mainTextureOffset += velocity * Time.deltaTime; 
        GetComponent<RectTransform>().localScale += scale * Time.deltaTime;
        GetComponent<RectTransform>().Rotate(0, 0, angle * Time.deltaTime);
    }
}
