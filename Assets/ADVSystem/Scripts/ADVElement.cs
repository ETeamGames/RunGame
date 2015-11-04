using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class ADVElement{
    public string charaName;
    [TextArea]
    public string text;
    public ADVMotion[] chara;

    public void start(Canvas canvas, float charaImagePosY)
    {
        for (int n = 0; n < chara.Length; n++)
        {
            chara[n].init(canvas.GetComponent<RectTransform>().rect.width / (chara.Length * 2) * (2 * n + 1), charaImagePosY, 0,canvas);
        }
    }
    public void end()
    {
        for (int n = 0; n < chara.Length; n++)
        {
            chara[n].end();
        }
    }
}
