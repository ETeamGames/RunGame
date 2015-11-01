using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class ADVScene : MonoBehaviour{
    public bool textAnim = true;
    public int textIndex = 1;
    public float timeBuffer = 0;
    public float charaImagePosY;
    //public ADVManager advManager;
    [Tooltip("一秒間に表示する文字数")]
    public float textDrawSpeed = 10;
    public Canvas canvas;
    public Text text;
    public Text charaName;
    public int index;
    public List<ADVElement> texts;

    private ADVManager advManager;

    public void init()
    {
        
        Debug.Log("init");
        index = 0;
        textIndex = 1;
        textAnim = false;
        drawText(true);
    }

    void Awake()
    {
        advManager = GameObject.Find("Manager").GetComponent<ADVManager>();
        charaName.text = texts[index].charaName;
        texts[index].start(canvas, charaImagePosY);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("タッチ<scaneManager>");
            if (textAnim)
            {
                Debug.Log("アニメーション省略<scaneManager>");
                textIndex = texts[index].text.Length + 1;
            }
            else
            {
                index++;
                if (index < texts.Count)
                {
                    texts[index].start(canvas, charaImagePosY);
                    texts[index-1].end();
                    drawText(true);
                }
                else
                {
                    advManager.nextScene();
                }
            }
        }
        drawText(false);
    }

    void drawText(bool touch)
    {
        if (touch)
        {
            charaName.text = texts[index].charaName;
            textAnim = true;
        }
        if (textAnim)
        {
            if (textIndex > texts[index].text.Length)
            {
                Debug.Log("クイック");
                text.text = texts[index].text;
                textAnim = false;
                textIndex = 0;
            }
            else
            {
                if (timeBuffer > (1f / textDrawSpeed))
                {
                    Debug.Log("アニメーション");
                    text.text = texts[index].text.Substring(0, textIndex);
                    textIndex++;
                    timeBuffer = 0;
                }
                timeBuffer += Time.deltaTime;
            }
        }
    }
}
