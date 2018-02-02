using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTimeSave : MonoBehaviour {
    public float timeCount;
    private float count;
	// Use this for initialization
	void Start () {
        count = timeCount;
	}
	
	// Update is called once per frame
	void Update () {
        count -= 0.1f;
        if (count < 0) Destroy(gameObject);
	}
}
