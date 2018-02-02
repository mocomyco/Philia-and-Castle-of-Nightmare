using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour {
    //一時停止ボタンに張り付け
    //HirarchyからPauseCanvasをパブリックで指定する
    private Button button;
    public Image _PauseCanvas;
    public GameObject _PauseImage;
    private bool pausing;
    public AudioSource BGM;
    private UI ui;
    private AnchorNumber anc;
    public string[] Name;
    private AudioSource click;
  
    private int sceneInt;


	void Start() {
       StaticMaster. clickSwitch= false;
        click = GameObject.Find("Click").GetComponent<AudioSource>();
        pausing = false;
        if (!_PauseCanvas) Debug.Log("Not Find PauseCanvas!!");
        else _PauseCanvas.enabled = false;
        ui = GameObject.Find("GameSystem").GetComponent<UI>();
        button = GetComponent<Button>();
        anc = GetComponent<AnchorNumber>();
        Name[0] =  SceneManager.GetActiveScene().name;
    }
	
    void Update()
    {
        if (ui.Clone)
        {
            button.enabled = false;
            anc.Num = 0;
        }
        else
        {
            button.enabled = true;
            anc.Num = 2;
        }

        if (StaticMaster.clickSwitch == true&&!click.isPlaying)
        {
            StaticMaster.clickSwitch = false;
            _PauseCanvas.enabled = false;
            pausing = false;
            Time.timeScale = 1;
            BGM.UnPause();
            _PauseImage.SetActive(false);
            _PauseCanvas.color = new Color(_PauseCanvas.color.r, _PauseCanvas.color.g, _PauseCanvas.color.b, _PauseCanvas.color.a - 0.5f);
            SceneManager.LoadScene(Name[sceneInt]);
        }
    }

    public void PauseSwitch()
    {
       
        if (ui.Clone != null)
        {
            return;
        }
        if (pausing == false)
        {
            _PauseCanvas.enabled = true;
            pausing = true;
            Time.timeScale = 0;
            BGM.Pause();
            _PauseImage.SetActive(true);
            _PauseCanvas.color = new Color(_PauseCanvas.color.r, _PauseCanvas.color.g, _PauseCanvas.color.b, _PauseCanvas.color.a + 0.5f);
        }
        else
        {
            _PauseCanvas.enabled = false;
            pausing = false;
            Time.timeScale = 1;
            BGM.UnPause();
            _PauseImage.SetActive(false);
            _PauseCanvas.color = new Color(_PauseCanvas.color.r, _PauseCanvas.color.g, _PauseCanvas.color.b, _PauseCanvas.color.a - 0.5f);
        }
    }

    public void PauseSwitch_SceneChange(int i)
    {
        sceneInt = i;
        if (!click.isPlaying && StaticMaster.clickSwitch == false)
        {
            click.Play();
            StaticMaster.clickSwitch = true;
        }
    }
}
