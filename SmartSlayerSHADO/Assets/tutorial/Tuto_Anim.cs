using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto_Anim : MonoBehaviour {
 
    public Tuto_States tutosute;
    public Image SpGauge;
    /// <summary>
    /// うまくいかないのでテスト
    /// </summary>
    public float fill;
    void Start()
    {
        SpGauge.fillAmount = 1.0f;
        fill = 1.0f;
        
    }

    void Update()
    {
        SpGauge.fillAmount = fill;
    }

    void End()
    {
        tutosute.SendMessage("NextContentsNum");
    }
}
