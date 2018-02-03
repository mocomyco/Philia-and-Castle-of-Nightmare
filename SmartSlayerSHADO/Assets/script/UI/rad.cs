using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rad : MonoBehaviour
{
    public int Num;
    public float StartRad, EndRad;
    public Image ImageColor;
    public Image fowardImage;
    private int CanvasScreenSize, GameObjectScreenSize;
    private Scrollbar value;
    public int tutorialStates;

    void Awake()
    {
        value = GetComponent<Scrollbar>();
    }

    void Start()
    {
        fowardImage.enabled = false;
    }

    void Update()
    {
        if (tutorialStates == 0)
        {
            if (PlayerMove.playerPos.x == StaticMaster.stageSizeMin)
            {
                if (Num == 6 || Num == 4 || Num == 5)
                {
                    return;
                }
            }
            if (PlayerMove.playerPos.x == StaticMaster.stageSizeMax)
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
            if (Num == 5 && (StartRad <= StaticMaster.rad || StaticMaster.rad < EndRad))
            {

                StaticMaster.MoveNum = Num;
            }
            else
            if (StartRad <= StaticMaster.rad && StaticMaster.rad < EndRad )
            {
                StaticMaster.MoveNum = Num;
            }
            else
            {
                value.value = 0;
            }
        }
        if (tutorialStates == 1)
        {
            if (StaticMaster.Asobi > StaticMaster.mag)
            {
                StaticMaster.MoveNum = 0;
                value.value = 0;
            }
            else
           if (Num == 3 && StartRad <= StaticMaster.rad && StaticMaster.rad < EndRad && StaticMaster.MoveNum == 0)
            {
                StaticMaster.MoveNum = Num;
            }
            else
            {
                value.value = 0;
            }

        }
        if (tutorialStates == 2)
        {
            if (StaticMaster.Asobi > StaticMaster.mag)
            {
                StaticMaster.MoveNum = 0;
                value.value = 0;
            }
            else
           if ((Num == 2 || Num == 4) && StartRad <= StaticMaster.rad && StaticMaster.rad < EndRad && StaticMaster.MoveNum == 0)
            {
                StaticMaster.MoveNum = Num;
            }
            else
            {
                value.value = 0;
            }

        }

        

            if (StaticMaster.mag == 0)
            {
            StaticMaster.radNum = 0;
                ImageColor.enabled = true;
                fowardImage.enabled = false;
            }
            else
            if (StaticMaster.MoveNum == 0 && ((Num == 5 && (StartRad < StaticMaster.rad || StaticMaster.rad < EndRad)) || (StartRad < StaticMaster.rad && StaticMaster.rad < EndRad)) && StaticMaster.Asobi > StaticMaster.mag)
            {
            StaticMaster.radNum = Num;
                ImageColor.enabled = false;
                fowardImage.enabled = true;
            }
            else if (Num == 5 && (StartRad < StaticMaster.rad || StaticMaster.rad < EndRad) && StaticMaster.MoveNum == Num)
            {
            StaticMaster.radNum = Num;
            ImageColor.enabled = false;
                fowardImage.enabled = true;
            }
            else if (StartRad < StaticMaster.rad && StaticMaster.rad < EndRad && StaticMaster.MoveNum == Num)
            {
            StaticMaster.radNum = Num;
            ImageColor.enabled = false;
                fowardImage.enabled = true;
            }
            else if (StaticMaster.MoveNum == 0)
            {
                ImageColor.enabled = true;
                fowardImage.enabled = false;
            }
            else if (StaticMaster.MoveNum != Num)
            {

                ImageColor.enabled = true;
                fowardImage.enabled = false;
            }

            if (StaticMaster.MoveNum == Num)
            {
                value.value = (StaticMaster.privateDelta) / (100);
            }
       
        
    }
}



