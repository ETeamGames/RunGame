using UnityEngine;
using System.Collections;

public class ADVManager : MonoBehaviour {
    public GameObject[] scenes;

    private GameObject nowDraw;
    private GameObject destroyObject;
    public int index{private set;get;}
    // Use this for initialization
    void Start () {
        index = 0;
        nowDraw = (GameObject)Instantiate(scenes[index], transform.position, transform.rotation);
        nowDraw.transform.FindChild("ScaneManager").GetComponent<ADVScene>().init();
        nowDraw.transform.FindChild("Canvas").GetComponent<Canvas>().enabled = true;
        nowDraw.transform.FindChild("ScaneManager").GetComponent<ADVScene>().enabled = true;

        nowDraw.transform.parent = transform;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void nextScene()
    {
        if (index < scenes.Length-1)
        {
            index++;
            destroyObject = nowDraw;
            scenes[index].transform.FindChild("ScaneManager").GetComponent<ADVScene>().init();
            scenes[index].transform.FindChild("Canvas").GetComponent<Canvas>().enabled = true;
            scenes[index].transform.FindChild("ScaneManager").GetComponent<ADVScene>().enabled = true;
            nowDraw = (GameObject)Instantiate(scenes[index], transform.position, transform.rotation);
            nowDraw.transform.parent = transform;
            Destroy(destroyObject);
        }
        else
        {//ADVパートの終了処理
            Application.LoadLevel("main");
        }
    }
}
