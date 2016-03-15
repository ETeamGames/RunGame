using UnityEngine;
using System.Collections;

public class fieldOfVision : MoveScript {
	//メインカメラのタグ名　constは定数(絶対に変わらない値)
	private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
	//カメラに映っているかの判定
	private bool _isRendered = false;

	void Start () {
	}

	void Update ()
	{
		if (_isRendered) {
			//Debug.Log ("rendered!");
			base.ResumePlayerMovement();
		} else {
			//Debug.Log ("not rendered...");
			base.StopPlayerMovement();
		}
	}

	/*
	 * OnWillRenderObject はオブジェクトが表示されている場合カメラごとに 1 度呼び出されます.
	 * この関数は MonoBehaviour が無効である場合は呼び出されません。
	 * objectがcomponentとしてrenderを保持する必要あり
	*/
	void OnWillRenderObject()
	{
		//メインカメラに映った時だけ_isRenderedをtrue
		if(Camera.current.tag == MAIN_CAMERA_TAG_NAME){
			_isRendered = true;
		}
	}

}