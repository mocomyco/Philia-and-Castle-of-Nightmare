using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_UserPlay : MonoBehaviour {
    public int stateNum;
    public Tuto_States tutoStates;
    public GameObject pizakon;
    public bool Test;
    public UI ui;
    public int uiNum;

    public GameObject DestroyCounter;
    // Use this for initialization
    void Start()
    {
        Debug.Log(stateNum + "Start");
        ui.tutorial = uiNum;
        
        pizakon.SetActive(true);
    }
    void Update()
    {
       if(ui.tutorial == uiNum) StaticMaster.tutorial = false;

        if (DestroyCounter == null)
        {
            End();
        }
    }
    void End()
    {
        pizakon.SetActive(false);
        tutoStates.SendMessage("NextContentsNum", stateNum);
    }
}
