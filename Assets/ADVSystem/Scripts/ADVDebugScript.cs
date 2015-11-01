using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ADVDebugScript : MonoBehaviour {
    public ADVManager target;
    public Text sceneText;

	// Use this for initialization
	void Start () {
        //sceneText = GameObject.Find("sceneText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (target.scenes[target.index].transform.GetChild(0).GetComponent<ADVScene>() != null)
        {
            sceneText.text = target.index + 1 + " / " + target.scenes.Length + " - " + (target.scenes[target.index].transform.GetChild(0).GetComponent<ADVScene>().index+1) + " / " + target.scenes[target.index].transform.GetChild(0).GetComponent<ADVScene>().texts.Count;
        }
    }
}
