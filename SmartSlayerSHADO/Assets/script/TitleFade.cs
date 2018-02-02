using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleFade : MonoBehaviour {
    public Vector3 Mouse;//タッチした場所
    public float NotTouchZone;//タッチが行われない範囲の数値
    public GameObject Fade;//フェードインアウトの画像を取得
    public float FadeSpeed;//フェードを行う速さ
    public float FadeOutSpeed;
    private float FadeBrightness = 1.0f;//フェードインアウトの現在明度
    private bool FadeInOROut = true;//フェードインの処理かフェードアウトの処理か判定
    private bool FadeGo = true;//フェードインの処理を行うか否か
    private bool NowFadeTouchOk = false;//フェードアウト中はタッチ画面が反応しない判定
    private bool CancelTouch = true;//フェードイン中にタッチ画面が押されたときにすぐ明るくする判定

	public int hayaokuri = 0;
	public Title_Anim[] Title_Anim;
    public Animator anim;
	public GameObject RogoAnim;
    public GameObject RogoNoAnim;

    public AudioSource click;
    public bool flag;

    public Image shado;
    public Image tap;
    public Image tap_txt;
    private float tapFade;
    private float speed;
    private int tapFadeFlag;
    
    void Start () {
       Fade.GetComponent<Image>().color = new Color(0, 0, 0, FadeBrightness);
    }

    void Update() {
        if(shado.color.a >= 1.0f)
        {
            tapFade += speed*Time.deltaTime;
            if (tapFade <= 0.01f)
            {
                speed = 1f;
            }
            if (tapFade >= 0.99f)
            {
                speed = -1f;
            }
            tap.color = new Color(tap.color.r, tap.color.g, tap.color.b, 0.7f);
            tap_txt.color = new Color(tap_txt.color.r, tap_txt.color.g, tap_txt.color.b, tapFade);
        }
        if (flag == true && click.time == 0.0f && click.isPlaying == false&& FadeBrightness>=1.0f)
        {
            flag = false;
            SceneManager.LoadScene("Select");
        }
        Fade.GetComponent<Image>().color = new Color(0, 0, 0, FadeBrightness);//フェードの明度操作
        if (FadeGo == true)//フェードイン・フェードアウトの操作を行えるようにする
        {
            if (FadeInOROut == true)
            {
                FadeIn();//フェードインの処理を実行
                if(Input.GetMouseButtonDown(0)&&StaticMaster.AnchorNum==0)
                {
                    AnimationCancel();
                }
            }
            else if( FadeInOROut == false)
            {
                FadeOut();//フェードアウトの処理を実行
            }
        }
        if(NowFadeTouchOk == false)
        { 
			if(Title_Anim[2].syuuryou ==1){
                if (Input.GetMouseButtonDown(0) && StaticMaster.AnchorNum == 0)//画面をタッチしたら
                {
                    Mouse = Input.mousePosition;//タッチした位置を取得
                    if (Mouse.x < Screen.width * (1.0f - NotTouchZone) && Mouse.x > Screen.width * NotTouchZone)
                    {
                        if (Mouse.y < Screen.height *(1.0f - NotTouchZone) && Mouse.y > Screen.height  * NotTouchZone)//タッチが可能な範囲内かどうか判定
                        {
                            click.Play();
                            flag = true;
                            Fade.SetActive(true);
                            NowFadeTouchOk = true;
                            FadeGo = true;
                        }
                    }
                }
            }

			if(Title_Anim[2].syuuryou ==0){
				if (Input.GetMouseButtonDown(0) && StaticMaster.AnchorNum == 0)//画面をタッチしたら
				{
					Mouse = Input.mousePosition;//タッチした位置を取得
					if (Mouse.x < Screen.width * (1.0f - NotTouchZone) && Mouse.x > Screen.width * NotTouchZone)
					{
						if (Mouse.y < Screen.height *(1.0f - NotTouchZone) && Mouse.y > Screen.height  * NotTouchZone)//タッチが可能な範囲内かどうか判定
						{
							hayaokuri = 1;
                            Title_Anim[1].tien = 0;
                            Title_Anim[2].tien = 0;
							Title_Anim[3].tien = 0;
                            RogoAnim.SetActive(false);
							RogoNoAnim.SetActive (true);
						}
					}
				}   　
			}
		}
	}

    void FadeIn()//フェードインの処理
    {
        FadeBrightness -= FadeSpeed * Time.deltaTime;
        if(FadeBrightness <= 0.0f)
        {
            FadeBrightness = 0.0f;
            FadeInOROut = false;
            FadeGo = false;
            Fade.SetActive(false);
            NowFadeTouchOk = false;
            CancelTouch = false;
        }
    }

    void FadeOut()//フェードアウトの処理
    {
        FadeBrightness += FadeOutSpeed * Time.deltaTime;
        if(FadeBrightness >= 1.0f)
        {
            FadeBrightness = 1.0f;
            FadeInOROut = true;
            FadeGo = false;
        }
    }

    void AnimationCancel()//Animation中にTouch画面を押したら処理
    {
        if(CancelTouch == true)
        {
            FadeBrightness = 0.05f;
            CancelTouch = false;
        }
    }

}

