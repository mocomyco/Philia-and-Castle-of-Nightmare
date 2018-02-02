using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_Anim : MonoBehaviour {
	float alfa;
	float speed = 0.02f;
	public float tien = 0f;
	public int shikibetu = 0;
	public int syuuryou =0;
	public int slime = 0;
	float red, green, blue;
	private TitleFade Title;

	void Start () {
		Title = GameObject.Find ("Canvas").GetComponent<TitleFade> ();
		red = GetComponent<Image> ().color.r;
		green = GetComponent<Image> ().color.g;
		blue = GetComponent<Image> ().color.b;
	}

	void Update () {


		Invoke ("toumei", tien);


		if (Title.hayaokuri == 1 && slime == 0) {
			alfa += 255;
			syuuryou = 1;
		}

		if (Title.hayaokuri == 1 && slime == 1) {
			alfa -= 255;
			syuuryou = 1;
		}

		if ((slime == 2)) {
			alfa -= Time.deltaTime;
		}
	}

	void toumei(){
		GetComponent<Image> ().color = new Color (red, green, blue, alfa);
		alfa += speed;

		if ((slime == 0)) {
			Invoke ("touch", 2f);
		}

		if ((slime == 1)) {
			Invoke ("touch", 3f);
		}
	}

	void touch(){
		if ((shikibetu == 1)) {
			syuuryou = 1;
		}	
		if (slime == 1) {
			slime = 2;
		}
	}
}
