using UnityEngine;
using System.Collections;

public class GameOverEffectScript : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer effectSprite;
    [SerializeField]
    private float effectTime = 1;
    private float timeBuffer;

    private Vector3 scaleBuffer;
    private float deltaScale;

	// Use this for initialization
	void Start ()
    {
        deltaScale = transform.localScale.x / effectTime;
        timeBuffer = effectTime;
        scaleBuffer = transform.localScale;
    }
	
    public void stop()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        transform.localScale = scaleBuffer;
        Destroy(this);
    }

	// Update is called once per frame
	void Update ()
    {
        if (GameManager.getGameOverFlag() && timeBuffer >= 0)
        {
            //アニメーションの停止、あるいは死亡アニメーション再生
            transform.parent.GetComponent<Animator>().enabled = false;
            transform.parent.GetComponent<MoveScript>().enabled = false;

            GetComponent<SpriteRenderer>().enabled = true;

            transform.localScale = new Vector3(transform.localScale.x - deltaScale * Time.deltaTime,
                                                transform.localScale.y - deltaScale * Time.deltaTime,
                                                transform.localScale.z);
            timeBuffer -= Time.deltaTime;
        }
        else if(timeBuffer < 0)
        {
            transform.localScale = Vector3.zero;
            stop();
        }
	}
}
