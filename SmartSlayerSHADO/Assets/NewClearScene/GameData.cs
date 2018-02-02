using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour {
    public int HighScore;//ハイスコア
    public int NowScore;//今回獲得したスコア
    public int Number;
    //public Text HighScoreText;
	// Use this for initialization
	void Start () {
        Number = StaticMaster.StageNumber;//どのステージのものか取得
        //HighScore = PlayerPrefs.GetInt("Data1");//確認用(現状各ステージの判別が行えないための代わり)
        if (Number == 1) HighScore = PlayerPrefs.GetInt("Data1");
        else if(Number == 2) HighScore = PlayerPrefs.GetInt("Data2");
        else if(Number == 3) HighScore = PlayerPrefs.GetInt("Data3");
        else if(Number == 4) HighScore = PlayerPrefs.GetInt("Data4");
        else if(Number == 5) HighScore = PlayerPrefs.GetInt("Data5");
        //HighScoreText.text = "" + HighScore;
        NowScore = StaticMaster.a * 10 + StaticMaster.b * 15 + StaticMaster.c * 20;
        if(NowScore > HighScore)//もし現在のスコアがハイスコアを超えたら実行
        {
            //PlayerPrefs.SetInt("Data1", NowScore);//確認用(現状各ステージの判別が行えないための代わり)
            if (Number == 1) PlayerPrefs.SetInt("Data1", NowScore);
            else if (Number == 2) PlayerPrefs.SetInt("Data2", NowScore);
            else if (Number == 3) PlayerPrefs.SetInt("Data3", NowScore);
            else if (Number == 4) PlayerPrefs.SetInt("Data4", NowScore);
            else if (Number == 5) PlayerPrefs.SetInt("Data5", NowScore);
            PlayerPrefs.Save();
            //HighScore = PlayerPrefs.GetInt("Data1");//確認用(現状各ステージの判別が行えないための代わり)
            if (Number == 1) HighScore = PlayerPrefs.GetInt("Data1");
            else if (Number == 2) HighScore = PlayerPrefs.GetInt("Data2");
            else if (Number == 3) HighScore = PlayerPrefs.GetInt("Data3");
            else if (Number == 4) HighScore = PlayerPrefs.GetInt("Data4");
            else if (Number == 5) HighScore = PlayerPrefs.GetInt("Data5");
            Debug.Log("Dataデータをに更新しました");
            //HighScoreText.text = "" + HighScore;
        }
        if (PlayerPrefs.HasKey("Data1") || PlayerPrefs.HasKey("Data2") || PlayerPrefs.HasKey("Data3") || PlayerPrefs.HasKey("Data4") || PlayerPrefs.HasKey("Data5"))//確認用
        {
            if (NowScore > HighScore)//もし現在のスコアがハイスコアを超えたら実行
            {
                Debug.Log("Dataデータを" + HighScore + "に更新しました");
            }
            else
            {
                Debug.Log("Dataデータを" + HighScore + "で維持しました");
            }
        }
        else
        {
            Debug.Log("Dataデータは存在しません");
        }
    }
}
