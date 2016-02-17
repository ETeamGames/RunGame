using UnityEngine;
using System.Collections;
using System.IO;

public class CSVConverter : MonoBehaviour{
	[Button("Process", "Read, convert and create CSV file")] public int button;
	public string inputDataPath = "CSV/InputData/stageData01";
	public string outputDataPath = "Assets/Resources/CSV/OutputData/stageData01.csv";
	public ArrayList outputDataArray = new ArrayList();
	public int column;

	//button用関数
	void Process()
	{
		Debug.Log ("Process called");
		Init ();
		TextAsset csv = Resources.Load(inputDataPath) as TextAsset;
		StringReader reader = new StringReader(csv.text);
		while (reader.Peek() > -1) 
		{
			//read
			string line = reader.ReadLine();
			string[] values = line.Split(',');
			//convert and save
			Convert(values);
			//update parameter
			column++;
		}
		CreateOutputDataFile ();
	}

	void Init()
	{
		outputDataArray.Clear();
		column = 0;
	}

	//convert data-type and save into ArrayList
	void Convert(string[] str)
	{
		for (int i = 0; i < str.Length; i++)
		{
			if (str [i] == "") str [i] = "0";
			string temp = i+","+column+","+str[i];
			outputDataArray.Add (temp);
		}
	}

	//create and output CSV file
	void CreateOutputDataFile()
	{
		StreamWriter sw = new StreamWriter(outputDataPath,false); //true=追記 false=上書き
		for (int i = 0; i < outputDataArray.Count; i++) 
		{
			sw.WriteLine(outputDataArray[i]);
			sw.Flush();
		}
		sw.Close();
	}

	//get outputDataArray
	public ArrayList getAllOutPutData()
	{
		return this.outputDataArray;
	}

	//use for debug
	void outputArrayList()
	{
		for (int i = 0; i < outputDataArray.Count; i++)
			Debug.Log (outputDataArray[i]);
	}
}
