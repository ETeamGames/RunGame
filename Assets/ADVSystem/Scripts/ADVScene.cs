using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class ADVScene : MonoBehaviour{
    public enum EFFECTFLAG
    {
        START,
        END,
        NON,
    }

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

    [SerializeField]
    private ADVBackground[] backgrounds;
    private EFFECTFLAG effectFlag;
    private ADVManager advManager;
    private bool effectAllFlag;

    public void init()
    {
        
        Debug.Log("init");
        index = 0;
        textIndex = 1;
        textAnim = false;
        drawText(true);

        //エフェクト初期化
        for(int n = 0; n < backgrounds.Length; n++)
        {
            backgrounds[n].End.init(backgrounds[n].background);
            backgrounds[n].Start.init(backgrounds[n].background);
            for (int m = 0; m < backgrounds[n].normal.Length; m++)
            {
                backgrounds[n].normal[m].init(backgrounds[n].Start.effectColor);
            }
        }
        effectAllFlag = false;
        effectFlag = EFFECTFLAG.START;
    }

    void Awake()
    {
        advManager = GameObject.Find("Manager").GetComponent<ADVManager>();
        charaName.text = texts[index].charaName;
        texts[index].start(canvas, charaImagePosY);
    }

    void Start()
    {
        effectFlag = EFFECTFLAG.START;
        if (textAnim)
        {
            init();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (effectFlag == EFFECTFLAG.START)
        {
            foreach(ADVBackground g in backgrounds) {
                effectAllFlag = g.Start.proc(Time.deltaTime,g.background);
            }
            if (effectAllFlag)
            {
                effectFlag = EFFECTFLAG.NON;
                effectAllFlag = false;
            }
        }
        else if(effectFlag == EFFECTFLAG.NON)
        {
            foreach (ADVBackground g in backgrounds)
            {
                foreach (ADVEffect e in g.normal)
                {
                    e.proc(Time.deltaTime, g.background,g.background);
                }
            }
        }
        else if(effectFlag == EFFECTFLAG.END)
        {
            foreach (ADVBackground g in backgrounds)
            {
                effectAllFlag = g.End.proc(Time.deltaTime, g.background,g.background);
            }
            if (effectAllFlag)
            {
                advManager.nextScene();
            }
        }

        if (Input.GetMouseButtonDown(0) && effectFlag != EFFECTFLAG.END)
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
                    texts[index-1].end();
                    effectFlag = EFFECTFLAG.END;
                    //advManager.nextScene();
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
                //Debug.Log("クイック");
                text.text = texts[index].text;
                textAnim = false;
                textIndex = 0;
            }
            else
            {
                if (timeBuffer > (1f / textDrawSpeed))
                {
                    //Debug.Log("アニメーション");
                    text.text = texts[index].text.Substring(0, textIndex);
                    textIndex++;
                    timeBuffer = 0;
                }
                timeBuffer += Time.deltaTime;
            }
        }
    }
}
