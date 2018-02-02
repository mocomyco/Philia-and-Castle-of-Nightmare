using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleLanguageButton : MonoBehaviour {
    private Image image;
    public string lang;
	// Use this for initialization
	void Start () {
       image= GetComponent<Image>();	
	}
	
	// Update is called once per frame
	void Update () {
		//if(StaticMaster.Language == lang)
  //      {
  //          image.color = new Color32(255, 169, 53,255);
  //      }
  //      else
  //      {
  //          image.color = new Color32(255, 255,255, 255);
  //      }
	}
}
