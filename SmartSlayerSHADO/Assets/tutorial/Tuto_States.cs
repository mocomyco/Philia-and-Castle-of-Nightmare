using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_States : MonoBehaviour {
    public GameObject[] AllContents;
    
    public bool[] nowState;//AllContentsと同期させる
    private int nowStateInt;
    private bool stateCheck;
    public UI ui;
    void Start()
    {
        nowStateInt = 0;

        stateCheck = false;
        for (int i = 0; i < AllContents.Length; i++)
        {
            if (nowStateInt == i)
            {
                AllContents[i].SetActive(true);
                nowState[i] = true;
            }
            else
            {
                AllContents[i].SetActive(false);
                nowState[i] = false;
            }
        }
    }
	
	
	void Update () {
        stateCheck = false;
        for (int i = 0; i < nowState.Length; i++)
        {
            if (nowState[i] == true) stateCheck = true;
        }
        if(stateCheck == false)
        {
            if (nowStateInt < AllContents.Length)
            {

            }
            else
            {
                //Debug.Log("終了");
                //チュートリアルの終了
            }
        }
	}

    public void NextContentsNum(int Num)
    {

        Debug.Log(Num + "States Send");
        Num += 1;
        nowStateInt = Num;
        StaticMaster.tutorial = true;
        if (nowStateInt == 2) ui.tutorial = 1;
        if (nowStateInt == 7) ui.tutorial = 2;
        if (nowStateInt == 11) ui.tutorial = 3;
        if (nowStateInt == 14) ui.tutorial = 1;


        if (Num > AllContents.Length)
        {
            Debug.Log("エラー");
            return;
        }
        for(int i =0; i< AllContents.Length; i++)
        {
            if(i == Num)
            {
                nowState[i] = true;
                AllContents[i].SetActive(true);
            }
            else
            {
                nowState[i] = false;
                AllContents[i].SetActive(false);
            }

        }
    }
    
}
