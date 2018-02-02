using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tenmetu : MonoBehaviour {
    private Image image;
    private float alfa;
    private bool State;
    float red, green, blue;
    public float speed;
    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
        alfa = GetComponent<Image>().color.a;
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        if (alfa ==1) State = true;
        else State = false;
	}
	
	// Update is called once per frame
	void Update () {
        switch (State)
        {
            case false:
                alfa += speed;
                if (alfa >0.95) State = true;
                Debug.Log("上昇中");
                break;
            case true:
                alfa -= speed;
                if (alfa <0.05) State = false;
                Debug.Log("下降中");
                break;
        }

        image.color =  new Color(red, green, blue, alfa);
    }
}
