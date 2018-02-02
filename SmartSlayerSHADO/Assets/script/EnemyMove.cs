using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public Animation anim;
    [Tooltip("0:Idle 1:Move 2:Damage")]public string[] anim_name;
    public Vector3[] EnemyMoveRoute;
    private int MoveCount = 1;
    public Vector3 SavePos;
    public int point;//スコアに加算するポイント
    private GameSystem gameSystem;
    public int EnemyNum;
    public GameObject destroyEffect;
    public bool Boss;
    private GameObject Player;
    [Tooltip("のけぞり判定に持っていく")] public bool IsDes = false;  

    void Start()
    {
        Player = GameObject.Find("Player");
        gameSystem =GameObject.Find("GameSystem").GetComponent<GameSystem>();
        if (SavePos.y == -1) SavePos = transform.position + new Vector3(0, 1.0f, 0);
        else SavePos = transform.position;

    }

    void Update()
    {
        if (IsDes == false)
        {
            if (anim.isPlaying == false)
            {
                anim.Play(anim_name[0]);
            }
            if (EnemyNum == 0 || EnemyNum == 3)
            {
                if (Player.transform.position.x > transform.position.x - 0.5f &&
                    Player.transform.position.x < transform.position.x + 0.5f &&
                    Player.transform.position.z > transform.position.z - 0.5f &&
                    Player.transform.position.z < transform.position.z + 0.5f)
                {
                    BossCheack();
                    gameSystem.SendMessage("P_Damage", transform.position);
                    gameSystem.SendMessage("DesEnemy", EnemyNum);//

                    //Destroy(gameObject);
                    IsDes = true;
                }
            }
            if (EnemyNum == 1)
            {
                if (Player.transform.position.x > transform.position.x - 1f &&
                    Player.transform.position.x < transform.position.x + 1f &&
                    Player.transform.position.z > transform.position.z - 2.1f &&
                    Player.transform.position.z < transform.position.z + 1f)
                {
                    //Debug.Log("Player"+Player.transform.position);
                    //Debug.Log("Enemy"+transform.position);
                    //Debug.Log("Player-Enemy" + (Player.transform.position.z - transform.position.z));
                    //Debug.Log("Player-Enemy" + (Player.transform.position.x - transform.position.x));
                }
                if ((Player.transform.position.x > transform.position.x - 0.5f &&
                Player.transform.position.x < transform.position.x + 0.5f &&
                Player.transform.position.z > transform.position.z - 0.5f &&
                Player.transform.position.z < transform.position.z + 0.5f) ||
                (Player.transform.position.x > transform.position.x - 0.3f &&
                Player.transform.position.x < transform.position.x + 0.3f &&
                Player.transform.position.z > transform.position.z - 1.03f &&
                Player.transform.position.z < transform.position.z + 0.5f))
                {
                    //Debug.Log("Player"+Player.transform.position);
                    //Debug.Log("Enemy"+transform.position.z);
                    BossCheack();
                    gameSystem.SendMessage("DesEnemy", EnemyNum);//
                    gameSystem.SendMessage("P_Damage", transform.position);

                    //Destroy(gameObject);
                    IsDes = true;
                }
            }
            if (EnemyNum == 2)
            {
                if (Player.transform.position.x > transform.position.x - 1.15f &&
                    Player.transform.position.x < transform.position.x + 1.15f &&
                    Player.transform.position.z > transform.position.z - 0.5f &&
                    Player.transform.position.z < transform.position.z + 0.5f)
                {
                    BossCheack();
                    gameSystem.SendMessage("P_Damage", transform.position);
                    gameSystem.SendMessage("DesEnemy", EnemyNum);//

                    //Destroy(gameObject);
                    IsDes = true;
                }
            }
        }
        if(IsDes == true)
        {
            anim.Play(anim_name[2]);
            if (anim[anim_name[2]].normalizedTime > 0.95) Destroy(gameObject);
        }
    }

    void _EnemyMove()
    {
        if (StaticMaster.MoveNum != 0)
        {
            transform.position = SavePos + EnemyMoveRoute[MoveCount - 1] * (StaticMaster.privateDelta / 100);
            if (StaticMaster.privateDelta == 0)
            {
                transform.position = SavePos;
            }
        }
        anim.Play(anim_name[1]);
    }

    void _EnemyMovePosSave()
    {
        SavePos = transform.position;
        MoveCount += 1;
        if (EnemyMoveRoute.Length < MoveCount) MoveCount = 1;
    }

    void Destroy()
    {

        BossCheack();
        gameSystem.SendMessage("DesEnemy", EnemyNum);
        if (destroyEffect != null)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.Euler(-90, 0, 0));
        }
    }
    
    void StartMove()
    {
        SavePos = transform.position;
    }

    void BossCheack()
    {
        if (Boss == true)
        {
            gameSystem.BossSwitch.RemoveAt(0);
        }
    }

    void GameOver()
    {
        if (Boss == true)
        {
            gameSystem.SendMessage("damage");
        }
    }

    void MoveReset()
    {
        transform.position = SavePos;
    }
}
