using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSE : MonoBehaviour {
   // private Animation _Animation;
    public AudioSource _SpecialAttack;
    public AudioSource _RotationAttack;
    public AudioSource _FootStep;
    private SP_Gauge _SP_Gauge;
    public GameSystem _GameSystem;

    void Start()
    {
        //_Animation = GetComponent<Animation>();
        _SP_Gauge = GameObject.Find("HP&SP").GetComponent<SP_Gauge>();
    }

    public void SpecialAttack()
    {
        _GameSystem.SendMessage("sp");
       // _SpecialAttack.Play();
        _SP_Gauge.SendMessage("InstansSpAttack");
    }

    public void SpecialSE()
    {
        _SpecialAttack.Play();
    }

    public void RotationAttack()
    {
        _RotationAttack.Play();
    }

    public void FootStep()
    {
        _FootStep.Play();
    }
}
