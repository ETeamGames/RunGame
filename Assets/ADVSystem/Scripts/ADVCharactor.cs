using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class ADVCharactor : MonoBehaviour{
    public Sprite[] right;
    public Sprite[] center;

    public void setPos(float x, float y, float z)
    {
        GetComponent<RectTransform>().position = new Vector3(x, y, z);
    }

    void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
