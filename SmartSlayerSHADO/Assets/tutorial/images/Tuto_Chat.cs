using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto_Chat : MonoBehaviour {

    public string[] nobelText;
    public Text nobel;
    // public GameObject[] EngSlide;
    public Image pauseCanvas;
    private int nowSlideNum;
    public Tuto_States tutoStates;
   
    public AudioSource BGM;
    public AudioSource SE;


    void Start()
    {
        
        StaticMaster.tutorial = true;
        nowSlideNum = 0;
        if (pauseCanvas.enabled == false) pauseCanvas.enabled = true;

        ///
        /// ノベルテキストの０番から開始。無ければ読み込まない。
        ///
        if (nobelText.Length >0) nobel.text = nobelText[0];



        //if (StaticMaster.Language == "Japanese")
        //{

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


    void Update()
    {
        ///
        ///
        StaticMaster.AnchorNum = 3;

        if (Input.GetMouseButtonDown(0))
        {

            nowSlideNum += 1;

            if (nowSlideNum >= nobelText.Length)
            {
                BGM.volume = 1;
                StaticMaster.AnchorNum = 1;
                pauseCanvas.enabled = false;
                tutoStates.SendMessage("NextContentsNum");
                gameObject.SetActive(false);

            }else nobel.text = nobelText[nowSlideNum];


            ///全回数で次へ
            //if(nowSlideNum>nobelText.Length)

            //if (StaticMaster.Language == "Japanese")
            //{

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

        }
    }
}

