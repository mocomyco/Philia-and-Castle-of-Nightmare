using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_TimeSpece : MonoBehaviour {
    public int WaitTime;
    public Tuto_States tutostate;
    private bool swich;
    // Use this for initialization
    void Start()
    {
        swich = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (swich == false)
        {
            StaticMaster.tutorial = true;
            Invoke("System", WaitTime);
            swich = true;
        }
    }

    void System()
    {
        tutostate.SendMessage("NextContentsNum");
    }
}
