using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXStageEnemyUI : MonoBehaviour {

    public Text[] Blue = new Text[5];
    public Text[] Yellow = new Text[5];
    public Text[] Red = new Text[5];
    public Text[] Rainbow = new Text[5];

    public int BlueMax;
    public int YellowMax;
    public int RedMax;
    public int RainbowMax;



    void Start () {
		if(BlueMax >= 10)
        {
            Blue[3].text = "" + Mathf.Floor(BlueMax / 10);
            Blue[4].text = ""+ (BlueMax - (Mathf.Floor(BlueMax / 10)) * 10); ;
        }
        else
        {
            Blue[3].text = "" + BlueMax;
            Blue[4].text = "" ;
        }

        if (YellowMax >= 10)
        {
            Yellow[3].text = "" + Mathf.Floor(YellowMax / 10);
            Yellow[4].text = "" + (YellowMax - (Mathf.Floor(YellowMax / 10)) * 10); ;
        }
        else
        {
            Yellow[3].text = "" + YellowMax;
            Yellow[4].text = "" ;
        }

        if (RedMax >= 10)
        {
            Red[3].text = "" + Mathf.Floor(RedMax / 10);
            Red[4].text = "" + (RedMax - (Mathf.Floor(RedMax / 10)) * 10); ;
        }
        else
        {
            Red[3].text = "" + RedMax;
            Red[4].text = "" ;
        }

        if (RainbowMax >= 10)
        {
            Rainbow[3].text = "" + Mathf.Floor(RainbowMax / 10);
            Rainbow[4].text = "" + (RainbowMax - (Mathf.Floor(RainbowMax / 10)) * 10); ;
        }
        else
        {
            Rainbow[3].text = "" + RainbowMax;
            Rainbow[4].text = "" ;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (StaticMaster.a >= BlueMax)
        {
            for (int i = 0; i < 5; i++)
            {
                Blue[i].color = Color.red;
            }
            if (BlueMax >= 10)
            {
                Blue[0].text = "" + Mathf.Floor(BlueMax / 10);
                Blue[1].text = "" + (BlueMax - (Mathf.Floor(BlueMax / 10)) * 10); ;
            }
            else
            {
                Blue[0].text = "" ;
                Blue[1].text = "" + BlueMax;
            }
        }
        else
        if (StaticMaster.a >= 10)
        {
            Blue[0].text = "" + Mathf.Floor(StaticMaster.a / 10);
            Blue[1].text = "" + (StaticMaster.a - (Mathf.Floor(StaticMaster.a / 10)) * 10); 
        }
        else
        {
            Blue[0].text = "";
            Blue[1].text = "" + StaticMaster.a;
        }

        if (StaticMaster.c >= YellowMax)
        {
            for (int i = 0; i < 5; i++)
            {
                Yellow[i].color = Color.red;
            }
            if (YellowMax >= 10)
            {
                Yellow[0].text = "" + Mathf.Floor(YellowMax / 10);
                Yellow[1].text = "" + (YellowMax - (Mathf.Floor(YellowMax / 10)) * 10); ;
            }
            else
            {
                Yellow[0].text = "" ;
                Yellow[1].text = "" + YellowMax;
            }
        }
        else
        if (StaticMaster.c >= 10)
        {
            Yellow[0].text = "" + Mathf.Floor(StaticMaster.c / 10);
            Yellow[1].text = "" + (StaticMaster.c - (Mathf.Floor(StaticMaster.c / 10)) * 10); ;
        }
        else
        {
            Yellow[0].text = "";
            Yellow[1].text = "" + StaticMaster.c;
        }

        if (StaticMaster.b >= RedMax)
        {
            for (int i = 0; i < 5; i++)
            {
                Red[i].color = Color.red;
            }
            if (RedMax >= 10)
            {
                Red[0].text = "" + Mathf.Floor(RedMax / 10);
                Red[1].text = "" + (RedMax - (Mathf.Floor(RedMax / 10)) * 10); ;
            }
            else
            {
                Red[0].text = "";
                Red[1].text = "" + RedMax;
            }
        }
        else
        if (StaticMaster.b >= 10)
        {
            Red[0].text = "" + Mathf.Floor(StaticMaster.b / 10);
            Red[1].text = "" + (StaticMaster.b - (Mathf.Floor(StaticMaster.b / 10)) * 10); ;
        }
        else
        {
            Red[0].text = "";
            Red[1].text = "" + StaticMaster.b;
        }

        if (StaticMaster.d >= RainbowMax)
        {
            for (int i = 0; i < 5; i++)
            {
                Rainbow[i].color = Color.red;
            }
            if (RainbowMax >= 10)
            {
                Rainbow[0].text = "" + Mathf.Floor(RainbowMax / 10);
                Rainbow[1].text = "" + (RainbowMax - (Mathf.Floor(RainbowMax / 10)) * 10); ;
            }
            else
            {
                Rainbow[0].text = "" ;
                Rainbow[1].text = "" + RainbowMax;
            }
        }
        else
        if (StaticMaster.d >= 10)
        {
            Rainbow[0].text = "" + Mathf.Floor(StaticMaster.d / 10);
            Rainbow[1].text = "" + (StaticMaster.d - (Mathf.Floor(StaticMaster.d / 10)) * 10); ;
        }
        else
        {
            Rainbow[0].text = "";
            Rainbow[1].text = "" + StaticMaster.d;
        }

       

        
       
       
    }
}
