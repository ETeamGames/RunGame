using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class ADVEffect{
    private Image img;

    [Tooltip("エフェクトの時間")]
    public float effectTime;

    public bool colorEnable;
    public bool hsv;
    public int countH = 1;
    [Range(0f, 1f)]
    public float deltaColorH;
    [Range(0f, 1f)]
    public float h = 0;
    public int countS = 1;
    [Range(0f, 1f)]
    public float deltaColorS;
    [Range(0f, 1f)]
    public float s = 0;
    public int countV = 1;
    [Range(0f, 1f)]
    public float deltaColorV;
    [Range(0f, 1f)]
    public float v = 0;
    [Tooltip("エフェクト後の色")]
    public Color effectColor;

    public bool scaleEnable;
    [Tooltip("スケール")]
    public Vector3 scale;

    public bool positionEnable;
    [Tooltip("位置")]
    public Vector3 position;

    public bool rotateEnable;
    [Tooltip("回転")]
    public float angle;

    public bool roop = false;

    private Vector3 initPosition;
    private Vector3 initScale;
    [SerializeField]
    private Color initColor;
    private float timeBuffer;
    private bool endFlag = false;

    public void init(GameObject target)
    {
        effectTime = Mathf.Clamp(effectTime, 0.0001f, float.MaxValue);
        float a, b;
        this.init(target.GetComponent<Image>().color);
        UnityEditor.EditorGUIUtility.RGBToHSV(initColor, out h, out a, out b);
        initPosition = target.GetComponent<RectTransform>().position;
        initScale = target.GetComponent<RectTransform>().localScale;
        timeBuffer = 0;
    }
    public void init(Color col)
    {
        initColor = col;
    }

    public bool proc(float deltaTime, GameObject target,GameObject init)
    {
        if (!endFlag)
        {
            this.init(init);
            endFlag = true;
        }
        return proc(deltaTime,target);
    }

    public bool proc(float deltaTime,GameObject target)
    {
        if (colorEnable && !hsv)
        {
            //色
            target.GetComponent<Image>().color = Color.Lerp(initColor, effectColor, Mathf.Clamp((1f / effectTime * timeBuffer),0,1f));
        }
        else if(colorEnable && hsv)
        {

            //色
            if (countH != 0)
            {
                if (h >= 1f)
                {
                    if (countH != 1 || countH < 0)
                    {
                        h = 0;
                    }
                    if (countH > 0)
                    {
                        countH--;
                    }
                }
                else
                {
                    h += deltaColorH * deltaTime;
                    h = Mathf.Clamp(h, 0, 1f);
                }
            }
            if (countS != 0)
            {
                if (s > 1f)
                {
                    if (countS != 1 || countS < 0)
                    {
                        s = 0;
                    }
                    if (countS > 0)
                    {
                        countS--;
                    }
                }
                else
                {
                    s += deltaColorS * deltaTime;
                    s = Mathf.Clamp(s, 0, 1f);
                }
            }
            if (countV != 0)
            {
                if (v > 1f)
                {
                    if (countV != 1 || countV < 0)
                    {
                        v = 0;
                    }
                    if (countV > 0)
                    {
                        countV--;
                    }
                }
                else
                {
                    v += deltaColorV * deltaTime;
                    v = Mathf.Clamp(v, 0, 1f);
                }
            }
            target.GetComponent<Image>().color = UnityEditor.EditorGUIUtility.HSVToRGB(h,s,v);
        }

        if (positionEnable)
        {
            //位置
            //target.GetComponent<RectTransform>().position = Vector3.Lerp(initPosition, position,Mathf.Clamp((1f / effectTime * timeBuffer),0,1f));
        }

        if (scaleEnable)
        {
            //スケール
            target.GetComponent<RectTransform>().localScale = Vector3.Lerp(initScale, scale, Mathf.Clamp((1f / effectTime * timeBuffer), 0, 1f));
        }

        if (rotateEnable)
        {
            //回転
            target.GetComponent<RectTransform>().Rotate(0, 0, angle * deltaTime);
        }
        if (timeBuffer >= effectTime)
        {
            if (roop)
            {
                //色
                target.GetComponent<Image>().color = initColor;
                //位置
                target.GetComponent<RectTransform>().position = initPosition;
                //スケール
                target.GetComponent<RectTransform>().localScale = initScale;
                //回転
                target.GetComponent<RectTransform>().Rotate(0, 0, angle * deltaTime);
                timeBuffer = 0;
            }
            else
                return true;
        }

        timeBuffer += deltaTime;
        return false;
    }

}
