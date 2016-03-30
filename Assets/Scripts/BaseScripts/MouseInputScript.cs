using UnityEngine;
using System.Collections;
using System;

public class MouseInputScript : InputScript {
    public MouseInputScript()
    {
        init();
    }

    public override Vector3 getDownPosition()
    {
        return downPosition;
    }

    public override Vector3 getPosition()
    {
        return Input.mousePosition;
    }

    public override Vector3 getUpPosition()
    {
        return upPosition;
    }

    public override void init()
    {
        upPosition = Vector3.zero;
        downPosition = Vector3.zero;
        isInputUpFlag = false;
        isInputDownFlag = false;
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
        if (Input.GetMouseButtonDown(0))
        {
            downPosition = Input.mousePosition;
            isInputDownFlag = true;
            isInputUpFlag = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            upPosition = Input.mousePosition;
            isInputDownFlag = false;
            isInputUpFlag = true;
        }
	}
}
