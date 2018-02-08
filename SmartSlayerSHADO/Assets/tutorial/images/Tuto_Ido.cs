using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tuto_Ido : MonoBehaviour {
    public Tuto_States tutoStates;
    public GameObject pizakon;
    public bool Test;
    public UI ui;
    public int uiNum;

    public int _IdouEndCount;
 
    void Start()
    {
        ui.tutorial = uiNum;

        pizakon.SetActive(true);
    }

    void Update()
    {
        if (ui.tutorial == uiNum) StaticMaster.tutorial = false;

        if (StaticMaster.Count == _IdouEndCount)
        {
            End();
        }
    }

    void End()
    {
        pizakon.SetActive(false);
        tutoStates.SendMessage("NextContentsNum");
    }
}

