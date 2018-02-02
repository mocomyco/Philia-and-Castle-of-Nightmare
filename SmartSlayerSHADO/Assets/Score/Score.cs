using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text Trouble;
    public Text TimeCount;
    private float NowTime;
    private int NowTroubleCount;
    private bool StartTime = false;
    // Use this for initialization
    void Start () {
        Trouble.text = "" + NowTroubleCount;
        TimeCount.text = "" + NowTime.ToString("f2");
        StaticMaster.NowNumberOfMoves = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTime == true)
        {
            TimeCount.text = "" + NowTime.ToString("f2");
            StaticMaster.NowTimeCount = NowTime;
            NowTime += Time.deltaTime;
           
        }
    }

    void TimeStart()
    {
        StartTime = true;
    }

    void TroubleCount()//手数スコアを増加
    {
        NowTroubleCount++;
        Trouble.text = "" + NowTroubleCount;
        StaticMaster.NowNumberOfMoves = NowTroubleCount;
    }
}
