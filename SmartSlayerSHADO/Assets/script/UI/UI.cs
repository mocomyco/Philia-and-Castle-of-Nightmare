using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    static public bool otameshi;
    public GameSystem gameSystem;
    private Vector2 InPos;
    public GameObject[] _UI;
    public GameObject Clone;
    public Canvas canvas;
    public SP_Gauge sp_Gauge;
    public Image SPGaugeImage;
    private PlayerMove PMove;
    private float IdouKyori;
    public string HoldState;
    private float holdCount;//↓2つの条件----
    private float holdStayAttackTime = 20000f;//移動ナシで攻撃できるようになる時間
    private float holdSpAttackTime = 0.5f;//SP攻撃できるようになる時間 
    //-------------
    public int Slow;//Asobi後の速度
    private AudioSource tap,cancel;
    // public Image carsol; // タッチ時にmousePosに目印
 

    public int tutorial;
    enum StateCTRL
    {
        ENTER,
        HOLD,
        HOLDOUT,
        OUT,
        SP,
        TIMESCROLL,
        STAND_BY,
    }
    private StateCTRL stateCTRL;

    void Awake()
    {
        //初期化はココ
        if (Clone) Destroy(Clone);  
    }

    void Start()
    {
        PMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        stateCTRL = StateCTRL.ENTER;
        tap = GameObject.Find("tap").GetComponent<AudioSource>();
        cancel = GameObject.Find("cancel").GetComponent<AudioSource>();
    }

    void Update()
    {
        Debug.Log(stateCTRL);
        switch (stateCTRL)
        {
            case StateCTRL.ENTER:
                Syokika();
                Enter();
                break;
            case StateCTRL.HOLD:
                HOLD();
                HOLDCOUNT();
                break;
            case StateCTRL.HOLDOUT:
                HOLDOUT();
                break;
            case StateCTRL.OUT:
                OUT();
                break;
            case StateCTRL.SP:
                SP();
                break;
            case StateCTRL.TIMESCROLL:
                TimeScroll();
                break;
            case StateCTRL.STAND_BY:
                Stand_By();
                break;
            default:
                break;
        }
    }

    void Syokika()
    {
        holdCount = 0;
        HoldState = "Normal";
        StaticMaster.privateDelta = 0;
        StaticMaster.MoveNum = 0;
    }

    void Enter()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Touch touch = Input.GetTouch(0);
          
            if (touch.phase == TouchPhase.Began && (StaticMaster.AnchorNum == 0 || (StaticMaster.AnchorNum == 1)) && StaticMaster.SP_AttackUse == false && /*(StaticMaster.gameSystemEnum == "MAINIDLE" || StaticMaster.gameSystemEnum == "MAINMOVE") &&*/ StaticMaster.tutorial == false && tutorial != 3&&Time.deltaTime !=0)//AnchorNum = 3 は討伐報告のボタン用
            {
                tap.Play();
                StaticMaster.rad = 0;//初期化
                StaticMaster.mag = 0;//
                InPos = touch.position;  //代入 
                if (StaticMaster.AnchorNum == 0)
                {
                    if (StaticMaster.SP_AttackUse == false)//攻撃モーション以外の時
                    {
                        if (!Clone)
                        {
                            Clone = Instantiate(_UI[tutorial], InPos, new Quaternion()); //ＵＩインスタンス
                            Clone.transform.SetParent(canvas.transform, false);
                        }
                    }
                }
                stateCTRL = StateCTRL.HOLD;
            }
        }else
        {
           
            //
            if (Input.GetMouseButton(0) && (StaticMaster.AnchorNum == 0 || (StaticMaster.AnchorNum == 1)) && StaticMaster.SP_AttackUse == false && /*(StaticMaster.gameSystemEnum == "MAINIDLE" || StaticMaster.gameSystemEnum == "MAINMOVE") &&*/ StaticMaster.tutorial == false && tutorial != 3&& Time.deltaTime !=0)//AnchorNum = 3 は討伐報告のボタン用
            {
                StaticMaster.rad = 0;//初期化
                StaticMaster.mag = 0;//
                InPos = Input.mousePosition;  //代入 
                tap.Play();
                if (StaticMaster.AnchorNum == 0)
                {
                    if (StaticMaster.SP_AttackUse == false)//攻撃モーション以外の時
                    {
                        if (!Clone)
                        {
                            Clone = Instantiate(_UI[tutorial], InPos, new Quaternion()); //ＵＩインスタンス
                            Clone.transform.SetParent(canvas.transform, false);
                        }
                    }
                }
                stateCTRL = StateCTRL.HOLD;
            }
        }
    }

    void HOLD()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Touch touch = Input.GetTouch(0);
            // Input.GetMouseButton(0) == false
            if (touch.phase == TouchPhase.Ended)
            {
                stateCTRL = StateCTRL.HOLDOUT;
                return;
            }

            //このゲームの時間の値をデバッグ
            if (StaticMaster.sp_UI == false) gameSystem.SendMessage("StateMove");

            if (StaticMaster.AnchorNum == 0)
            {
                StaticMaster.rad = GetAim(InPos, touch.position);           //ラジアン取得

                StaticMaster.mag = (InPos - touch.position).magnitude;
            }

            //相対距離取得

            if (StaticMaster.mag - StaticMaster.Asobi < 0)
            {
                StaticMaster.privateDelta = 0;

            }
            else
            if (StaticMaster.mag > StaticMaster.Asobi)
            {
                if (StaticMaster.mag - StaticMaster.Asobi > 100 * Slow)
                {
                    StaticMaster.privateDelta = 100;
                }
                else
                {
                    StaticMaster.privateDelta = (StaticMaster.mag - StaticMaster.Asobi) / Slow;

                }
                //相対距離を100までゲーム時間まで反映
            }
        }
        else
        {
           
            if (Input.GetMouseButton(0) == false)
            {
                stateCTRL = StateCTRL.HOLDOUT;
                return;
            }

            //このゲームの時間の値をデバッグ
            if (StaticMaster.sp_UI == false) gameSystem.SendMessage("StateMove");

            if (StaticMaster.AnchorNum == 0)
            {
                StaticMaster.rad = GetAim(InPos, Input.mousePosition);           //ラジアン取得

                StaticMaster.mag = (InPos - (Vector2)Input.mousePosition).magnitude;
            }

            //相対距離取得

            if (StaticMaster.mag - StaticMaster.Asobi < 0)
            {
                StaticMaster.privateDelta = 0;

            }
            else
            if (StaticMaster.mag > StaticMaster.Asobi)
            {
                if (StaticMaster.mag - StaticMaster.Asobi > 100 * Slow)
                {
                    StaticMaster.privateDelta = 100;

                }
                else
                {
                    StaticMaster.privateDelta = (StaticMaster.mag - StaticMaster.Asobi) / Slow;

                }
                //相対距離を100までゲーム時間まで反映
            }
        }
    }

    void HOLDCOUNT()
    {
        if (StaticMaster.MoveNum == 0)
        {
            if (IdouKyori == StaticMaster.mag)
            {
                holdCount += 0.01f;
            }
            else if (HoldState == "Normal")
            {
                holdCount = 0;
            }
        }
        else
        {
            holdCount = 0;
        }

       
            HoldState = "Normal";
        
        IdouKyori = StaticMaster.mag;
    }

    void OUT()
    {
        Destroy(Clone); //UIをDestory
        
        if (StaticMaster.privateDelta > 0 && StaticMaster.sp_UI == false && StaticMaster.MoveNum != 0)
        {
            //座標を整数値に
            //StaticMaster.privateDelta = 100;
            gameSystem.SendMessage("MoveCompletion");
            
            StaticMaster.Count += 1; //相対距離　20 + Asobi 以上でゲーム時間が進む
            StaticMaster.WaveCount += 1;
            StaticMaster.WalkChargeBool = true;
        }
        else
        {
            StaticMaster.privateDelta = 0;
            cancel.Play();
            gameSystem.SendMessage("StateMove");
        }
        stateCTRL = StateCTRL.STAND_BY;
    }

    void HOLDOUT()
    {
        if (HoldState == "SP")
        {
            stateCTRL = StateCTRL.SP;
        }
        else
        if (HoldState == "StayAttack")
        {
            stateCTRL = StateCTRL.TIMESCROLL;
        }
        else
        {
            stateCTRL = StateCTRL.TIMESCROLL;
        }
    }

    void SP()
    {
        PMove.SendMessage("SP_Attack");
        sp_Gauge.SendMessage("SP");
        stateCTRL = StateCTRL.OUT;
    }
    
    public float GetAim(Vector3 p1, Vector3 p2)
    {
        //ラジアンをfloatで返すクラス
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }

    void TimeScroll()
    {
        if (StaticMaster.privateDelta == 0||StaticMaster.MoveNum == 0) stateCTRL = StateCTRL.OUT;
        if (StaticMaster.privateDelta >= 100)
        {
            stateCTRL = StateCTRL.OUT;
        }

        if (StaticMaster.privateDelta > 80)
        {
            StaticMaster.privateDelta = 100;
        }
        else
        {
            StaticMaster.privateDelta += 15;
        }
        if (StaticMaster.sp_UI == false) gameSystem.SendMessage("StateMove");
    }

    void Stand_By()
    {
        //if (StaticMaster.PlayerAnim != "Idle"&&StaticMaster.PlayerAnim != "run")
        //{
        //    return;
        //}
        stateCTRL = StateCTRL.ENTER;
    }

    void DAMAGE_OUT()
    {
        Destroy(Clone); //UIをDestory
        StaticMaster.privateDelta = 0;
        stateCTRL = StateCTRL.STAND_BY;
    }
}
