using UnityEngine;
using System.Collections;

public abstract class ItemScript : MonoBehaviour {

    /// <summary>
    /// スクリプトの追加関数
    /// </summary>
    /// <param name="gameObject">追加対象</param>
    protected abstract void addEffect(GameObject gameObject);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
