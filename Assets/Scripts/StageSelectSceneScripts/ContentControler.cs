using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContentControler : MonoBehaviour {
	[Button("Process", "Generate item list")]
	public int button;
	[SerializeField]
	RectTransform prefab = null;
	[SerializeField]
	int ItemNum = 5;

	/*void Start () 
	{
		for(int i=0; i<ItemNum; i++)
		{
			var item = GameObject.Instantiate(prefab) as RectTransform;
			item.SetParent(transform, false);

			//var text = item.GetComponentInChildren<Text>();
			//text.text = "item:" + i.ToString();

			TextMesh tm = (TextMesh)item.GetComponentInChildren(typeof(TextMesh));
			//string now = System.DateTime.Now.ToString("HH:mm");
			string stageName = "STAGE "+string.Format("{0}", i);
			tm.text = stageName;
		}
	}*/

	public void Process(){
		Debug.Log ("pushed Button");
		int count = gameObject.transform.childCount;
		for(int i=count; i<ItemNum; i++)
		{
			var item = GameObject.Instantiate(prefab) as RectTransform;
			item.SetParent(transform, false);

			//var text = item.GetComponentInChildren<Text>();
			//text.text = "item:" + i.ToString();

			TextMesh tm = (TextMesh)item.GetComponentInChildren(typeof(TextMesh));
			//string now = System.DateTime.Now.ToString("HH:mm");
			string stageName = "STAGE-"+string.Format("{0}", i);
			tm.text = stageName;
		}
	}
}
