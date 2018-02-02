using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadoAttackParticle : MonoBehaviour {

    private UI _UI;
    public GameObject[] particle;
	// Use this for initialization
	void Start () {
        _UI = GameObject.Find("GameSystem").GetComponent<UI>();
        particle[0].SetActive(false);
        particle[1].SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(_UI.HoldState);
            if(_UI.HoldState == "SP")
        {
            particle[0].SetActive(true);
            particle[1].SetActive(false);
        }
        else if (_UI.HoldState == "StayAttack")
        {
            particle[1].SetActive(true);
            particle[0].SetActive(false);
        }
        else
        {
            particle[0].SetActive(false);
            particle[1].SetActive(false);
        }
	}
}
