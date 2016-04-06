using UnityEngine;
using System.Collections;

public class MenuHitScript : MonoBehaviour
{
    private Vector3 initPos;
    public Vector3 effectPosOffset;
    private bool flag;
    private bool flagBuff;
    private bool reverce;
    public float freq = 0.5f;
    private float timeBuffer = 0;

    public void proc()
    {
        flag = true;
    }
	// Use this for initialization
	void Start ()
    {
        initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (flag)
        {
            if ((freq / 4f) >= timeBuffer) {
                transform.position = initPos + (effectPosOffset * Mathf.Sin(2f * Mathf.PI * freq *timeBuffer));
                timeBuffer += Time.deltaTime;
            }
            flag = false;
        }
        else
        {
            timeBuffer = 0;
            transform.position = initPos;
        }
    }
}
