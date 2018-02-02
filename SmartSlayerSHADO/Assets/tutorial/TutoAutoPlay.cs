using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoAutoPlay : MonoBehaviour {
    public int stateNum;
    public Tuto_States TState;

    public bool endBool;
    public Animator anim;
    private bool swith;
	// Use this for initialization
	void Start () {
        StaticMaster.tutorial = true;
        swith = false;
        anim.enabled = false;
        endBool = false;

        Debug.Log(stateNum + "Start");
    }
	
	// Update is called once per frame
	void Update () {
        if (anim.enabled == false) anim.enabled = true;
		if (endBool==true&&swith == false)
        {
            anim.enabled = false;
            swith = true;
            TState.SendMessage("NextContentsNum", stateNum);
        }
	}
}
