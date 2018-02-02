using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyReset : MonoBehaviour
{
    public GameObject OldEnemyBox;
    public GameSystem EnemyPos;
    public PlayerMove PlayerPos;
    public GameObject[] EnemyObject;
    private Vector3[] EnemyObjectVec;
    public Vector3[] EnemyAttackHani;
    public int stateNum;
    public Tuto_States tutoStates;
    public Image fIn;
    private float count;

    enum State
    {
        START,
        CHENGE,
        END,
    }

    private State _enum;

    void Start()
    {

        Debug.Log(stateNum + "Start");
        count = 0;
        fIn.enabled = true;
        _enum = State.START;
        //for (int i = 0; i < EnemyObject.Length; i++)
        //{
        //    EnemyObject[i].SetActive(true);
        //    //EnemyObjectVec[i] = EnemyObject[i].transform.position;

        //}

    }

    // Update is called once per frame
    void Update()
    {
        switch (_enum)
        {
            case State.START:
                count += 5;
                if (count < 255) fIn.color = new Color32(0, 0, 0, (byte)(count));
                else if
                    (count >= 255)
                {
                    fIn.color = new Color32(0, 0, 0, 255);
                    _enum = State.CHENGE;
                }
                break;
            case State.CHENGE:
                Reset();
                _enum = State.END;
                break;
            case State.END:
                count -= 5;
                if (count > 0) fIn.color = new Color32(0, 0, 0, (byte)(count));
                else if
                    (count <= 0)
                {
                    fIn.enabled = false;
                    tutoStates.SendMessage("NextContentsNum", stateNum);
                }
                break;
            default:
                break;
        }




    }

    public void Reset()
    {
        for (int i = 0; i < EnemyObject.Length; i++)
        {
            EnemyObject[i].SetActive(true);
            //EnemyObject[i].transform.position = EnemyObjectVec[i];
        }
        EnemyPos.SendMessage("PlayerPosReset");
        EnemyPos.Enemy.Clear();
        //EnemyPos.EnemyAttack_hanni_0.Clear();
        //EnemyPos.EnemyAttack_hanni_1.Clear();
        for (int i = 0; i < EnemyObject.Length; i++)
        {
            EnemyPos.Enemy.Add(EnemyObject[i]);
            //EnemyPos.EnemyAttack_hanni_0.Add(EnemyAttackHani[i]);
            //EnemyPos.EnemyAttack_hanni_1.Add(new Vector3(0.5f, 0, 0.5f));
        }
        foreach (Transform n in OldEnemyBox.transform)
        {
            GameObject.Destroy(n.gameObject);
        }

    }
}
