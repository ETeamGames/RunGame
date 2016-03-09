using UnityEngine;
using System.Collections;
using System;

public class TouchInputScript : InputScript{
    public TouchInputScript()
    {
        init();
    }

    public override Vector3 getDownPosition()
    {
        return downPosition;
    }

    public override Vector3 getPosition()
    {
        if (isInputDownFlag)
        {
            return Input.GetTouch(0).position;
        }
        else
            return Vector3.zero;
    }

    public override Vector3 getUpPosition()
    {
        return upPosition;
    }

    public override void init()
    {
        isInputDownFlag = false;
        isInputUpFlag = false;
        downPosition = Vector3.zero;
        upPosition = Vector3.zero;
    }

    public override bool isInputDown()
    {
        return isInputDownFlag;
    }

    public override bool isInputUp()
    {
        return isInputUpFlag;
    }

	public override void process () {
        if(Input.touchCount >0 & !isInputDownFlag & !isInputUpFlag)//初めてタッチされた場合
        {
            downPosition = Input.GetTouch(0).position;
        }
        else if (isInputDownFlag & Input.touchCount == 0)//前に入力があり、かつ現在入力がない場合はタッチが解除されたと判定
        {
            isInputUpFlag = true;
            upPosition = Input.GetTouch(0).position;
        }
        else if (isInputUpFlag & Input.touchCount > 0)//タッチ解除された後で、再びタッチされるとタッチ解除フラグをfalseする
        { 
            isInputUpFlag = false;
            downPosition = Input.GetTouch(0).position;

        }
        isInputDownFlag = Input.touchCount > 0;
	}
}
