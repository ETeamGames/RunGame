using UnityEngine;
using System.Collections;

public class ConnectButton : MonoBehaviour{
	[SerializeField] TextMesh nowStageTextMesh;
	public string[] stagesName = {"STAGE-1"};

	public void ButtonPushed(){
		Debug.Log (
			"connect button pushed!\n" +
			"connect to "+nowStageTextMesh.text);
		this.ConnectToStage ();
	}

	public void ConnectToStage(){
		if (CheckStageNameIsTrue ()) {
			Debug.Log ("start connecting");
			Application.LoadLevel (nowStageTextMesh.text);
		}
	}

	public bool CheckStageNameIsTrue(){
		foreach (string str in stagesName) {
			if (str.Equals (nowStageTextMesh.text)) {
				Debug.Log ("stage name is true, start connecting...");
				return true;
			}
		}
		Debug.Log ("stage name is false, does not start connecting...");
		return false;
	}

}
