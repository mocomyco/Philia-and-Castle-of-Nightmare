using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPButton : MonoBehaviour {
    [SerializeField]
    [Header("フィリアのSPゲージ")]
    private SP_Gauge spGauge;

    [SerializeField]
    [Header("必殺技エフェクト発動スクリプト")]
    private SpecialAttackAnimTrigger specialAttackAnimTrigger;

    
    public PlayerMove PMove;
    private UI ui;
    private Button button;
    private AnchorNumber anc;


    
   void StartGetComponent()
    {
        ui = GameObject.Find("GameSystem").GetComponent<UI>();
        button = GetComponent<Button>();
        anc = GetComponent<AnchorNumber>();
        //PlayerのSP
        spGauge = GameObject.Find("PlayerStates/Philia_SP").GetComponent<SP_Gauge>();

        //必殺技発動のスクリプト
        specialAttackAnimTrigger = GameObject.Find("Player/philia_idle").GetComponent<SpecialAttackAnimTrigger>();
    }

    void Start()
    {
        StartGetComponent();
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
            specialAttackAnimTrigger.SendMessage("SpecialAttack");
        }
    }
}
