using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using UnityStageScoreTest;

public class LogViewScript : MonoBehaviour {
    public TextMesh stageNameText;
    public TextMesh log;

    void Awake()
    {
        /*******************************************************************************/
        /*** debug データ読み込みテスト用***/

        /*for (int n = 0; n < 5; n++)
        {
            StageScore ss = new StageScore();
            ss.date = System.DateTime.Now;
            ss.time = new TimeSpan(0, UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 59));
            ss.score = UnityEngine.Random.Range(0, 1000);
            StageScoreList.getInstance().addScore(ss, "STAGE-1");
        }*/

        //ScoreDataWriter sdw = new ScoreDataWriter();
        //sdw.write();

        /*******************************************************************************/

        StreamReader sr;
        FileInfo fi;
        fi = new FileInfo(Application.dataPath + @"\Resources\scoredata.dat");
        if (fi == null)
            return;
        sr = fi.OpenText();
        ScoreDataReader sdr = new ScoreDataReader(sr);
    }

    public void ChangeView(string stageName)
    {
        stageNameText.text = stageName;
        var data = StageScoreList.getInstance().getScore(stageName);
        if (data == null)
        {
            log.text = "No data...";
            return;
        }
        int n = 1;
        log.text = "Rank  Date        Time  Score";
        foreach(var d in data)
        {
            log.text += string.Format("\nNo.{0}   {1}  {2:00}:{3:00}   {4}", n, d.date.ToShortDateString(), d.time.Minutes,d.time.Seconds, d.score);
            n++;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

namespace UnityStageScoreTest
{
    public struct StageScore
    {
        public DateTime date;
        public TimeSpan time;
        public int score;
    }
    /// <summary>
    /// ステージのスコアをファイルから読み込み、保持管理するクラス。
    /// データはハッシュテーブルにて保持し、ゲッタを用いてスコアを取得する。
    /// なおこのクラスはシングルトンとして実装する。
    /// </summary>
    public class StageScoreList
    {
        private static Hashtable stages;
        private static StageScoreList instance;
        private StageScoreList()
        {
            stages = new Hashtable();
        }
        public static StageScoreList getInstance()
        {
            if (instance == null)
                instance = new StageScoreList();
            return instance;
        }
        /// <summary>
        /// ステージのスコアを取得します
        /// </summary>
        /// <param name="stageName">ステージ名</param>
        /// <returns>スコアの配列。登録されていない時はnull</returns>
        public LinkedList<StageScore> getScore(string stageName)
        {
            if (stages.ContainsKey(stageName))
            {
                //ステージがある場合
                return ((StageScoreArray)stages[stageName]).getScores();
            }
            else
            {
                return null;
            }
        }
        public Hashtable getAllScore()
        {
            return stages;
        }
        public void addScore(StageScore ss, string stageName)
        {
            if (stages.ContainsKey(stageName))
            {
                //ステージがあるならば
                ((StageScoreArray)stages[stageName]).add(ss);
            }
            else
            {
                //ステージが無いならば
                stages[stageName] = new StageScoreArray(ss);
            }
        }
    }
    public class StageScoreArray
    {
        private const int arrayLimit = 5;
        private LinkedList<StageScore> scores;
        public StageScoreArray()
        {
            scores = new LinkedList<StageScore>();
        }
        /// <summary>
        /// 先頭にssを追加したStageScoreArrayを作成します
        /// </summary>
        /// <param name="ss">追加したいStageScore</param>
        public StageScoreArray(StageScore ss)
        {
            scores = new LinkedList<StageScore>();
            scores.AddLast(ss);
        }
        public void add(StageScore ss)
        {
            if (scores.Count == 0)
            {
                scores.AddLast(ss);
                return;
            }
            LinkedListNode<StageScore> lln = scores.First;
            //追加と同時にソート
            for (int n = 0; n < arrayLimit; n++)
            {
                if (lln == null & n < arrayLimit)
                {
                    //データが登録されていない、かつリミットを超えていない
                    scores.AddLast(ss);
                    break;
                }
                else if (lln.Value.score < ss.score)
                {
                    //新しいほうがスコアが高いならば、比較対象の前に追加
                    scores.AddBefore(lln, ss);
                    break;
                }
                else if (lln.Value.score == ss.score & lln.Value.time.CompareTo(ss.time) == -1)
                {
                    //スコアは同じだが、時間が早い場合、比較対象の前に追加
                    scores.AddBefore(lln, ss);
                    break;
                }
                lln = lln.Next;
            }
            while (scores.Count > arrayLimit)
            {
                //要素数がリミットより大きいなら最後を消去
                scores.RemoveLast();
            }
        }
        public LinkedList<StageScore> getScores()
        {
            return scores;
        }
    }
    public class ScoreDataWriter
    {
        public ScoreDataWriter()
        {
        }
        public void write()
        {
            StreamWriter sw;
            FileInfo fi;
            fi = new FileInfo(Application.dataPath + @"\Resources\scoredata.dat");
            sw = fi.AppendText();

            Hashtable dataArray = StageScoreList.getInstance().getAllScore();
            foreach (string ssa in dataArray.Keys)
            {
                sw.Write(ssa);
                foreach(StageScore ss in ((StageScoreArray)dataArray[ssa]).getScores())
                {
                    sw.Write(String.Format(",{0},{1},{2}", ss.date.ToBinary(), ss.time.ToString(), ss.score));
                }
                sw.WriteLine();
            }
            sw.Flush();
            sw.Close();
        }
    }

    public class ScoreDataReader
    {
        private StreamReader sr;
        public ScoreDataReader(StreamReader data)
        {
            sr = data;
            split();
        }
        private void split()
        {
            if (sr == null)
                return;
            string line;
            StageScore ss;
            while ((line = sr.ReadLine()) != null)
            {
                string[] dataArray = line.Split(',');
                for (int n = 0; (n * 3 + 3) < dataArray.Length; n++)
                {
                    ss = new StageScore();
                    ss.date = DateTime.FromBinary(long.Parse(dataArray[n * 3 + 1]));
                    ss.time = TimeSpan.Parse(dataArray[n * 3 + 2]);
                    ss.score = int.Parse(dataArray[n * 3 + 3]);
                    StageScoreList.getInstance().addScore(ss, dataArray[0]);
                }
            }
        }
    }
}
