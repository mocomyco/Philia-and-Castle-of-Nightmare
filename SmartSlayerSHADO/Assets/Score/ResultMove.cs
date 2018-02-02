using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultMove : MonoBehaviour {
    //ステージの呼び出し
    public string CameStage;
    public string[] StageName;
    public int ScoreNumber;

    //元ステージでの記録
    public float NowTimeScore;
    public int NowTroubleScore;

    //ハイスコア
    public float HighTimeScore;
    public int HighTroubleScore;
    // Use this for initialization
    void Start () {
        NowTimeScore = StaticMaster.NowTimeCount;
        NowTroubleScore = StaticMaster.NowNumberOfMoves;
        CameStage = StaticMaster.StageName;

        for (int i = 0; i < StageName.Length; i++)
        {
            if (StageName[i] == CameStage) ScoreNumber = i;
        }
        HighTimeScore = PlayerPrefs.GetFloat("Time"+ ScoreNumber);
        HighTroubleScore = PlayerPrefs.GetInt("Trouble" + ScoreNumber);


        if(NowTimeScore > HighTimeScore)
        {
            PlayerPrefs.SetFloat("Time" + ScoreNumber, NowTimeScore);
            PlayerPrefs.Save();
        }
        if(NowTroubleScore > HighTroubleScore)
        {
            PlayerPrefs.SetInt("Trouble" + ScoreNumber, NowTroubleScore);
            PlayerPrefs.Save();
        }
    }
	
	// Update is called once per frame
	void Update () {
     
    }
}
