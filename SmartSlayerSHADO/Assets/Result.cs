using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {
    public Text[] enemy;
    public Text[] score;
    public bool UseMaxNumberOfMoves;//以下のpublicを使用するか宣言(Clearシーンでバグが発生しないようにするための対策)
    private int Number;
    public int[] MaxNumberOfMoves;//各ステージの最短手数を表示するために使用
    private int NowNumberOfMoves = 0;
    void Start () {
        enemy[0].text = "" + StaticMaster.a;
        enemy[1].text = "" + StaticMaster.b;
        enemy[2].text = "" + StaticMaster.c;

        score[0].text = "" + StaticMaster.a * 10;
        score[1].text = "" + StaticMaster.b * 15;
        score[2].text = "" + StaticMaster.c * 20;
        score[3].text = "" + (StaticMaster.a * 10 + StaticMaster.b * 15 + StaticMaster.c * 20);
        if (UseMaxNumberOfMoves == true)//最短手数を表示させたい場合
        {
            NowNumberOfMoves = StaticMaster.NowNumberOfMoves;//ステージでかかった手数を取得
            score[4].text = "" + NowNumberOfMoves;//掛かった手数を表示
            Number = StaticMaster.StageNumber;//どこのステージから来たのか取得
            score[5].text = "" + MaxNumberOfMoves[Number];//ステージごとの最短手数を表示
        }
        if (StaticMaster.a == 51) score[0].color = new Color32(255, 90, 20, 255);
        if (StaticMaster.b == 10) score[1].color = new Color32(255, 90, 20, 255);
        if (StaticMaster.c == 10) score[2].color = new Color32(255, 90, 20, 255);
        if (860 == StaticMaster.a * 10 + StaticMaster.b * 15 + StaticMaster.c * 20) score[3].color = new Color32(255, 90, 20, 255);
    }
}
