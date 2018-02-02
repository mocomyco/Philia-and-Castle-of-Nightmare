using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    public string CameStage;
    public Text[] enemy;
    public Text[] score;

    public List<RankingCount> Rank; //CharaStatus型のリスト「RankingCount」を宣言(０～４順にD～S)
    [System.Serializable] //これを書くとinspectorに表示される。
    public struct RankingCount
    {
        public GameObject RankImage;
        public float RankMinimumValue;
    }

    //public int[] CountScore;
    //private int Number;
    public int BonusCount;//2017/08/29追加(小林)
    private int Total;
    //public int[] MaxNumberOfMoves;//各ステージの最短手数を表示するために使用
    //private int NowNumberOfMoves = 0;
    public string[] StageName;
    public List<StageScoreCount> StageScore; //CharaStatus型のリスト「StageScoreCount」を宣言
    [System.Serializable] //これを書くとinspectorに表示される。
    public struct StageScoreCount
    {
        public int SlimeCount00;
        public int SlimeCount01;
        public int SlimeCount02;
        public int SlimeCount03;//2017/08/29追加(小林)

        //public int SlimeTotalScore;
        //public int BonusCount;
        //public int MaxTotalScore;

    }
    public int SlimeCount00;
    public int SlimeCount01;
    public int SlimeCount02;
    public int SlimeCount03;//2017/08/29追加(小林)

    public int ScoreNumber;

    public string[] data_5over;

    //ハイスコアに関して
    public int HighScore;//2017/08/31追加(小林)
    void Start()
    {
        CameStage = StaticMaster.StageName;
       
        SlimeCount00 = scoreTesu.BlueScore;
        SlimeCount01 = scoreTesu.RedScore;
        SlimeCount02 = scoreTesu.YellowScore;
        SlimeCount03 = scoreTesu.BossScore;

        //if (StageName[0] == CameStage) ScoreNumber = 0;
        //else if (StageName[1] == CameStage) ScoreNumber = 1;
        //else if (StageName[2] == CameStage) ScoreNumber = 2;
        //else if (StageName[3] == CameStage) ScoreNumber = 3;
        //else if (StageName[4] == CameStage) ScoreNumber = 4;
        //else if (StageName[5] == CameStage) ScoreNumber = 5;//2017/08/29追加(小林)
        
        for(int i = 0; i < StageName.Length; i++)
        {
            if (StageName[i] == CameStage) ScoreNumber = i;
        }

        //Number = StaticMaster.StageNumber;//どこのステージから来たのか取得
        //NowNumberOfMoves = StaticMaster.NowNumberOfMoves;//ステージでかかった手数を取得

        Debug.Log("StaticMaster：A" + StaticMaster.a);
        if (StaticMaster.a >= 10)
        {
            enemy[0].text = "" + Mathf.Floor(StaticMaster.a/10);
            enemy[1].text = "" + (StaticMaster.a - Mathf.Floor(StaticMaster.a / 10)*10);
        }
        else
        {
            enemy[0].text = "";
            enemy[1].text = "" + StaticMaster.a;
        }

        if (StaticMaster.b >= 10)
        {
            enemy[2].text = "" + Mathf.Floor(StaticMaster.b / 10);
            enemy[3].text = "" + (StaticMaster.b - Mathf.Floor(StaticMaster.b / 10) * 10);
        }
        else
        {
            enemy[2].text = "";
            enemy[3].text = "" + StaticMaster.b;
        }
        if (StaticMaster.c >= 10)
        {
            enemy[4].text = "" + Mathf.Floor(StaticMaster.c / 10);
            enemy[5].text = ""+(StaticMaster.c - Mathf.Floor(StaticMaster.c / 10) * 10);
        }
        else
        {
            enemy[4].text = "";
            enemy[5].text = "" + StaticMaster.c;
        }

        enemy[6].text = "" + StaticMaster.d;//2017/08/29追加(小林)

       //スライム青
        if(StaticMaster.a * SlimeCount00 >= 1000)
        {
            //score[0].text = "" + Mathf.Floor(StaticMaster.a * StageScore[ScoreNumber].SlimeCount00 / 1000);
            //score[1].text = "" + ((Mathf.Floor(StaticMaster.a * StageScore[ScoreNumber].SlimeCount00 / 100))-(Mathf.Floor(StaticMaster.a * StageScore[ScoreNumber].SlimeCount00 / 1000)*10));
            //score[2].text = "" + ((Mathf.Floor(StaticMaster.a * StageScore[ScoreNumber].SlimeCount00 / 10)) - (Mathf.Floor(StaticMaster.a * StageScore[ScoreNumber].SlimeCount00 / 100) * 10));
            //score[3].text = "" + (StaticMaster.a * StageScore[ScoreNumber].SlimeCount00 - (Mathf.Floor(StaticMaster.a * StageScore[ScoreNumber].SlimeCount00 / 10))*10);
            score[0].text = "" + Mathf.Floor(StaticMaster.a * SlimeCount00 / 1000);
            score[1].text = "" + ((Mathf.Floor(StaticMaster.a * SlimeCount00 / 100)) - (Mathf.Floor(StaticMaster.a * SlimeCount00 / 1000) * 10));
            score[2].text = "" + ((Mathf.Floor(StaticMaster.a * SlimeCount00 / 10)) - (Mathf.Floor(StaticMaster.a * SlimeCount00 / 100) * 10));
            score[3].text = "" + (StaticMaster.a * SlimeCount00 - (Mathf.Floor(StaticMaster.a * SlimeCount00 / 10)) * 10);
        }
        else if(StaticMaster.a * SlimeCount00 >= 100)
        {
            //score[0].text = "" ;
            //score[1].text = "" + ((Mathf.Floor(StaticMaster.a * StageScore[ScoreNumber].SlimeCount00 / 100)));
            //score[2].text = "" + ((Mathf.Floor(StaticMaster.a * StageScore[ScoreNumber].SlimeCount00 / 10)) - (Mathf.Floor(StaticMaster.a * StageScore[ScoreNumber].SlimeCount00 / 100) * 10));
            //score[3].text = "" + (StaticMaster.a * StageScore[ScoreNumber].SlimeCount00 - (Mathf.Floor(StaticMaster.a * StageScore[ScoreNumber].SlimeCount00 / 10)) * 10);
            score[0].text = "";
            score[1].text = "" + ((Mathf.Floor(StaticMaster.a * SlimeCount00 / 100)));
            score[2].text = "" + ((Mathf.Floor(StaticMaster.a * SlimeCount00 / 10)) - (Mathf.Floor(StaticMaster.a * SlimeCount00 / 100) * 10));
            score[3].text = "" + (StaticMaster.a * SlimeCount00 - (Mathf.Floor(StaticMaster.a * SlimeCount00 / 10)) * 10);
        }
        else if(StaticMaster.a * SlimeCount00 >= 10)
        {
            score[0].text = "";
            score[1].text = "";
            score[2].text = "" + Mathf.Floor(StaticMaster.a * SlimeCount00 / 10);
            score[3].text = "" + (StaticMaster.a * SlimeCount00 - (Mathf.Floor(StaticMaster.a * SlimeCount00 / 10)) * 10);
        }else if(StaticMaster.a * SlimeCount00 >= 0)
        {
            score[0].text = "";
            score[1].text = "";
            score[2].text = "";
            score[3].text = ""+ StaticMaster.a * SlimeCount00;
        }

        //スライム赤
        if (StaticMaster.b * SlimeCount01 >= 1000)
        {
            score[4].text = "" + Mathf.Floor(StaticMaster.b * SlimeCount01 / 1000);
            score[5].text = "" + ((Mathf.Floor(StaticMaster.b * SlimeCount01 / 100)) - (Mathf.Floor(StaticMaster.b * SlimeCount01 / 1000) * 10));
            score[6].text = "" + ((Mathf.Floor(StaticMaster.b * SlimeCount01 / 10)) - (Mathf.Floor(StaticMaster.b * SlimeCount01 / 100) * 10));
            score[7].text = "" + (StaticMaster.b * SlimeCount01 - (Mathf.Floor(StaticMaster.b * SlimeCount01 / 10)) * 10);
        }
        else if (StaticMaster.b * SlimeCount01 >= 100)
        {
            score[4].text = "";
            score[5].text = "" + ((Mathf.Floor(StaticMaster.b * SlimeCount01 / 100)));
            score[6].text = "" + ((Mathf.Floor(StaticMaster.b * SlimeCount01 / 10)) - (Mathf.Floor(StaticMaster.b * SlimeCount01 / 100) * 10));
            score[7].text = "" + (StaticMaster.b * SlimeCount01 - (Mathf.Floor(StaticMaster.b * SlimeCount01 / 10)) * 10);
        }
        else if (StaticMaster.b * SlimeCount01 >= 10)
        {
            score[4].text = "";
            score[5].text = "";
            score[6].text = "" + Mathf.Floor(StaticMaster.b * SlimeCount01 / 10);
            score[7].text = "" + (StaticMaster.b * SlimeCount01 - (Mathf.Floor(StaticMaster.b * SlimeCount01 / 10)) * 10);
        }
        else if (StaticMaster.b * SlimeCount01 >= 0)
        {
            score[4].text = "";
            score[5].text = "";
            score[6].text = "";
            score[7].text = "" + StaticMaster.b * SlimeCount01;
        }

        //スライム黄
        if (StaticMaster.c * SlimeCount02 >= 1000)
        {
            score[8].text = "" + Mathf.Floor(StaticMaster.c * SlimeCount02 / 1000);
            score[9].text = "" + ((Mathf.Floor(StaticMaster.c * SlimeCount02 / 100)) - (Mathf.Floor(StaticMaster.c * SlimeCount02 / 1000) * 10));
            score[10].text = "" + ((Mathf.Floor(StaticMaster.c * SlimeCount02 / 10)) - (Mathf.Floor(StaticMaster.c * SlimeCount02 / 100) * 10));
            score[11].text = "" + (StaticMaster.c * SlimeCount02 - (Mathf.Floor(StaticMaster.c* SlimeCount02 / 10)) * 10);
        }
        else if (StaticMaster.c * SlimeCount02 >= 100)
        {
            score[8].text = "";
            score[9].text = "" + ((Mathf.Floor(StaticMaster.c * SlimeCount02 / 100)));
            score[10].text = "" + ((Mathf.Floor(StaticMaster.c * SlimeCount02 / 10)) - (Mathf.Floor(StaticMaster.c* SlimeCount02 / 100) * 10));
            score[11].text = "" + (StaticMaster.c * SlimeCount02 - (Mathf.Floor(StaticMaster.c* SlimeCount02 / 10)) * 10);
        }
        else if (StaticMaster.c * SlimeCount02 >= 10)
        {
            score[8].text = "";
            score[9].text = "";
            score[10].text = "" + Mathf.Floor(StaticMaster.c * SlimeCount02 / 10);
            score[11].text = "" + (StaticMaster.c * SlimeCount02 - (Mathf.Floor(StaticMaster.c* SlimeCount02 / 10)) * 10);
        }
        else if (StaticMaster.c * SlimeCount02 >= 0)
        {
            score[8].text = "";
            score[9].text = "";
            score[10].text = "";
            score[11].text = "" + StaticMaster.c * SlimeCount02;
        }

        //スライム虹
        if (StaticMaster.d * SlimeCount03 >= 1000)
        {
            score[12].text = "" + Mathf.Floor(StaticMaster.d * SlimeCount03 / 1000);
            score[13].text = "" + ((Mathf.Floor(StaticMaster.d * SlimeCount03 / 100)) - (Mathf.Floor(StaticMaster.d * SlimeCount03 / 1000) * 10));
            score[14].text = "" + ((Mathf.Floor(StaticMaster.d * SlimeCount03 / 10)) - (Mathf.Floor(StaticMaster.d * SlimeCount03 / 100) * 10));
            score[15].text = "" + (StaticMaster.d * SlimeCount03 - (Mathf.Floor(StaticMaster.d * SlimeCount03 / 10)) * 10);
        }
        else if (StaticMaster.d * SlimeCount03 >= 100)
        {
            score[12].text = "";
            score[13].text = "" + ((Mathf.Floor(StaticMaster.d * SlimeCount03 / 100)));
            score[14].text = "" + ((Mathf.Floor(StaticMaster.d * SlimeCount03 / 10)) - (Mathf.Floor(StaticMaster.d *SlimeCount03 / 100) * 10));
            score[15].text = "" + (StaticMaster.d * SlimeCount03 - (Mathf.Floor(StaticMaster.d *SlimeCount03 / 10)) * 10);
        }
        else if (StaticMaster.d * SlimeCount03 >= 10)
        {
            score[12].text = "";
            score[13].text = "";
            score[14].text = "" + Mathf.Floor(StaticMaster.d * SlimeCount03 / 10);
            score[15].text = "" + (StaticMaster.d * SlimeCount03 - (Mathf.Floor(StaticMaster.d * SlimeCount03 / 10)) * 10);
        }
        else if (StaticMaster.d * SlimeCount03 >= 0)
        {
            score[12].text = "";
            score[13].text = "";
            score[14].text = "";
            score[15].text = "" + StaticMaster.d * SlimeCount03;
        }

        // if (StageScore[ScoreNumber].SlimeTotalScore >= StaticMaster.a * StageScore[ScoreNumber].SlimeCount00 + StaticMaster.b * StageScore[ScoreNumber].SlimeCount01 + StaticMaster.c * StageScore[ScoreNumber].SlimeCount02)//ボーナスあり
        if (StaticMaster.tesu>=0)//Bonusは1000以上
        {
            score[16].text = "" + Mathf.Floor(BonusCount / 1000);
            score[17].text = "" + ((Mathf.Floor(BonusCount / 100)) - (Mathf.Floor(BonusCount / 1000) * 10));
            score[18].text = "" + ((Mathf.Floor(BonusCount / 10)) - (Mathf.Floor(BonusCount / 100) * 10));
            score[19].text = "" + (BonusCount - (Mathf.Floor(BonusCount / 10)) * 10);
            //score[19].text = "" + BonusCount;//殲滅時ボーナス点//2017/08/29変更(小林)
            Total = (StaticMaster.a * SlimeCount00 + StaticMaster.b * SlimeCount01 + StaticMaster.c * SlimeCount02 + StaticMaster.d * SlimeCount03 + BonusCount);//合計値(ボーナス込み)//2017/08/29追加(小林)
            Debug.Log("ボーナスが入りました");
        }
        else//ボーナスなし
        {
            score[16].text = "";
            score[17].text = "";
            score[18].text = "";
            score[19].text = "0";//2017/08/29変更(小林)
            Total = (StaticMaster.a * SlimeCount00 + StaticMaster.b * SlimeCount01 + StaticMaster.c * SlimeCount02 + StaticMaster.d * SlimeCount03);//合計値(ボーナスなし)//2017/08/29追加(小林)
            Debug.Log("ボーナスが入りませんでした");
        }
        //Total
        if (Total >= 10000)
        {
            score[20].text = "" + Mathf.Floor(Total / 10000);
            score[21].text = "" + ((Mathf.Floor(Total / 1000)) - (Mathf.Floor(Total / 10000) * 10));
            score[22].text = "" + ((Mathf.Floor(Total / 100)) - (Mathf.Floor(Total / 1000) * 10));
            score[23].text = "" + ((Mathf.Floor(Total / 10)) - (Mathf.Floor(Total / 100) * 10));
            score[24].text = "" + (Total - (Mathf.Floor(Total / 10)) * 10);
        }
        else if (Total >= 1000)
        {
            score[20].text = "";
            score[21].text = "" + (Mathf.Floor(Total / 1000));
            score[22].text = "" + ((Mathf.Floor(Total / 100)) - (Mathf.Floor(Total / 1000) * 10));
            score[23].text = "" + ((Mathf.Floor(Total / 10)) - (Mathf.Floor(Total / 100) * 10));
            score[24].text = "" + (Total - (Mathf.Floor(Total / 10)) * 10);
        }
        else if (Total >= 100)
        {
            score[20].text = "";
            score[21].text = "" ;
            score[22].text = "" + ((Mathf.Floor(Total / 100)));
            score[23].text = "" + ((Mathf.Floor(Total / 10)) - (Mathf.Floor(Total / 100) * 10));
            score[24].text = "" + (Total - (Mathf.Floor(Total / 10)) * 10);
        }
        else if (Total >= 10)
        {
            score[20].text = "";
            score[21].text = "";
            score[22].text = "" ;
            score[23].text = "" + ((Mathf.Floor(Total / 10)));
            score[24].text = "" + (Total - (Mathf.Floor(Total / 10)) * 10);
        }
        else if (Total >= 0)
        {
            score[20].text = "";
            score[21].text = "";
            score[22].text = "";
            score[23].text = "";
            score[24].text = ""+Total ;
        }
        //score[24].text = "" + Total;//合計点数//2017/08/29変更(小林)


        //ハイスコア関連
        if (ScoreNumber == 1)//Stage01のハイスコア更新
        {
            HighScore = PlayerPrefs.GetInt("Data1");
            if (Total > HighScore)//もし現在のスコアがハイスコアを超えたら実行
            {
                PlayerPrefs.SetInt("Data1", Total);
                PlayerPrefs.Save();
            }
        }
        else if (ScoreNumber == 2)//Stage02のハイスコア更新
        {
            HighScore = PlayerPrefs.GetInt("Data2");
            if (Total > HighScore)//もし現在のスコアがハイスコアを超えたら実行
            {
                PlayerPrefs.SetInt("Data2", Total);
                PlayerPrefs.Save();
            }
        }
        else if (ScoreNumber == 3)//Stage03のハイスコア更新
        {
            HighScore = PlayerPrefs.GetInt("Data3");
            if (Total > HighScore)//もし現在のスコアがハイスコアを超えたら実行
            {
                PlayerPrefs.SetInt("Data3", Total);
                PlayerPrefs.Save();
            }
        }
        else if (ScoreNumber == 4)//Stage04のハイスコア更新
        {
            HighScore = PlayerPrefs.GetInt("Data4");
            if (Total > HighScore)//もし現在のスコアがハイスコアを超えたら実行
            {
                PlayerPrefs.SetInt("Data4", Total);
                PlayerPrefs.Save();
            }
        }
        else if (ScoreNumber == 5)//Stage05のハイスコア更新
        {
            HighScore = PlayerPrefs.GetInt("Data5");
            if (Total > HighScore)//もし現在のスコアがハイスコアを超えたら実行
            {
                PlayerPrefs.SetInt("Data5", Total);
                PlayerPrefs.Save();
            }
        }
        else if (ScoreNumber > 5)
        {
            HighScore = PlayerPrefs.GetInt(data_5over[ScoreNumber-6]);
            if (Total > HighScore)//もし現在のスコアがハイスコアを超えたら実行
            {
                PlayerPrefs.SetInt(data_5over[ScoreNumber - 6], Total);
                PlayerPrefs.Save();
            }
        }




        if (Total <= Rank[0].RankMinimumValue)//Dランクの処理
        {
            Rank[0].RankImage.SetActive(true);
            Rank[1].RankImage.SetActive(false);
            Rank[2].RankImage.SetActive(false);
            Rank[3].RankImage.SetActive(false);
            Rank[4].RankImage.SetActive(false);
        }
       else if(Total < Rank[1].RankMinimumValue && Total > Rank[0].RankMinimumValue)//Cランクの処理
        {
            Rank[0].RankImage.SetActive(false);
            Rank[1].RankImage.SetActive(true);
            Rank[2].RankImage.SetActive(false);
            Rank[3].RankImage.SetActive(false);
            Rank[4].RankImage.SetActive(false);
        }
        else if (Total < Rank[2].RankMinimumValue && Total >= Rank[1].RankMinimumValue)//Bランクの処理
        {
            Rank[0].RankImage.SetActive(false);
            Rank[1].RankImage.SetActive(false);
            Rank[2].RankImage.SetActive(true);
            Rank[3].RankImage.SetActive(false);
            Rank[4].RankImage.SetActive(false);
        }
        else if (Total < Rank[3].RankMinimumValue && Total >= Rank[2].RankMinimumValue)//Aランクの処理
        {
            Rank[0].RankImage.SetActive(false);
            Rank[1].RankImage.SetActive(false);
            Rank[2].RankImage.SetActive(false);
            Rank[3].RankImage.SetActive(true);
            Rank[4].RankImage.SetActive(false);
        }
        else if (Total < Rank[4].RankMinimumValue && Total >= Rank[3].RankMinimumValue)//Aランクの処理
        {
            Rank[0].RankImage.SetActive(false);
            Rank[1].RankImage.SetActive(false);
            Rank[2].RankImage.SetActive(false);
            Rank[3].RankImage.SetActive(true);
            Rank[4].RankImage.SetActive(false);
        }
        else if (Total >= Rank[4].RankMinimumValue)//Sランクの処理
        {
            Rank[0].RankImage.SetActive(false);
            Rank[1].RankImage.SetActive(false);
            Rank[2].RankImage.SetActive(false);
            Rank[3].RankImage.SetActive(false);
            Rank[4].RankImage.SetActive(true);
        }


        //if (StaticMaster.a == 51) score[0].color = new Color32(255, 90, 20, 255);
        //if (StaticMaster.b == 10) score[1].color = new Color32(255, 90, 20, 255);
        //if (StaticMaster.c == 10) score[2].color = new Color32(255, 90, 20, 255);
        //if (860 == StaticMaster.a * 10 + StaticMaster.b * 15 + StaticMaster.c * 20) score[3].color = new Color32(255, 90, 20, 255);
    }
}
