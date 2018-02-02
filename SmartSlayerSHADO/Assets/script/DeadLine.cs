using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour {
    public GameObject bar;
    private float Kyori = -1.5f;
    public GameObject BlackOut;

	void Update () {
        if(transform.position.z < 1) {
            bar.transform.position = new Vector3(bar.transform.position.x, bar.transform.position.y, -0.5f);
        }
        else
        {
            bar.transform.position = new Vector3(bar.transform.position.x, bar.transform.position.y, transform.position.z + Kyori);
        }
        if (BlackOut != null)
        {
            if (transform.position.z <= 0)
            {
                BlackOut.transform.position = new Vector3(BlackOut.transform.position.x, BlackOut.transform.position.y, 5.5f);
            }
            else
            {
                BlackOut.transform.position = new Vector3(BlackOut.transform.position.x, BlackOut.transform.position.y, transform.position.z + Kyori + 7);
            }
        }
    }
}
