using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    public Text[] HighScoreText;
    public bool Reset;//ハイスコアをリセットする(Unityで一度動かしてリセットさせる)
	// Use this for initialization
	void Start () {
        if (Reset == true)//ハイスコアをリセットする
        {
            PlayerPrefs.SetInt("Data1", 0);
            PlayerPrefs.SetInt("Data2", 0);
            PlayerPrefs.SetInt("Data3", 0);
            PlayerPrefs.SetInt("Data4", 0);
            PlayerPrefs.SetInt("Data5", 0);
            PlayerPrefs.SetInt("Data6", 0);
            PlayerPrefs.SetInt("Data7", 0);
            PlayerPrefs.SetInt("Data8", 0);
            PlayerPrefs.SetInt("Data9", 0);
            PlayerPrefs.SetInt("Data10", 0);
            Reset = false;
        }
        HighScoreText[0].text = "" + PlayerPrefs.GetInt("Data1");
        HighScoreText[1].text = "" + PlayerPrefs.GetInt("Data2");
        HighScoreText[2].text = "" + PlayerPrefs.GetInt("Data3");
        HighScoreText[3].text = "" + PlayerPrefs.GetInt("Data4");
        HighScoreText[4].text = "" + PlayerPrefs.GetInt("Data5");
        HighScoreText[5].text = "" + PlayerPrefs.GetInt("Data6");
        HighScoreText[6].text = "" + PlayerPrefs.GetInt("Data7");
        HighScoreText[7].text = "" + PlayerPrefs.GetInt("Data8");
        HighScoreText[8].text = "" + PlayerPrefs.GetInt("Data9");
        HighScoreText[9].text = "" + PlayerPrefs.GetInt("Data10");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RESET()
    {

        PlayerPrefs.SetInt("Data1", 0);
        PlayerPrefs.SetInt("Data2", 0);
        PlayerPrefs.SetInt("Data3", 0);
        PlayerPrefs.SetInt("Data4", 0);
        PlayerPrefs.SetInt("Data5", 0);
        PlayerPrefs.SetInt("Data6", 0);
        PlayerPrefs.SetInt("Data7", 0);
        PlayerPrefs.SetInt("Data8", 0);
        PlayerPrefs.SetInt("Data9", 0);
        PlayerPrefs.SetInt("Data10", 0);

        HighScoreText[0].text = "" + PlayerPrefs.GetInt("Data1");
        HighScoreText[1].text = "" + PlayerPrefs.GetInt("Data2");
        HighScoreText[2].text = "" + PlayerPrefs.GetInt("Data3");
        HighScoreText[3].text = "" + PlayerPrefs.GetInt("Data4");
        HighScoreText[4].text = "" + PlayerPrefs.GetInt("Data5");
        HighScoreText[5].text = "" + PlayerPrefs.GetInt("Data6");
        HighScoreText[6].text = "" + PlayerPrefs.GetInt("Data7");
        HighScoreText[7].text = "" + PlayerPrefs.GetInt("Data8");
        HighScoreText[8].text = "" + PlayerPrefs.GetInt("Data9");
        HighScoreText[9].text = "" + PlayerPrefs.GetInt("Data10");
    }
}
