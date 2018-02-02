using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public Animation anim;
    public GameObject player;
    static public Vector3 playerPos;
    public GameSystem gameSystem;
    //public GameObject Idle;
    public int FlashingCount;
    static public bool FlashingFlag;
    public bool tutoRun;
    public SkinnedMeshRenderer playerSkinMesh;
    public MeshRenderer[] playerMesh;
    public Animator effect;
    void Update () {
        playerPos = new Vector3((int)player.transform.position.x, 0, (int)player.transform.position.z);
        if (anim.isPlaying == false)
        {
            
            anim.Play("idle");
            StaticMaster.PlayerAnim = "Idle";
        }
        if(tutoRun == true)
        {
            anim.Play("run");
            StaticMaster.PlayerAnim = "run";
        }
        if(FlashingFlag == true)
        {
            FlashingCount += 1;
            if (FlashingCount % 4 == 0)
            {
                playerSkinMesh.enabled = !playerSkinMesh.enabled;
                for(int i = 0; i < playerMesh.Length; i++)
                {
                    playerMesh[i].enabled = !playerMesh[i].enabled;
                }
                //if (Idle.activeSelf == true)
                //{
                //    Idle.SetActive(false);
                //}
                //else if(Idle.activeSelf == false)
                //{
                //    Idle.SetActive(true);
                //}
            }
            if (FlashingCount >= 25)
            {
                FlashingCount = 0;
                FlashingFlag = false;
            }
        }
        //if (anim["attack"].normalizedTime >= StaticMaster.StayTime) 
        if (anim["attack"].normalizedTime >= 0.9)
        {
            
            anim.CrossFade("idle", 1.0f);
            StaticMaster.PlayerAnim = "Idle";//攻撃後の待機時間
        }
        //if(anim["specialattack"].normalizedTime >= 0.9) StaticMaster.sp_AttackNum = 0;
    }

    void SP_Attack()
    {
       
        anim.CrossFade("specialattack");
        StaticMaster.PlayerAnim = "specialattack";
        //gameSystem.SendMessage("sp");
    }

    void _PlayerMove(int Num)
    {
        if (StaticMaster.MoveNum !=0)
        {
            anim.Play("run");
            anim["run"].normalizedTime = (StaticMaster.privateDelta) / (100);
            StaticMaster.PlayerAnim = "run";
        }
    }

    void _PlayerMovePosSave()
    {
        anim.CrossFade("attack");
        effect.Play("slash");
        anim["attack"].speed = 1.5f;
        StaticMaster.PlayerAnim = "attack";
        StaticMaster.tesu -= 1;
    }

    void StartMove(string a)
    {
        anim.Play(a);
        if (a == "run") anim[a].speed = 1.5f;
        StaticMaster.PlayerAnim = a;
    }
}
