using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMaster : MonoBehaviour {
    static public int Board_x;
    static public int Board_z;

    static public int stageSizeMin;
    static public int stageSizeMax;

    static public float privateDelta;
    static public float rad, mag;
    static public bool Pause;
    static public int Count;
    static public int WaveCount;
    static public int MoveNum;

    static public bool SP;
    static public bool WalkChargeBool;
    static public bool SP_AttackUse;
    static public int UI;
    static public float Asobi;

    static public int sp_AttackNum;
    static public bool SP_Full;
    static public bool sp_UI;
    static public int AnchorNum;

    static public string PlayerAnim;
    static public float StayTime = 0.3f; // 攻撃後の待機時間

    static public bool ClearFlag;
    static public int a;
    static public int b;
    static public int c;
    static public int d;//2017/08/29追加(小林)

    static public string StageName;
    static public int StageNum;

    static public string gameSystemEnum;

    //以下2017/08/12小林追加部分
    static public int StageNumber;//何番目のステージかを判定するために使用
                                  //↑これはクリア画面の時にどこのステージから来たのかを確認するためのもの
                                  //各ステージの時にステージ番号(0～5)を宣言してもらう
    static public bool tutorial = false;
    static public int NowNumberOfMoves;//ステージで掛かった手数を記憶

    static public bool clickSwitch;//↑これはクリア画面の時に手数を表示させるために使用する
                                       //各ステージの最後で掛かった手数をここに記録させる
    static public int radNum = 0;
   // static public string Language = "Japanese"; 
    public int _Asobi;

    static public int tesu;

    void Awake()
    {
        SP_AttackUse = false;
        Pause = false;
        Asobi = _Asobi;
        Count = 0;
        privateDelta = 0;
        StaticMaster.SP_Full = false;
        ClearFlag=false;
        a = 0;
        b = 0;
        c = 0;
        d = 0;//2017/08/29追加(小林)
    }
}
