using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPButton : MonoBehaviour {
    public SP_Gauge spGauge;
    public PlayerMove PMove;
    private UI ui;
    private Button button;
    private AnchorNumber anc;
    
    // Use this for initialization
    void Start()
    {
        ui = GameObject.Find("GameSystem").GetComponent<UI>();
        button = GetComponent<Button>();
        anc = GetComponent<AnchorNumber>();
    }

    // Update is called once per frame
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
    }
    public void SpButton()
    {
        if (ui.Clone != null||StaticMaster.PlayerAnim!="Idle") return;
        if (StaticMaster.SP_Full == true&&StaticMaster.privateDelta==0)
        {
            spGauge.SendMessage("SP");
            PMove.SendMessage("SP_Attack");
        }
    }
}
