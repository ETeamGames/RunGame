using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;

public class Generator : MonoBehaviour
{
    [Button("Process", "Generate all objects")]
    public int button;
    public CSVReader csvReader;
    public GameObject[] objects;
    //元の床のタイルの大きさ調整用
    private float tileSise;
    private Data[] data;
    private Hashtable hashTable;


    //button用関数
    void Process()
    {
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

        foreach (Data d in data)
        {
            if (d.ID < 0)
            {

            }
            else if (d.ID != 1)//オブジェクトIDがCheckPointでない
            {
                if (d.CheckPointNumber >= 0)//CheckPointNumberが0以上
                {
                    if (!hashTable.ContainsKey(d.CheckPointNumber))//既にチェックポイントが登録されていない
                    {
                        //チェックポイントオブジェクトを作成
                        GameObject temp = (GameObject)Instantiate(objects[1], new Vector3(0, 0), objects[1].transform.rotation);
                        temp.name = temp.name + d.CheckPointNumber;
                        hashTable.Add(objects[d.CheckPointNumber], temp);
                    }
                    //オブジェクトを作成し、チェックポイントに登録
                    GameObject go = (GameObject)Instantiate(objects[d.ID], new Vector3(d.X * x, -d.Y * y), objects[d.ID].transform.rotation);
                    go.transform.parent = ((GameObject)hashTable[d.CheckPointNumber]).transform;
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
                if (!hashTable.ContainsKey(d.CheckPointNumber))//既にチェックポイントが存在しない
                {
                    GameObject go = (GameObject)Instantiate(objects[1], objects[1].transform.position, objects[1].transform.rotation);
                    go.name = go.name + d.CheckPointNumber;
                    hashTable.Add(d.CheckPointNumber, go);
                }
                //場所を更新
                ((GameObject)hashTable[d.CheckPointNumber]).transform.position = new Vector3(d.X * x, -d.Y * y);
            }
        }
        foreach (GameObject g in hashTable.Values)
        {
            g.transform.parent = transform;
        }
    }
}
