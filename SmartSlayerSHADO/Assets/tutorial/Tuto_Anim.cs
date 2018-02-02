using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto_Anim : MonoBehaviour {
    public int stateNum;
    public Tuto_States tutosute;
    public Image SpGauge;
    // Use this for initialization
    void Start()
    {
        SpGauge.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void End()
    {
        tutosute.SendMessage("NextContentsNum", stateNum);
    }
}
