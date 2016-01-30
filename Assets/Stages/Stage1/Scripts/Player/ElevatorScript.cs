using UnityEngine;

public class ElevatorScript : Switchable{

    private GameObject player;
    [Button("auto", "Apply")]
    public int button;
    [SerializeField]
    private Vector3 afterPosition;
    [SerializeField]
    private float time;
    [SerializeField]
    private bool flag;
    [SerializeField]
    private Vector3 offset;

    private float timeBuffer;
    private Vector3 delta;

    public override void onSwitch()
    {
        flag = true;
        if(!flag)
            timeBuffer = 0;
    }

	// Use this for initialization
	void Start () {
        offset = afterPosition - transform.position;
        afterPosition = transform.position;
        flag = false;
        if (offset.x != 0)
            delta.x = offset.x / time;
        if(offset.y != 0)
            delta.y = offset.y / time;
        if(offset.z != 0)
            delta.z = offset.z / time;
	}

    void FixedUpdate()
    {
        if (flag && timeBuffer < time)
        {
            transform.position = afterPosition + delta * timeBuffer;
            timeBuffer += Time.fixedDeltaTime;
        }
        else if(flag && timeBuffer >= time)
        {
            player.GetComponent<MoveScript>().ResumePlayerMovement();
            flag = false;
        }
    }

    public void setPlayer(GameObject pl)
    {
        player = pl;
    }
	
	// Update is called once per frame
	void Update () {

	}

    //自動計算用関数
    void auto()
    {
        afterPosition = transform.position;
    }
}
