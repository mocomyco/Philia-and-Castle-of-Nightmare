using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto_Image : MonoBehaviour {
    public GameObject[] slide;
    public GameObject[] EngSlide;
    public Image pauseCanvas;
    private int nowSlideNum;
    public Tuto_States tutoStates;
    public int stateNum;
    public AudioSource BGM;
    public AudioSource SE;
    // Use this for initialization
    void Start()
    {

        Debug.Log(stateNum + "Start");
        StaticMaster.tutorial = true;
        nowSlideNum = 0;
        if (pauseCanvas.enabled == false) pauseCanvas.enabled = true;
        //if (StaticMaster.Language == "Japanese")
        //{
            for (int i = 0; i < slide.Length; i++)
            {
                if (i == nowSlideNum)
                {
                    slide[i].SetActive(true);
                }
                else
                {
                    slide[i].SetActive(false);
                }
            }
            //for (int i = 0; i < EngSlide.Length; i++)
            //{
            //    EngSlide[i].SetActive(false);
            //}
        //}
        //else if (StaticMaster.Language == "English")
        //{
        //    for (int i = 0; i < EngSlide.Length; i++)
        //    {
        //        if (i == nowSlideNum)
        //        {
        //            EngSlide[i].SetActive(true);
        //        }
        //        else
        //        {
        //            EngSlide[i].SetActive(false);
        //        }
        //    }

        //    for (int i = 0; i < slide.Length; i++)
        //    {
        //        slide[i].SetActive(false);
        //    }
        //}
        SE.Play();
        BGM.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        StaticMaster.AnchorNum = 3;

        if (Input.GetMouseButtonDown(0))
        {

            nowSlideNum += 1;
            //if (StaticMaster.Language == "Japanese")
            //{
                for (int i = 0; i < slide.Length; i++)
                {
                    if (i == nowSlideNum)
                    {
                        slide[i].SetActive(true);
                    }
                    else
                    {
                        slide[i].SetActive(false);
                    }
            }
            //}

            //else if (StaticMaster.Language == "English")
            //{
            //    for (int i = 0; i < EngSlide.Length; i++)
            //    {
            //        if (i == nowSlideNum)
            //        {
            //            EngSlide[i].SetActive(true);
            //        }
            //        else
            //        {
            //            EngSlide[i].SetActive(false);
            //        }
            //    }
            //}
            if (nowSlideNum >= slide.Length)
            {
                BGM.volume = 1;
                StaticMaster.AnchorNum = 1;
                pauseCanvas.enabled = false;
                tutoStates.SendMessage("NextContentsNum", stateNum);
                gameObject.SetActive(false);

            }
        }
    }
}
