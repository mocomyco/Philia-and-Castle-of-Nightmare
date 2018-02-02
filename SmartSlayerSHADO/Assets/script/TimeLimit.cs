using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : MonoBehaviour {
    public float MaxLimit;　//制限時間の最大値
    public float SafeTime;　//時間消費なしで行動できる時間
  //  private float NowLimit;　//現在の制限時間
    private float LagTime;　//ターン開始時からの経過時間
	
	void Start () {
     //   NowLimit = MaxLimit;
	}
	
	void Update () {
        // プレイヤーのターン開始時から終わりまで
        LagTime -= Time.deltaTime;  
	}
}
