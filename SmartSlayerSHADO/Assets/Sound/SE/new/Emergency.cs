using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emergency : MonoBehaviour {
    public List<EnemyMove> enemy = new List<EnemyMove>();
    public GameObject player;
    private int state;
    private bool kurikaesibousi;
    private bool kurikaesibousi2;
    private AudioSource emargency;
	// Use this for initialization
	void Start () {
        emargency = GetComponent<AudioSource>();
        emargency.loop = true;
        kurikaesibousi = false;
        kurikaesibousi2 = false;
    }
	
	// Update is called once per frame
	void Update () {
       if( StaticMaster.privateDelta == 0)
        {
            kurikaesibousi = false;
            kurikaesibousi2 = true;
        }
        if ((StaticMaster.privateDelta <= 10 || (StaticMaster.privateDelta <= 67 && StaticMaster.privateDelta > 50)) && kurikaesibousi == false)
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                if (enemy[i] == null)
                {
                    enemy.RemoveAt(i);
                }
            }
            kurikaesibousi = true;
            kurikaesibousi2 = false;
        } else if (StaticMaster.privateDelta <= 50 && kurikaesibousi2 == false)
        {
            kurikaesibousi = false;
        }

        
	}
}
