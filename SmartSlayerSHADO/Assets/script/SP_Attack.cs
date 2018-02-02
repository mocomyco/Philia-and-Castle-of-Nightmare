using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Attack : MonoBehaviour {
    //spの斬撃の移動のみのスクリプト
    public float speed;
    public float destroyPos_z;
    private float nowPos_z;

    void Start () {
        nowPos_z = transform.position.z;
	}

    void Update()
    {
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        if (nowPos_z + destroyPos_z <= transform.position.z)
        {
            StaticMaster.SP_AttackUse = false;
            Destroy(gameObject);
        }
    }
}
