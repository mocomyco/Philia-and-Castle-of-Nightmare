using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rad2 : MonoBehaviour
{
    public int Num;
    public float StartRad, EndRad;
   // private SP_Gauge SP;
    public Image ImageColor;
    private int CanvasScreenSize, GameObjectScreenSize;
    private Scrollbar value;


    void Awake()
    {
        value = GetComponent<Scrollbar>();

    }

    void Start()
    {
     //   SP = GameObject.Find("SP_GAUGE").GetComponent<SP_Gauge>();

    }

    void Update()
    {
        if (PlayerMove.playerPos.x == 0)
        {
            if (Num == 6 || Num == 4 || Num == 5)
            {
                return;
            }
        }
        if (PlayerMove.playerPos.x == 6)
        {
            if (Num == 2 || Num == 1 || Num == 8)
            {
                return;
            }
        }
        if (PlayerMove.playerPos.z == 0)
        {
            if (Num == 8 || Num == 6 || Num == 7)
            {
                return;
            }
        }

        if (StaticMaster.Asobi > StaticMaster.mag)
        {
            StaticMaster.MoveNum = 0;
            value.value = 0;
        }
        else
        if (Num == 5 && (StartRad <= StaticMaster.rad || StaticMaster.rad < EndRad) && StaticMaster.MoveNum == 0)
        {

            StaticMaster.MoveNum = Num;
        }
        else
        if (StartRad <= StaticMaster.rad && StaticMaster.rad < EndRad && StaticMaster.MoveNum == 0)
        {
            StaticMaster.MoveNum = Num;
        }
        else
        {
            value.value = 0;
        }


        if (StaticMaster.MoveNum == 0 && ((Num == 5 && (StartRad < StaticMaster.rad || StaticMaster.rad < EndRad)) || (StartRad < StaticMaster.rad && StaticMaster.rad < EndRad)))
        {
            ImageColor.color = new Color32(255, 80, 0, 255);
        }
        else if (Num == 5 && (StartRad < StaticMaster.rad || StaticMaster.rad < EndRad) && StaticMaster.MoveNum == Num)
        {
            ImageColor.color = new Color32(255, 80, 0, 255);
        }
        else if (StartRad < StaticMaster.rad && StaticMaster.rad < EndRad && StaticMaster.MoveNum == Num)
        {
            ImageColor.color = new Color32(255, 80, 0, 255);
        }
        else if (StaticMaster.MoveNum == 0)
        {
            ImageColor.color = new Color32(255, 255, 255, 165);
        }


        if (StaticMaster.MoveNum == Num)
        {

            // StaticMaster.SP = false;
            //  ImageColor.color = new Color32(255, 80, 0, 255);
            value.value = (StaticMaster.privateDelta) / (100);
        }


        /*

        if (Num == 4 && (StartRad <= StaticMaster.rad || StaticMaster.rad < EndRad)
            && (StaticMaster.privateDelta < StaticMaster.Asobi && StaticMaster.Sp_privateDelta < StaticMaster.Asobi))
        {
            StaticMaster.MoveNum = Num;
        }
        else
        if (StartRad <= StaticMaster.rad && StaticMaster.rad < EndRad && (StaticMaster.privateDelta < StaticMaster.Asobi && StaticMaster.Sp_privateDelta < StaticMaster.Asobi))
        {
              StaticMaster.MoveNum = Num;
            
        }
        else
        {
            value.value = 0;
        }
       if(StaticMaster.MoveNum == Num) {
           // StaticMaster.SP = false;
            value.value = (StaticMaster.privateDelta + StaticMaster.Asobi) / (100 + StaticMaster.Asobi);
        }
       */

        //if (StaticMaster.MoveNum == Num)
        //{
        //    if (Num == 6)
        //    {
        //        value.value = (StaticMaster.Sp_privateDelta) / (100);
        //        if(( StaticMaster.Sp_privateDelta > StaticMaster.Asobi))
        //        {
        //            value.value = (StaticMaster.Asobi) / (100);
        //            if (StaticMaster.SP_Full == true)
        //            {
        //                if (StaticMaster.rad < - 22.5 && StaticMaster.rad >-67.5)
        //                {
        //                    Debug.Log("Atttack0");
        //                    StaticMaster.sp_AttackNum = 0;
        //                    StaticMaster.SP = true;
        //                }

        //                if (StaticMaster.rad < -67.5 && StaticMaster.rad > -112.5)
        //                {
        //                    Debug.Log("Atttack1");
        //                    StaticMaster.sp_AttackNum = 1;
        //                    StaticMaster.SP = true;
        //                }

        //                if (StaticMaster.rad < -112.5 && StaticMaster.rad > -157.5)
        //                {
        //                    Debug.Log("Atttack2");
        //                    StaticMaster.sp_AttackNum = 2;
        //                    StaticMaster.SP = true;
        //                }
        //            }
        //        }     
        //    }
        //    else
        //    {
        //        StaticMaster.SP = false;
        //        value.value = (StaticMaster.privateDelta+StaticMaster.Asobi) / (100+StaticMaster.Asobi);
        //    }
        //}

    }
}