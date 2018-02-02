using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour {
    //public GameObject MaineCamera;
    public GameObject WindowCamera;
    public GameObject TapToSkip;
    public GameObject Background;
    public GameObject Window;
    public GameObject TapToStageSelect;
    public GameObject StageSelect;
    public float AnimationTime;
    private float Nowtime = 0.0f;
    private bool AnimationFinish = false;
    private int ScreenCount = 0;

    //シャドオブジェクト関連
    public GameObject SyadoRun;//シャドちゃんの走るオブジェクト
    public GameObject SyadoJump;//シャドちゃんのジャンプオブジェクト
    public GameObject SyadoDoyagao;//シャドちゃんのどや顔オブジェクト
    public GameObject SyadoDoyagaoVer2;

    //その他
    private string a = "";
    public AudioSource click;
    public AudioSource ClearBGM;

    // Use this for initialization
    void Start () {
        //MaineCamera.SetActive(true);
        WindowCamera.SetActive(false);
        TapToSkip.SetActive(false);
        Background.SetActive(false);
        Window.SetActive(false);
        TapToStageSelect.SetActive(false);
        StageSelect.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (AnimationFinish == false) Nowtime += Time.deltaTime;
        if(Nowtime >= AnimationTime)
        {
            Nowtime = 0.0f;
            AnimationFinish = true;
            ScreenCount = 2;
        }
        if(Input.GetMouseButtonDown(0) && ScreenCount <= 2)//画面が押されたとき
        {
            ScreenCount += 1;
        }
        if(ScreenCount ==1)
        {
            TapToSkip.SetActive(true);    
        }
        else if (ScreenCount == 2)
        {
            //↓以下追加部分(2017/08/26)
            SyadoRun.SetActive(false);
            SyadoJump.SetActive(false);
            SyadoDoyagao.SetActive(false);
            SyadoDoyagaoVer2.SetActive(true);
            ClearBGM.Stop();
            //↑以上追加部分(2017/08/26)
            Nowtime = 0.0f;
            AnimationFinish = true;
            Time.timeScale = 0.0f;
            //MaineCamera.SetActive(false);
            WindowCamera.SetActive(true);
            TapToSkip.SetActive(false);
            Background.SetActive(true);
            Window.SetActive(true);
            TapToStageSelect.SetActive(true);
        }
        else if(ScreenCount == 3)
        {
            click.Play();//2017/08/27追加
            StaticMaster.StageName = a;//バグ防止
            SceneManager.LoadScene("Select");
        }
    }

 
}
