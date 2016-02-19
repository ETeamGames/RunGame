using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class CSVReader : MonoBehaviour{
	[Button("Process", "Read CSV file")] public int button;
	public string inputDataPath = "CSV/InputData/stageData01";
	public int column;
	public List<Data> dataList = new List<Data>();
	public char splitChar = ',';
	public char[] splitOptionChar = { '.', '-'};

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
			string[] values = line.Split(splitChar);
			//convert and create Data
			ConvertToData(values);
			//update parameter
			column++;
		}
		Debug.Log (dataList.Count);
		checkDataList ();
	}

	void Init()
	{
		column = 0;
	}

	void ConvertToData(string[] str)
	{
		int countX = 0;
		foreach (string s in str)
		{
			string[] values = s.Split(splitOptionChar);
			Data data = new Data ();
			if (values.Length == 1 && values[0] != "")
				data.setData (int.Parse (values [0]), countX, column, -1);
			else if (values.Length > 1 && values[0] != "")
				data.setData (int.Parse (values [0]), countX, column, int.Parse (values [1]));
			dataList.Add (data);
			countX++;
		}
	}

	public List<Data> getDataList()
	{
		return dataList;
	}

	public void checkDataList()
	{
		for (int i = 0; i < dataList.Count; i++)
			dataList [i].showAllData();
	}

}
