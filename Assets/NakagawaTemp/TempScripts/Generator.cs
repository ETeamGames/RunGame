using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Generator : MonoBehaviour {
	[Button("Process", "Generate all objects")] public int button;
	public string inputDataPath = "CSV/OutputData/stageData01";
	public GameObject temp;
	public Vector3 initialPos = new Vector3(0,0,0);
	public Vector3 nextPos = new Vector3(0,0,0);
	public float unitX = 0.64f;
	public float unitY = 0.64f;

	//button用関数
	void Process()
	{
		Debug.Log ("Process called");
		Init ();
		TextAsset csv = Resources.Load(inputDataPath) as TextAsset;
		StringReader reader = new StringReader(csv.text);
		while (reader.Peek() > -1) {
			//read
			string line = reader.ReadLine();
			string[] values = line.Split(',');
			Generate (values);
		}
		//Generate ();
	}

	void Init()
	{
		initialPos = new Vector3(0,0,0);
		nextPos = new Vector3(0,0,0);
	}

	void ReInit(int type){
		initialPos = new Vector3(0,0,0);
		nextPos = new Vector3(0,0,0);
		switch(type)
		{
			case 1:
				temp = (GameObject)Resources.Load ("Prefabs/Floor");
				break;
			default:
				temp = (GameObject)Resources.Load ("Prefabs/Floor");
				break;
		}
	}

	void Generate(string[] str)
	{
		ReInit (int.Parse(str[2]));
		nextPos = new Vector3 (unitX*float.Parse(str[0]),unitY*float.Parse(str[1]),0);
		if (int.Parse (str [2]) != 0) {
			GameObject obj = (GameObject)Instantiate (temp, nextPos, Quaternion.identity);
			obj.transform.parent = transform;
		}
	}
}
