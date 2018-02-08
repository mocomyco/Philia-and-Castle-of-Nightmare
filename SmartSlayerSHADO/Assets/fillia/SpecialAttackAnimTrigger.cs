using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackAnimTrigger : MonoBehaviour {

    /// <summary>
    /// 未実装のサウンド
    /// </summary>
    //public AudioSource _SpecialAttack;
    //public AudioSource _RotationAttack;
    //public AudioSource _FootStep;

    [SerializeField]
    [Header("フィリアのSPゲージ")]
    private SP_Gauge _SP_Gauge;
    private GameSystem _GameSystem;

    void StartGetComponent()
    {
        //PlayerのSP
        _SP_Gauge = GameObject.Find("PlayerStates/Philia_SP").GetComponent<SP_Gauge>();

        //GameSystem
        _GameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
    }

    void Start()
    {
        StartGetComponent();
    }

    /// <summary>
    /// 必殺処理が終わった時に必ず呼び出す
    /// </summary>
    public void SpecialAttack()
    {
        _GameSystem.SendMessage("sp");
        // _SpecialAttack.Play();
        _SP_Gauge.SendMessage("InstansSpAttack");
    }

    
    
    //public void SpecialSE()
    //{
    //    _SpecialAttack.Play();
    //}

    //public void RotationAttack()
    //{
    //    _RotationAttack.Play();
    //}

    //public void FootStep()
    //{
    //    _FootStep.Play();
    //}
}

