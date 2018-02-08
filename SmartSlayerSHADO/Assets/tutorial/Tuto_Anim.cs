using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto_Anim : MonoBehaviour {
 
    public Tuto_States tutosute;
    public Image SpGauge;

    void Start()
    {
        SpGauge.fillAmount = 1;
    }

    void End()
    {
        tutosute.SendMessage("NextContentsNum");
    }
}
