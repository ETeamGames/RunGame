using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ADVManager : MonoBehaviour {
    public GameObject[] scenes;
    public float fadeTime = 1;

    private bool endFlag = false;
    private Color colorBuffer;
    private Image imageBuffer;
    private float timeBuffer = 0;
    private GameObject nowDraw;
    private GameObject destroyObject;
    private Color endColor = new Color(0, 0, 0, 0);
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
        if (endFlag)
        {
            if (fadeTime == 0f) {
                imageBuffer.color = Color.black;
                timeBuffer = fadeTime;
            }
            else
            {
                imageBuffer.color = Color.Lerp(colorBuffer, endColor, 1f / fadeTime * timeBuffer);
                timeBuffer += Time.deltaTime;
            }
            if (timeBuffer >= fadeTime)
            {
                Application.LoadLevel("main");
            }
        }
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
        else if(!endFlag)
        {//ADVパートの終了処理
            endFlag = true;
            imageBuffer = nowDraw.transform.FindChild("Canvas").FindChild("waku").GetComponent<Image>();
            colorBuffer = imageBuffer.color;
        }
    }
}
