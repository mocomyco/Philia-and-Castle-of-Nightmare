using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMove : MonoBehaviour {
    public float ShadowRadius;
    public float ShadowAnimationSpeed;
    private Vector3 FirstScale;
    private bool on = true;
    private float NowScale;
	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(ShadowRadius, ShadowRadius, ShadowRadius);
        FirstScale = transform.localScale;
        transform.localScale = new Vector3(ShadowRadius/3, ShadowRadius/3, ShadowRadius/3);
        NowScale = transform.localScale.x;
    }
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(NowScale, NowScale, NowScale);
        if(transform.localScale.x >= FirstScale.x)
        {
            on = false;
        }
        if(transform.localScale.x <= FirstScale.x / 4 * 3)
        {
            on = true;
        }
		if(on == true)
        {
            NowScale += ShadowAnimationSpeed * Time.deltaTime;
        }
        if (on == false)
        {
            NowScale -= ShadowAnimationSpeed * Time.deltaTime;
        }
	}
}
