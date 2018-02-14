using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto_Chat : MonoBehaviour {

    public string[] nobelText;
    private Text nobel;
    // public GameObject[] EngSlide;
    public Image pauseCanvas;
    private int nowSlideNum;
    public Tuto_States tutoStates;
   
    public AudioSource BGM;
    public AudioSource SE;

    [Header("フィリアの通常顔 Num0")]
    public Image _FiriaSimple;

    [Header("フィリアのスマイル Num1")]
    public Image _FiriaSmile;

    [Header("ぐるるるる・・・・ Num2")]
    public Image _Enemy01;

   


    [Header("フィリアの目をつぶる Num3")]
    public Image _FiriaCloseEye;

    [Header("フィリアの顔しまる Num4")]
    public Image _FiriaOko;

    [Header("フィリアの必殺 Num5")]
    public Image _FiriaAction;

    [Header("立ち絵スライドNum決め ※スライド数に合わせる")]
    public int[] CharaImages;

    void Start()
    {
        nobel = transform.FindChild("ChatWindow").transform.GetComponentInChildren<Text>();
        StaticMaster.tutorial = true;
        nowSlideNum = 0;
        if (pauseCanvas.enabled == false) pauseCanvas.enabled = true;


        ///
        /// ノベルテキストの０番から開始。無ければ読み込まない。
        ///
        if (nobelText.Length >0) nobel.text = nobelText[0];

        CharaSlider();


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

            }
            else
            {
                //ノベル再生
                nobel.text = nobelText[nowSlideNum];
                CharaSlider();
            }

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


    /// <summary>
    /// 立ち絵を表示させる
    /// </summary>
    private void CharaSlider()
    {

        //バグ防止
        if (nobelText.Length != CharaImages.Length) { Debug.Log("数字を合わせてくれ"); return; }

        //立ち絵初期化
        {
            if (_FiriaSimple) _FiriaSimple.enabled = false;
            if (_FiriaSmile) _FiriaSmile.enabled = false;
            if (_Enemy01) _Enemy01.enabled = false;
            if (_FiriaAction) _FiriaAction.enabled = false;
            if (_FiriaCloseEye) _FiriaCloseEye.enabled = false;
            if (_FiriaOko) _FiriaOko.enabled = false;
            
        }

        //立ち絵再生

        switch (CharaImages[nowSlideNum])
        {
            case 0:
                _FiriaSimple.enabled = true;
                break;
            case 1:
                _FiriaSmile.enabled = true;
                break;
            case 2:
                _Enemy01.enabled = true;
                break;
            case 3:
                _FiriaCloseEye.enabled = true;
                break;
            case 4:
                _FiriaOko.enabled = true;
                break;
            case 5:
                _FiriaAction.enabled = true;
                break;
        }

    }
}

