using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour {
    public GameObject Fade;//フェードの画像を取得
    private  bool FadeOutOk = false;//フェードを実行するかどうかの判定(実行する：true・実行しない：false)
    public float FadeSpeed;//フェードアウトする速さ
    private float FadeBrightness = 0.0f;//フェード画像の明度
    
    void Start () {
        Fade.GetComponent<Image>().color = new Color(0, 0, 0, FadeBrightness);//フェードの画像の色を取得
        Fade.SetActive(false);//フェードの画僧を非表示する
    }
	
	void Update () {
		if(FadeOutOk == true)//フェードの処理を行えるなら実行
        {
            Fade.GetComponent<Image>().color = new Color(0, 0, 0, FadeBrightness);//フェードの画像の色を更新
            FadeBrightness += FadeSpeed * Time.deltaTime;//フェードの明度を更新
            if(FadeBrightness >= 1.0f)//明度が１を超えたら実行
            {
                FadeBrightness = 1.0f;
                SceneManager.LoadScene("次のシーンの名前");//移りたいシーンの名前をここに書く
                FadeOutOk = false;//フェードの処理をやめる
            }
        }
	}

    void FadeOutGo()//フェードアウトを実行(SendMessageでここを呼び出せばOk)
    {
        FadeOutOk = true;
        Fade.SetActive(true);//フェードの画像を表示する
    }
}
