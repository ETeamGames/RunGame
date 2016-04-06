using UnityEngine;
using System.Collections;

public class StageSelectButton : MonoBehaviour {
	[SerializeField] TextMesh stageNameTextMesh;
	[SerializeField] TextMesh nowStageTextMesh;
    [SerializeField] LogViewScript lvs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ButtonPushed(){
		Debug.Log ("button pushed");
		nowStageTextMesh.text = stageNameTextMesh.text;
        lvs.ChangeView(stageNameTextMesh.text);
		Debug.Log ("StageName is "+nowStageTextMesh.text);

	}
}
