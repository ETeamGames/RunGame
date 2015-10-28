using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float power = 0;
    public dynamicObjectScript[] objects = new dynamicObjectScript[3];

    //攻撃可能物体を座標に飛ばす
    public void attack(Vector3 vec)
    {
        foreach(dynamicObjectScript obj in objects)
        {
            if (obj != null)
            {
                //objectとタッチ位置との方向ベクトルを算出
                Vector2 direction = vec - obj.transform.position;
                Debug.Log("<PlayerScript:attack> direction" + direction);
                //速度を0にする
                obj.debugScript.debug = false;
                //その方向に力を加える
                obj.objectRigidbody.AddForce(direction.normalized * power);
            }
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
