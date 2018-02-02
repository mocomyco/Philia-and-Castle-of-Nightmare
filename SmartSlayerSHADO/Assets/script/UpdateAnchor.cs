using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAnchor : MonoBehaviour {
    public int AnchorNum;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StaticMaster.AnchorNum = AnchorNum;
	}
}
