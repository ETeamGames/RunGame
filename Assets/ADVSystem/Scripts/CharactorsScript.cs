using UnityEngine;
using System.Collections;

public class CharactorsScript : MonoBehaviour {
    [Button("charaAdd", "Apply")]
    public int debug;
    public GameObject[] charactors;
    public float charaImagePosY;
    public RectTransform canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //inspector
    public void charaAdd()
    {
        Debug.Log("button clicked");
        charactors = new GameObject[transform.childCount];
        for(int n=0;n<transform.childCount;n++)
        {
            charactors[n] = transform.GetChild(n).gameObject;
            //charactors[n].GetComponent<CharaImgScript>().setPos(canvas.rect.width / (transform.childCount*2) * (2*n+1), charaImagePosY, 0);
        }
    }
}
