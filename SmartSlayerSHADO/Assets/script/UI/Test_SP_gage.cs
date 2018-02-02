using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_SP_gage : MonoBehaviour {
	public SP_Gauge gage;
	private Image image;
	public ParticleSystem HISATU;
	// Use this for initialization
	void Start()
	{
		image = GetComponent<Image>();
		HISATU.Stop();
	}

	// Update is called once per frame
	void Update()
	{
		if (gage.SP_UI.fillAmount < 1) {
			image.color = new Color (0.5f, 0.5f, 0.5f, 1);
			HISATU.Stop();
		} else {
			image.color = new Color (1, 1, 1, 1);
			StaticMaster.SP_Full = true;
			HISATU.Play();
		}
        



    }
}


