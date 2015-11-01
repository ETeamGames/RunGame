using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ADVCharactorEffect : MonoBehaviour {
    public enum TIMMING
    {
        START,
        NON,
        END
    }
    public TIMMING startFlag = TIMMING.NON;
    public float effectTime = 0;
    public Vector4 diffColor;
    public Color color;
    public Vector4 endColor;
    public float timeBuffer = 0;

	// Use this for initialization
	void Start () {
    }

    public void init()
    {
        Vector4 col = new Vector4(
            GetComponent<Image>().color.r,
            GetComponent<Image>().color.g,
            GetComponent<Image>().color.b,
            GetComponent<Image>().color.a
            );
        diffColor = (col - endColor) / effectTime;
        Debug.Log("ADVCharactorEffect : DiffColor :" + diffColor);
    }
	
	// Update is called once per frame
	void Update () {
	    if((startFlag==TIMMING.START || startFlag == TIMMING.END) && timeBuffer < effectTime)
        {
            Debug.Log("ADVCharactorEffect : Update timeBuffer : "+timeBuffer);
            color.r = diffColor.x * Time.deltaTime;
            color.g = diffColor.y * Time.deltaTime;
            color.b = diffColor.z * Time.deltaTime;
            color.a = diffColor.w * Time.deltaTime;
            GetComponent<Image>().color -= color;
            timeBuffer += Time.deltaTime;
        }
        else if(timeBuffer >= effectTime)
        {
            if(startFlag == TIMMING.END)
            {
                Destroy(gameObject);
            }
            startFlag = TIMMING.NON;
            timeBuffer = 0;
        }
	}
}
