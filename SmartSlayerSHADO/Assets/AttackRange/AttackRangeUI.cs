using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeUI : MonoBehaviour {


	// Use this for initialization
	void Start () {
        StaticMaster.AttackRange = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AttackRangeChange()
    {
        if (StaticMaster.AttackRange == false)
        {
            StaticMaster.AttackRange = true;
        }
        else if(StaticMaster.AttackRange == true)
        {
            StaticMaster.AttackRange = false;
        }
    }

}
