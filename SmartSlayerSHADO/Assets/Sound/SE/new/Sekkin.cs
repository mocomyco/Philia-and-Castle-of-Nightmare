using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sekkin : MonoBehaviour {
    private AudioSource sekkin;
    public float waitTime;
    private bool juuhukubousi;
	// Use this for initialization
	void Start () {
        sekkin = GetComponent<AudioSource>();
        sekkin.Play();
        juuhukubousi = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!sekkin.isPlaying&&juuhukubousi == false)
        {
            Invoke("SoundPlay",waitTime);
            juuhukubousi = true;
        }
        sekkin.volume = StaticMaster.privateDelta / 200;
	}

    void SoundPlay()
    {
        sekkin.Play();
        juuhukubousi = false;
    }
}
