using UnityEngine;
using System.Collections;

public class BallSightScript : MonoBehaviour {
    public GameObject parent;
    /// <summary>
    /// 回転速度
    /// </summary>
    public float rotateSpeed;
    /// <summary>
    /// 拡縮の時間
    /// </summary>
    public float scaleSpeed;
    /// <summary>
    /// 初期の大きさ
    /// </summary>
    private Vector3 initScale;
    private float timeBuffer;
    private Vector3 deltaScale;

	// Use this for initialization
	void Start () {
        initScale = transform.localScale;
        timeBuffer = 0;
        deltaScale = (initScale - transform.localScale)/scaleSpeed;
	}

	void FixedUpdate () {
        transform.localScale = initScale * (0.2f*Mathf.Sin(2 * Mathf.PI * 1 * timeBuffer)+0.8f);
        transform.Rotate(0, 0, rotateSpeed * Time.fixedDeltaTime, Space.Self);
        timeBuffer += Time.fixedDeltaTime;
        transform.position = parent.transform.position;
	}
}
