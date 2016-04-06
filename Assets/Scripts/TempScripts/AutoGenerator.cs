using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class AutoGenerator : MonoBehaviour {
	[Button("Process", "Generate all objects")]
	public int button;
	public GameObject[] objects;
	//元の床のタイルの大きさ調整用
	private float tileSise;
	private Data[] data;
	private Hashtable hashTable;
	//for CSVReader
	public string inputDataPath = "CSV/InputData/TestStage";
	public CSVReader csvReader;

	//button用関数
	void Process()
	{
		csvReader = new CSVReader(inputDataPath);
		data = csvReader.getDataList().ToArray();
		if(data.Length <= 0)
		{
			Debug.Log("マップファイルが読み込まれていません");
			return;
		}
		hashTable = new Hashtable();
		//元となる床のオブジェクトの大きさを取得
		tileSise = objects[3].transform.localScale.x;

		//床のテクスチャの大きさを取得
		//以降このテクスチャサイズを元にタイルを配置
		float x = objects[3].GetComponent<SpriteRenderer>().sprite.texture.width * tileSise / objects[3].GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
		float y = objects[3].GetComponent<SpriteRenderer>().sprite.texture.height * tileSise / objects[3].GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;

        //先にチェックポイントを登録
        foreach (Data d in data)
        {
            if(d.ID == 1)
            {
                GameObject go = (GameObject)Instantiate(objects[1], new Vector3(d.X*x,-d.Y*y), objects[1].transform.rotation);
                go.name = go.name + d.CheckPointNumber;
                hashTable.Add(d.CheckPointNumber, go);
            }
        }


		foreach (Data d in data)
		{
			if (d.ID < 0)
			{

			}
			else if (d.ID != 1)//オブジェクトIDがCheckPointでない
			{
				if (d.CheckPointNumber >= 0)//CheckPointNumberが0以上
				{
					//Debug.Log("num:" + n + " objectId:" + d.ID + " checkID:" + d.CheckPointNumber + " x:" + d.X + " y:" + d.Y);
					if (hashTable.Contains(d.CheckPointNumber))//チェックポイントが登録されている
					{
						//オブジェクトを作成し、チェックポイントに登録
						GameObject go = (GameObject)Instantiate(objects[d.ID], new Vector3(d.X * x, -d.Y * y), objects[d.ID].transform.rotation);
						go.transform.parent = ((GameObject)hashTable[d.CheckPointNumber]).transform;
					}
					else
					{
						//チェックポイントオブジェクトを作成
						GameObject temp = (GameObject)Instantiate(objects[1], new Vector3(0, 0), objects[1].transform.rotation);
						temp.name = objects[1].name + d.CheckPointNumber;
						GameObject go = (GameObject)Instantiate(objects[d.ID], new Vector3(d.X * x, -d.Y * y), objects[d.ID].transform.rotation);
						go.transform.parent = temp.transform;
						hashTable.Add(d.CheckPointNumber, temp);
					}
				}
				else
				{
					//Generatorの子オブジェクトとして登録
					GameObject go = (GameObject)Instantiate(objects[d.ID], new Vector3(d.X * x, -d.Y * y), objects[d.ID].transform.rotation);
					go.transform.parent = transform;
				}
			}
			else
			{
				if (!hashTable.ContainsKey(d.CheckPointNumber))//チェックポイントが存在しない
				{
					GameObject go = (GameObject)Instantiate(objects[1], Vector3.zero, objects[1].transform.rotation);
					go.name = go.name + d.CheckPointNumber;
					hashTable.Add(d.CheckPointNumber, go);
				}
			}
		}
		foreach (GameObject g in hashTable.Values)
		{
			g.transform.parent = transform;
		}
	}
}

public class CSVReader{
	public string inputDataPath = "";
	public int column;
	public List<Data> dataList = new List<Data>();
	public char splitChar = ',';
	public char[] splitOptionChar = { '.', '-'};

	public CSVReader(string filePath)
	{
		this.inputDataPath = filePath;
	}

	//button用関数
	public void Process()
	{
		Debug.Log ("CSVReader Process called");
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
			if (values.Length == 1 && values [0] != "") {
				data.setData (int.Parse (values [0]), countX, column, -1);
				dataList.Add (data);
			} else if (values.Length > 1 && values [0] != "") {
				data.setData (int.Parse (values [0]), countX, column, int.Parse (values [1]));
				dataList.Add (data);
			}
			countX++;
		}
	}

	public List<Data> getDataList()
	{
		this.Process ();
		return this.dataList;
	}

	public void checkDataList()
	{
		for (int i = 0; i < dataList.Count; i++)
			dataList [i].showAllData();
	}

}

public class Data {
	public int ID;
	public int X;
	public int Y;
	public int CheckPointNumber;

	public Data()
	{
		ID = -1;
		X = -1;
		Y = -1;
		CheckPointNumber = -1;
	}

	public Data(int id, int x, int y, int num)
	{
		ID = id;
		X = x;
		Y = y;
		CheckPointNumber = num;
	}

	public void setData(int id, int x, int y, int num)
	{
		ID = id;
		X = x;
		Y = y;
		CheckPointNumber = num;
	}

	public void showAllData()
	{
		Debug.Log ("ID_X_Y_CheckPointNum = "+ID+"_"+X+"_"+Y+"_"+CheckPointNumber);
	}
}