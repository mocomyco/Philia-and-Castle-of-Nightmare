using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCTRL : MonoBehaviour {
    private AudioSource aSource;
    public string Name;

    private bool SpSwich;
    
    //private Target _Target;
    //public int TargetSENum;
    /// <summary>
    /// -----TargetSENum------
    /// １から12まで設定できる。
    /// 1～6はCursor01_01～Cursor01_06に対応
    /// 7～9はCursor04_01～Cursor04_06に対応
    /// </summary>
    /// 

    //private ActionSE _ActionSE;
    //public int EnterSENum;
    //public int CancelSENum;
    /// <summary>
    /// ------ActionSE系-----
    /// EnterSENumは1～3まで設定できる
    /// CanselSENumは1のみ設定できる
    /// </summary>
	void Awake()
    {
        SpSwich = false;
    }

	void Start () {
        
        aSource = GetComponent<AudioSource>();
        //_Target = GameObject.Find("Target").GetComponent<Target>();
        //_Target.SendMessage("SoundNum", TargetSENum);
        //_ActionSE = GameObject.Find("Action").GetComponent<ActionSE>();
        //_ActionSE.SendMessage("SoundNumEnter",EnterSENum);
        //_ActionSE.SendMessage("SoundNumCancel", CancelSENum);
    }

    void Update()
    {

        if (StaticMaster.SP_Full == true)
        {
                if (Name == "SuperCharge" && SpSwich == false)
                {
                    aSource.Play();
                    //Debug.Log(StaticMaster.SP_Full);
                }
                SpSwich = true;
        }
        else
        {
            SpSwich = false;
        }
    }
}
