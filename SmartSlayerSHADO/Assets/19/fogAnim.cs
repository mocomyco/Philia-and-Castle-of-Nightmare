using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogAnim : MonoBehaviour {

    public float[] fogSpeed;

    public GameObject[] fog;

    public GameObject fogPa;

    void Start()
    {

    }

	void Update () {
        for(int i = 0; i < fog.Length; i++)
        {
            fog[i].transform.position += new Vector3(0, 0, fogSpeed[i]*Time.deltaTime);

            if(fog[i].transform.position.z < fogPa.transform.position.z)
            {
                fog[i].transform.position = new Vector3(fog[i].transform.position.x, fog[i].transform.position.y, fogPa.transform.position.z);
                fogSpeed[i] *= -1;
            }
            if (fog[i].transform.position.z > fogPa.transform.position.z + 1)
            {
                fog[i].transform.position = new Vector3(fog[i].transform.position.x, fog[i].transform.position.y, fogPa.transform.position.z+1);
                fogSpeed[i] *= -1; 
            }
        }	
	}
}
