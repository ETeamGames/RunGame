using UnityEngine;
using System.Collections;

public class SightLineScript : MonoBehaviour {
    public enum Active
    {
        NON,
        ACTIVE,
        RESIDUUM
    }
    /// <summary>
    ///　エフェクトを表示するレンダー
    /// </summary>
    public SpriteRenderer render;
    /// <summary>
    /// 押し続けているときTrue
    /// </summary>
    public Active active;

	// Use this for initialization
	void Start () {
	
	}

    public void Proc(Transform t,Vector3 pos,Vector3 playerPos,int n,int length)
    {
        transform.eulerAngles = new Vector3(0, 0,Mathf.Rad2Deg*(Mathf.Acos(Vector3.Dot(pos - playerPos, Vector3.right) / Vector3.Distance(playerPos,pos))));
        pos.x = t.position.x + (playerPos.x - t.position.x) / length * n;
        pos.y = t.position.y + (playerPos.y - t.position.y) / length * n;
        transform.position = pos;
    }
	
	// Update is called once per frame
	void Update () {
	    if(active == Active.ACTIVE)
        {

        }
	}
}
