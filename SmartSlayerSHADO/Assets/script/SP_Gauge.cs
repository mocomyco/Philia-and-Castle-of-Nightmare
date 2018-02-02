using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SP_Gauge : MonoBehaviour {
    public Image SP_UI;
    public float DestroyEnemyCharge;
    public float WalkCharge;
    public GameObject Player;
    public GameObject[] sp_Attack;
    public float MaxPos_z;
    public bool Cheack_Pos_x;
    public int sp2_z;
   
	void Update () {
        if (StaticMaster.WalkChargeBool == true)
        {
            if (Player.transform.position.z > MaxPos_z)
            {
                MaxPos_z = Player.transform.position.z;
                SP_UI.fillAmount += WalkCharge / 100;
            }
            StaticMaster.WalkChargeBool = false;
        }
    }

    void SP()
    {
        if (SP_UI.fillAmount >= 1.0)
        {
            StaticMaster.SP_AttackUse = true;
            SP_UI.fillAmount = 0;
            StaticMaster.SP_Full = false;
        }
    }

    public void InstansSpAttack()
    {
        Instantiate(sp_Attack[0], new Vector3(Player.transform.position.x, 1.0f, Player.transform.position.z), Quaternion.Euler(90, 0, 0));
    }

    void DestroyEnemyChargeBool()
    {
        if (StaticMaster.SP_AttackUse == false)
        {
            SP_UI.fillAmount += DestroyEnemyCharge / 100;
        }
    }
}
