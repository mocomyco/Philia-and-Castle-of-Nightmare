using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour {
    public GameObject target;
    public GameObject Camera;
    public int tx;
    public int tz;

	void Update () {

        //Targetの移動
        if (Input.GetKeyDown("d"))
        {
            tx += 1;
            if (tx > StaticMaster.Board_x - 1) tx = 0;
        }
        if (Input.GetKeyDown("a"))
        {
            tx -= 1;
            if (tx < 0) tx = StaticMaster.Board_x - 1;
        }

        if (Input.GetKeyDown("w"))
        {

            tz += 1;
            if (tz > StaticMaster.Board_z - 1) tz = 0;

        }
        if (Input.GetKeyDown("s"))
        {

            tz -= 1;
            if (tz < 0) tz = StaticMaster.Board_z - 1;
        }
        target.transform.position = new Vector3(tx, transform.position.y, tz);


        // Cameraのズーム
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Camera.transform.position += new Vector3(0, -1, 0)*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Camera.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
        }
    }
}
