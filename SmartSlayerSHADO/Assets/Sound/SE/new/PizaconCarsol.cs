using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizaconCarsol : MonoBehaviour {
    private int carsolNum;
    private AudioSource cursor;
	// Use this for initialization
	void Start () {
        cursor = GetComponent<AudioSource>();
        carsolNum = StaticMaster.radNum;
	}
	
	// Update is called once per frame
	void Update () {
		if(carsolNum != StaticMaster.radNum)
        {
            carsolNum = StaticMaster.radNum;
            if (carsolNum != 0&&!cursor.isPlaying) cursor.Play();
        }
	}
}
