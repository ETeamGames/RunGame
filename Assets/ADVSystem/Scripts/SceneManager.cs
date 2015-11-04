using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor;

/*[ExecuteInEditMode]
[System.Serializable]
public class ScenarioText
{
    public  string charaName;
    [TextArea]
    public  string text;
};*/

[System.Serializable]
public class ScenarioBackground
{
    public Image img;
    public RectTransform rectTrans;
    public Vector2 velocity;
    public void draw(float time)
    {

    }
};

[ExecuteInEditMode]
//[RequireComponent(typeof(SceneManager))]
public class SceneManager : MonoBehaviour
{
    public bool textAnim = false;
    public int textIndex = 1;
    public float timeBuffer = 0;
    public ADVManager advManager;
    [Tooltip("一秒間に表示する文字数")]
    public float textDrawSpeed = 10;
    public Text text;
    public Text charaName;
    [HideInInspector]
    public ScenarioElement[] scenario;
    public bool endFlag = false;
    public Canvas canvas;

    [SerializeField]
    private int index;

    void Awake()
    {
        advManager = GameObject.Find("Manager").GetComponent<ADVManager>();
    }

    // Use this for initialization
    void Start()
    {
    }

    public void init()
    {
        Debug.Log("init");
        index = 0;
        endFlag = false;
        textIndex = 1;
        textAnim = false;
        drawText(true);
    }

    // Update is called once per frame
    void Update()
    {
        //背景画像処理


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("タッチ<scaneManager>");
            if (textAnim)
            {
                Debug.Log("アニメーション省略<scaneManager>");
                textIndex = scenario[index].text.Length + 1;
            }
            else
            {
                index++;
                if (index < scenario.Length)
                {
                    drawText(true);
                }
                else
                {
                    endFlag = true;
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
            charaName.text = scenario[index].charaName;
            textAnim = true;
        }
        if (textAnim)
        {
            if (textIndex > scenario[index].text.Length)
            {
                Debug.Log("クイック");
                text.text = scenario[index].text;
                textAnim = false;
                textIndex = 0;
            }
            else
            {
                if (timeBuffer > (1f / textDrawSpeed))
                {
                    Debug.Log("アニメーション");
                    text.text = scenario[index].text.Substring(0, textIndex);
                    textIndex++;
                    timeBuffer = 0;
                }
                timeBuffer += Time.deltaTime;
            }
        }
    }

    public void add()
    {
        //EditorWindow.GetWindow<ScenarioEditorWindow>("ScenarioEditor");
        //scenario.Add(new ScenarioText());
        //Debug.Log("Scenario:" + scenario.Count);
    }
    public void del(ScenarioElement t)
    {
        //scenario.Remove(t);
    }
    public void delAll()
    {
        //scenario.Clear();
        //Debug.Log("Scenario:" + scenario.Count);
    }
}
