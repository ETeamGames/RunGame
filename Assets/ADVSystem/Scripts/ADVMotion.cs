using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class ADVMotion{
    public enum DIRECT
    {
        RIGHT,
        CENTER,
        LEFT,
    }
    public enum EMOTION
    {
        HAPPY,
        ANGRY,
        SAD,
        NORMAL,
        SURPRISE,
    }
    public enum DRAW_EFFECT
    {
        NON,
        FADE_IN,
        FADE_OUT,
    }
    public ADVCharactor chara;
    public GameObject g;
    public DIRECT direct;
    public EMOTION emo;
    public DRAW_EFFECT startEffect;
    public DRAW_EFFECT endEffect;
    public float effectTime;

    private Color c;

    public void setCharactorEffect(DRAW_EFFECT flag)
    {
        switch (flag)
        {
            case DRAW_EFFECT.NON:
                //g.GetComponent<ADVCharactorEffect>().timeBuffer = g.GetComponent<ADVCharactorEffect>().effectTime;
                g.GetComponent<ADVCharactorEffect>().startFlag = ADVCharactorEffect.TIMMING.NON;
                break;
            case DRAW_EFFECT.FADE_IN:
                g.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0);
                c = new Color(  1f,
                                1f,
                                1f,
                                1f);
                g.GetComponent<ADVCharactorEffect>().endColor = c;
                break;
            case DRAW_EFFECT.FADE_OUT:
                c = new Color(  1f,
                                1f,
                                1f,
                                0f);
                g.GetComponent<ADVCharactorEffect>().endColor = c;
                break;
        }
        g.GetComponent<ADVCharactorEffect>().effectTime = effectTime;
        g.GetComponent<ADVCharactorEffect>().init();
    }

    public void init(float x,float y,float z,Canvas c)
    {
        g = (GameObject)GameObject.Instantiate(chara.gameObject, Vector3.zero, Quaternion.identity);

        //g.AddComponent<ADVCharactorEffect>();
        g.GetComponent<ADVCharactorEffect>().startFlag = ADVCharactorEffect.TIMMING.START;
        setCharactorEffect(startEffect);
        

        if (direct == DIRECT.RIGHT)
        {
            //Debug.Log("ADVMotion : direct.right");
            g.GetComponent<Image>().sprite = chara.right[(int)emo];
            g.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
        else if (direct == DIRECT.CENTER)
        {
            //Debug.Log("ADVMotion : direct.center");
            g.GetComponent<Image>().sprite = chara.center[(int)emo];
        }
        else
        {
            //Debug.Log("ADVMotion : direct.left");
            g.GetComponent<Image>().sprite = chara.right[(int)emo];
            g.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
        }

        g.GetComponent<ADVCharactor>().setPos(x, y, z);
        g.transform.SetParent(c.transform.Find("Charactors").transform);
    }

    public void end()
    {
        g.GetComponent<ADVCharactorEffect>().startFlag = ADVCharactorEffect.TIMMING.END;
        setCharactorEffect(endEffect);
        //GameObject.Destroy(g);
    }
}
