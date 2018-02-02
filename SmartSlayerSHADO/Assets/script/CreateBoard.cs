using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoard : MonoBehaviour {
    public int _x, _z,groundNum,gridNum;
    public GameObject Grid;
    public GameObject ground;
    public GameObject rock;
    private int k,grid;
    public int RockLastPos_z;

    void Start()
    {
        StaticMaster.Board_x = _x;
        StaticMaster.Board_z = _z;

        for(grid = 0; grid < gridNum; grid++)
        {
            Instantiate(Grid, new Vector3(0, 0, grid * 29), new Quaternion(0, 0, 0, 0));
        }
        grid = 1;

        for(k = 0; k < groundNum; k++)
        {
            Instantiate(ground, new Vector3(3, 0, 4 + 15.3375f * k), Quaternion.Euler(90, 0, 0));
        }

        for (int l = 0; l < RockLastPos_z; l++)
        {
            float ranY = Random.Range(0, 360);
            float ranY2 = Random.Range(0, 360);
            if (StaticMaster.stageSizeMin > 0)
            {
                Instantiate(rock, new Vector3(StaticMaster.stageSizeMin - 1, 0, 1.2f * l + 0.35f), Quaternion.Euler(0, ranY, 0));//
            }
            else
            {
                Instantiate(rock, new Vector3(StaticMaster.stageSizeMin, 0, 1.2f * l + 0.35f), Quaternion.Euler(0, ranY, 0));
            }

            if (StaticMaster.stageSizeMax < 6)
            {
                Instantiate(rock, new Vector3(StaticMaster.stageSizeMax+1, 0, 1.2f * l + 0.35f), Quaternion.Euler(0, ranY2, 0));//
            }
            else
            {
                Instantiate(rock, new Vector3(StaticMaster.stageSizeMax, 0, 1.2f * l + 0.35f), Quaternion.Euler(0, ranY2, 0));//
            }
        }
    }
}
