using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    [Header("プロパティ名にカーソルを合わせると、説明が表示されます")]
    [Tooltip("物体を飛ばす力")]
    public float power;

    [Header("ここより下はデバッグ用の表示です")]
    [Header("変更を加えないでください")]
    [Tooltip("飛ばす物体のリスト")]
    public AttackableList end;
    public AttackableList first;
    //攻撃可能物体を座標に飛ばす
    public void attack(Vector3 vec)
    {
        if(first != null)
            first.attack(vec, power);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
