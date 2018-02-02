using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour {
    static public string static_sceneName;
    public string sceneName;
    public int StageNumTenTimes;
    public int StageNumOneAmount;
    public AudioSource click;
    private int flag;

    public string NowStageName;//追加部分(2017/08/26・小林)

    void Start()
    {
        if (SceneManager.GetActiveScene().name!="Select") {
            if (int.Parse(SceneManager.GetActiveScene().name) >= 20)
            {
                NowStageName = "Stage" + "1" + (int.Parse(SceneManager.GetActiveScene().name) - 20);//19ステージまでなら自動入力
            }
            else if (int.Parse(SceneManager.GetActiveScene().name) >= 10)
            {
                NowStageName = "Stage" + "0" + (int.Parse(SceneManager.GetActiveScene().name) - 10);
            } }
    }


    void Update () {
        if (flag==1&&click.time == 0.0f && click.isPlaying == false)
        {
            flag = 0;
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1.0f;
        }
        if (flag == 2 && click.time == 0.0f && click.isPlaying == false)
        {
            flag = 0;
            SceneManager.LoadScene(StaticMaster.StageName);
            Time.timeScale = 1.0f;
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }

    void SceneChange_Button()//音入りシーンチェンジ(タイトル)
    {
        if (flag != 1)
        {
            click.Play();
            flag = 1;
        }
    }

    void SceneChange_Boss()//音入りシーンチェンジ(タイトル)
    {
        click.Play();
        flag = 1;
    }

    void StageSelect()//音入りシーンチェンジ(セレクト)
    {
        if (flag != 1)
        {
            StaticMaster.StageNum = StageNumTenTimes * 10 + StageNumOneAmount;
            sceneName = StaticMaster.StageNum.ToString();
            StaticMaster.StageName = sceneName;
            click.Play();
            flag = 1;
        }
    }

    void StageRetry()
    {
        if (flag != 2)
        {
            click.Play();
            flag = 2;
            SceneManager.LoadScene(StaticMaster.StageName);
        }
    }

    void NextStage()
    {
        StaticMaster.StageNum += 1;
        if (StaticMaster.StageNum % 10 != 6)
        {
            StaticMaster.StageName = StaticMaster.StageNum.ToString(); 
            SceneManager.LoadScene(StaticMaster.StageName);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        } 
    }

    void ClearSceneChange(string Name)
    {
        SceneManager.LoadScene(Name);
        StaticMaster.StageName = NowStageName;//追加部分(2017/08/26・小林)
    }
}
