using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreTesu : MonoBehaviour {
	private int NowS;
	public Text scoretext;
	public Text tesutext;
	public int STN;
    public int tesu;

    public int EnemyBlue;
    public int EnemyYellow;
    public int EnemyRed;
    public int BossScore_kari;
    public int BossNum = 1;
    private int EnemyAll=1;
    private int ScoreAll = 10000;
    private int BluePar, YellowPar, RedPar;
    public int Blue_Par_10, Yellow_Par_10, Red_Par_10;
    static public int BlueScore;
    static public int YellowScore;
    static public int RedScore;
    static public int BossScore;
    public int seigyoBlue = 0;
    public int seigyoYellow = 0;
    public int seigyoRed = 0;
    static public int overBlue = 0;
    static public int overYellow = 0;
    static public int overRed = 0;
    // Use this for initialization
    void Start()
    {

        EnemyAll = EnemyBlue + EnemyRed + EnemyYellow;
        ScoreAll -= BossScore_kari;
        BluePar = EnemyBlue * 100 / EnemyAll;
        YellowPar = EnemyYellow * 100 / EnemyAll;
        RedPar = EnemyRed * 100 / EnemyAll;
        if (BluePar + YellowPar + RedPar != 100)
        {
            RedPar += 1;
        }
        BlueScore = Score(EnemyBlue, EnemyAll, ScoreAll, "Blue", BluePar, Blue_Par_10);
        YellowScore = Score(EnemyYellow, EnemyAll, ScoreAll, "Yellow", YellowPar, Yellow_Par_10);
        RedScore = Score(EnemyRed, EnemyAll, ScoreAll, "Red", RedPar, Red_Par_10);
        ScoreAll = BlueScore * EnemyBlue + YellowScore * EnemyYellow + RedScore * EnemyRed;
        BossScore = (10000 - ScoreAll)/BossNum;

        //STN = StaticMaster.StageNumber;
        //手数は最短＋５
        //STNはステージナンバー
        if (tesu == 0)
        {
            if (STN == 1) tesu = 11;
            else if (STN == 2) tesu = 19;
            else if (STN == 3) tesu = 21;
            else if (STN == 4) tesu = 25;
            else if (STN == 5) tesu = 31;
        }
        StaticMaster.tesu = tesu;
    }
	
	// Update is called once per frame
	void Update () {
        if (seigyoBlue != 0 && seigyoYellow != 0 && seigyoRed != 0)
        {
            if (seigyoBlue < StaticMaster.a) overBlue = StaticMaster.a - seigyoBlue;
            if (seigyoRed < StaticMaster.b) overRed = StaticMaster.b - seigyoRed;
            if (seigyoBlue < StaticMaster.c) overYellow = StaticMaster.c - seigyoYellow;
        }
        //ステージごとのスライムの点数
        NowS = StaticMaster.a * BlueScore + StaticMaster.b * RedScore + StaticMaster.c * YellowScore + StaticMaster.d * BossScore - overBlue * BlueScore - overYellow * YellowScore - overRed * RedScore;
        if (STN == 1){
            //NowS = StaticMaster.a * 700 + StaticMaster.b * 0 + StaticMaster.c * 0+StaticMaster.d * 900;
            tesutext.text = "" + -1 * (StaticMaster.tesu - 11);
		}

		if(STN == 2){
			//NowS = StaticMaster.a * 300 + StaticMaster.b * 0 + StaticMaster.c * 400 + StaticMaster.d * 900;
            tesutext.text = "" + -1 * (StaticMaster.tesu - 19);
        }

		if(STN == 3){
			//NowS = StaticMaster.a * 200 + StaticMaster.b * 350 + StaticMaster.c * 0 + StaticMaster.d * 450;
            tesutext.text = "" + -1 * (StaticMaster.tesu - 21);
        }

		if(STN == 4){
			//NowS = StaticMaster.a * 150 + StaticMaster.b * 400 + StaticMaster.c * 300 + StaticMaster.d * 450;
            tesutext.text = "" + -1 * (StaticMaster.tesu - 25);
        }

		if(STN == 5){
			//NowS = StaticMaster.a * 100 + StaticMaster.b * 260 + StaticMaster.c * 200 + StaticMaster.d * 700;
            tesutext.text = "" + -1 * (StaticMaster.tesu - 31);
        }

        if (STN > 5)
        {
            tesutext.text = "" + -1 * (StaticMaster.tesu - tesu);
        }
		scoretext.text = "SCORE:"+ NowS;
	}

    public int Score(int EnemyNum, int E_All, int S_All, string EnemyColor, int EnemyPar, int Par)
    {
        int EnemyScoreAll = (S_All * EnemyPar / 100) * Par / 10;
        int EnemyScore = 0;
        if (EnemyNum != 0) EnemyScore = EnemyScoreAll / EnemyNum;
        if (EnemyScore % 5 != 0)
        {
            EnemyScore -= EnemyScore % 5;
        }
        return (EnemyScore);
    }
}
