using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    [Header("X軸にスクロールする速さ")]
    public float XSpeed=0.2f;

    [Header("Y軸にスクロールする速さ")]
    public float YSpeed = 0.2f;

    void Update()
    {
        float Xscroll = Mathf.Repeat(Time.time * XSpeed, 1);
        float Yscroll = Mathf.Repeat(Time.time * YSpeed, 1);
        Vector2 offset = new Vector2(Xscroll, Yscroll);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
