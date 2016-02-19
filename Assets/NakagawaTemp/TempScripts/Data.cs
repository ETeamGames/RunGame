using UnityEngine;
using System.Collections;

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
