using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Hp : MonoBehaviour {
    public Image[] HP;//HPのイメージ入れてね
    public Image[] LostHP;//減ったHPのイメージ入れてね
    public float X, Y;//HPの位置を決めてね
    private int a;
   // private bool HpLost = false;

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < HP.Length; i++)
        {
            HP[i].rectTransform.anchoredPosition = new Vector2(X*i, Y);
            LostHP[i].rectTransform.anchoredPosition = new Vector2(X * i, Y);
        }
        a = HP.Length;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("a")) LostHp();//試しで使用
    }

    void LostHp()//ここをSendMessageか何かで呼び出せばHPが1減る
    {
       if(a >= 1) a -= 1;
        HP[a].GetComponent<Image>().enabled = false;
    }
}
