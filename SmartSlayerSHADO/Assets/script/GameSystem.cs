using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public PlayerMove playerMove;
    private EnemyMove enemyMove;
    public Text timeText;
    public float _time;
    public int[] desEnemy;
    
    public sceneChange SceneChange;

    public List<GameObject> Enemy;
    public GameObject Player;
    public GameObject CameraObj;
    private Vector3 P_Save;
    private Vector3 C_Save;


    [SerializeField]
    [Header("必殺技ゲージ")]
    private SP_Gauge sp_Gauge;

    public Vector3 sp_hanni_0;
    public Vector3 sp_hanni_1;
    public GameObject HitEffect;
    public string ClearSceneName;
    public AnchorNumber TapIfStartReturn;
    public List<bool> BossSwitch;
    public AudioSource EnemyEscape;
    public AudioSource EnemyDestroy;
    public Image[] StartImage = new Image[2];
    private float StartImageA = 0;

    public GameObject[] GameOverWindow;
    public GameObject StartWindow;
    public UI ui;

    public int StageSizeMin = 0;
    public int StageSizeMax = 6;

    [SerializeField]
    [Header("フィリアのライフポイント")]
    private int _Philia_LifePoint　= 3;//固定値
    private Image[] _Philia_LifeImage = new Image[3];

    //2018/02/02小林追加
    public GameObject ScoreCount;
    enum StateCTRL
    {
        STARTENEMY,
        STARTPLAYER,
        MAINIDLE,
        MAINMOVE,
        MAINATTACK,
        CLEAREND,
        WINDOW,
    }
    private StateCTRL stateCTRL;

    void Awake()
    {
        if (BossSwitch.Count == 0) BossSwitch.Add(false);
        for (int i = 0; i < BossSwitch.Count; i++)
        {
            BossSwitch[i] = false;
        }
        TapIfStartReturn.Num = 3;
        StaticMaster.stageSizeMin = StageSizeMin;
        StaticMaster.stageSizeMax = StageSizeMax;
    }

    /// <summary>
    /// Start時に読み込む　GetComponent一覧
    /// </summary>
    void StartGetComponents()
    {  
        //PlayerのHP
        _Philia_LifeImage[0] = GameObject.Find("PlayerStates/Philia_HP/Stock01").GetComponentInChildren<Image>();
        _Philia_LifeImage[1] = GameObject.Find("PlayerStates/Philia_HP/Stock02").GetComponentInChildren<Image>();
        _Philia_LifeImage[2] = GameObject.Find("PlayerStates/Philia_HP/Stock03").GetComponentInChildren<Image>();

        //PlayerのSP
        sp_Gauge = GameObject.Find("PlayerStates/Philia_SP").GetComponentInChildren<SP_Gauge>();
    }


    void Start()
    {
        StartGetComponents();
        GameObject[] e = GameObject.FindGameObjectsWithTag("Enemy");//Enemyの自動取得
        foreach (GameObject Ene in e)
        {
            if (!Enemy.Contains(Ene))//同じ要素がない時に追加
            {
                Enemy.Add(Ene);
            }
        }
        stateCTRL = StateCTRL.STARTENEMY;
        TapIfStartReturn.Num = 3;
    }

    void Update()
    {
       
        switch (stateCTRL)
        {
            case StateCTRL.STARTENEMY:
                StaticEnum("STARTENEMY");
                StartMove();
                break;
            case StateCTRL.STARTPLAYER:
                StaticEnum("STARTPLAYER");
                StartMovePlayer();
                break;
            case StateCTRL.MAINIDLE:
                StaticEnum("MAINIDLE");
                MainIdle();
                break;
            case StateCTRL.MAINMOVE:
                StaticEnum("MAINMOVE");
                MainMove();
                P_Move(StaticMaster.MoveNum);
                C_Move(StaticMaster.MoveNum);
                if (BossSwitch.Count == 0 && GameOverWindow[0].activeSelf == false && GameOverWindow[1].activeSelf == false)
                {
                    // Debug.Log("きてる");
                    StaticMaster.a -= scoreTesu.overBlue;
                    StaticMaster.b -= scoreTesu.overRed;
                    StaticMaster.c -= scoreTesu.overYellow;
                    SceneChange.SendMessage("ClearSceneChange", ClearSceneName);
                }
                break;
            case StateCTRL.MAINATTACK:
                StaticEnum("MAINATTACK");
                MainAttack();
                break;
            case StateCTRL.CLEAREND:
                StaticEnum("CLEAREND");
                clear();
                break;
            case StateCTRL.WINDOW:
                StaticEnum("WINDOW");
                break;
            default:
                break;
        }

        if (GameOverWindow[0].activeSelf == true && stateCTRL != StateCTRL.WINDOW)
        {
            ui.SendMessage("DAMAGE_OUT");
            Player.transform.position = P_Save;
            CameraObj.transform.position = C_Save;
            for (int i = 0; i < Enemy.Count; i++)
            {
                enemyMove = Enemy[i].GetComponent<EnemyMove>();
                enemyMove.SendMessage("MoveReset");
            }
            if (StartWindow != null) stateCTRL = StateCTRL.WINDOW;
            else stateCTRL = StateCTRL.MAINIDLE;
        }

        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemy[i] == null)
            {
                Enemy.RemoveAt(i);
            }
        }
    }

    void StartMove()//ゲーム開始時
    {
        //この下に処理を書いてね
        TapIfStartReturn.Num = 3;
        Debug.Log(Enemy.Count);
        if (Enemy.Count != 1)
        {
            for (int i = 0; i < Enemy.Count; i++)
            {
                if (Enemy[i].transform.position.y < 0.0f) Enemy[i].transform.position += new Vector3(0, 1.0f, 0) * Time.deltaTime;
                else
                {
                    Enemy[i].transform.position = new Vector3(Enemy[i].transform.position.x, 0.0f, Enemy[i].transform.position.z);
                    enemyMove = Enemy[i].GetComponent<EnemyMove>();
                    enemyMove.SendMessage("StartMove");
                }
            }

            if (Enemy[Enemy.Count - 1].transform.position.y == 0.0f) stateCTRL = StateCTRL.STARTPLAYER;//処理が終わったら実行する。(if文とかで処理が終わった判断をさせたりするのが楽かも) 
        }
        else stateCTRL = StateCTRL.STARTPLAYER;
    }

    void StartMovePlayer()//ゲーム開始時
    {
        //この下に処理を書いてね
        playerMove.SendMessage("StartMove", "run");
        Player.transform.position += new Vector3(0, 0, 4.0f) * Time.deltaTime;
        if (Player.transform.position.z >= 0.0f)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, 0.0f);
            playerMove.SendMessage("StartMove", "idle");
            //StartWindow.SetActive(true);
            //stateCTRL = StateCTRL.WINDOW;//処理が終わったら実行する。(if文とかで処理が終わった判断をさせたりするのが楽かも) 
            if (StartWindow != null)
            {
                StartWindow.SetActive(true);
                stateCTRL = StateCTRL.WINDOW;
            }
            else stateCTRL = StateCTRL.MAINIDLE;
        }
    }

    void MainIdle()//待機中にプレイヤーとカメラの位置をセーブ
    {

        //if (StaticMaster.Language == "Japanese")
        //{
        if (StartImage[0] != null)
        {
            StartImage[0].color = StartImage[0].color + new Color(0, 0, 0, StartImageA);
            StartImageA += 1.0f * Time.deltaTime;
            if (StartImageA >= 1.0f)
            {
                Destroy(StartImage[0]);
                TapIfStartReturn.Num = 0;
                if(ScoreCount)ScoreCount.SendMessage("TimeStart");//ScoreCountがある時だけSend
            }
            Destroy(StartImage[1]);

        }
        //}
        //else if (StaticMaster.Language == "English")
        //{
        //    if (StartImage[1] != null)
        //    {
        //        StartImage[1].color = StartImage[1].color + new Color(0, 0, 0, StartImageA);
        //        StartImageA += 1.0f * Time.deltaTime;
        //        if (StartImageA >= 1.0f)
        //        {
        //            Destroy(StartImage[1]);
        //            TapIfStartReturn.Num = 0;
        //        }
        //        Destroy(StartImage[0]);
        //    }

        //}
        P_Save = Player.transform.position;
        C_Save = CameraObj.transform.position;
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemy[i] == null)
            {
                Enemy.RemoveAt(i);
            }
            else
            {
                if (Enemy[i].transform.position.z < Player.transform.position.z - 1 || Enemy[i].transform.position.z < 0)
                {
                    Enemy[i].transform.position -= new Vector3(0, 0, 4.0f) * Time.deltaTime;
                }
                if (Enemy[i].transform.position.z < Player.transform.position.z - 3)
                {
                    EnemyEscape.Play();
                    enemyMove = Enemy[i].GetComponent<EnemyMove>();
                    enemyMove.SendMessage("GameOver");
                    Destroy(Enemy[i]);
                    Enemy.RemoveAt(i);
                    //EnemyAttack_hanni_0.RemoveAt(i);
                    //EnemyAttack_hanni_1.RemoveAt(i);
                    i = -1;
                }
            }
        }
        if (BossSwitch.Count == 0 && GameOverWindow[0].activeSelf == false && GameOverWindow[1].activeSelf == false) stateCTRL = StateCTRL.CLEAREND;
    }

    void MainMove()//コントローラで動かしている間
    {
        playerMove.SendMessage("_PlayerMove", StaticMaster.MoveNum);
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemy[i] == null)
            {
                Enemy.RemoveAt(i);
            }
            else
            {
                enemyMove = Enemy[i].GetComponent<EnemyMove>();
                enemyMove.SendMessage("_EnemyMove");
            }
        }

        //for (int i = 0; i < Enemy.Count; i++)
        //{
        //    if (Enemy[i].transform.position.x + EnemyAttack_hanni_0[i].x <= Player.transform.position.x && Enemy[i].transform.position.x + EnemyAttack_hanni_1[i].x >= Player.transform.position.x &&
        //        Enemy[i].transform.position.z + EnemyAttack_hanni_0[i].z <= Player.transform.position.z && Enemy[i].transform.position.z + EnemyAttack_hanni_1[i].z >= Player.transform.position.z)
        //    {
        //        //enemyMove = Enemy[i].GetComponent<EnemyMove>();
        //        //enemyMove.SendMessage("BossCheack");
        //        //Destroy(Enemy[i]);
        //        //Enemy.RemoveAt(i);
        //        //EnemyAttack_hanni_0.RemoveAt(i);
        //        //EnemyAttack_hanni_1.RemoveAt(i);
        //        //PlayerMove.FlashingFlag = true;
        //        //if (PlayerLifeImage.fillAmount == 1.0f) PlayerLifeImage.fillAmount = 0.635f;
        //        //else if (PlayerLifeImage.fillAmount == 0.635f) PlayerLifeImage.fillAmount = 0.315f;
        //        //else if(PlayerLifeImage.fillAmount == 0.315f)
        //        //{
        //        //    PlayerLifeImage.fillAmount = 0.0f;
        //        //    GameOverWindow[0].SetActive(true);
        //        //    stateCTRL = StateCTRL.WINDOW;
        //        //}
        //    }
        //}

    }

    void MainAttack()//指を離したときの処理
    {

        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemy[i] == null)
            {
                Enemy.RemoveAt(i);
            }

            if (i == Enemy.Count - 1)
            {
                enemyMove = Enemy[i].GetComponent<EnemyMove>();
                enemyMove.SendMessage("_EnemyMove");
            }
        }
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Player.transform.position.x + 1 >= Enemy[i].transform.position.x && Player.transform.position.x - 1 <= Enemy[i].transform.position.x && Player.transform.position.z + 1 >= Enemy[i].transform.position.z && Player.transform.position.z - 1 <= Enemy[i].transform.position.z)
            {
                if (Enemy[i].transform.position.z >= 0)
                {
                    EnemyDestroy.Play();
                    enemyMove = Enemy[i].GetComponent<EnemyMove>();
                    enemyMove.SendMessage("Destroy");
                    sp_Gauge.SendMessage("DestroyEnemyChargeBool");
                    Instantiate(HitEffect, Enemy[i].transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));
                    //Destroy(Enemy[i]);
                    enemyMove.IsDes = true;
                    Enemy.RemoveAt(i);
                    //EnemyAttack_hanni_0.RemoveAt(i);

                    //EnemyAttack_hanni_1.RemoveAt(i);
                    i = -1;
                }
            }
        }
        playerMove.SendMessage("_PlayerMovePosSave");
        for (int i = 0; i < Enemy.Count; i++)
        {
            enemyMove = Enemy[i].GetComponent<EnemyMove>();
            enemyMove.SendMessage("_EnemyMovePosSave");
        }

        if (timeText != null) _time -= 1;

        if (BossSwitch.Count != 0) stateCTRL = StateCTRL.MAINIDLE;
        else stateCTRL = StateCTRL.CLEAREND;
    }

    void clear() //クリアシーンに飛ばしたりする
    {
        StaticMaster.a -= scoreTesu.overBlue;
        StaticMaster.b -= scoreTesu.overRed;
        StaticMaster.c -= scoreTesu.overYellow;
        SceneChange.SendMessage("ClearSceneChange", ClearSceneName);
    }

    void P_Move(int Num)//プレイヤーの移動先
    {
        if (StaticMaster.privateDelta > 0 && StaticMaster.UI == 0)
        {
            if (Num == 2)
            {
                Player.transform.position = P_Save + new Vector3(1, 0, 1) * (StaticMaster.privateDelta) / (100);
            }
            else if (Num == 3)
            {
                Player.transform.position = P_Save + new Vector3(0, 0, 1) * (StaticMaster.privateDelta) / (100);
            }
            else if (Num == 4)
            {
                Player.transform.position = P_Save + new Vector3(-1, 0, 1) * (StaticMaster.privateDelta) / (100);
            }
            else if (Num == 5)
            {
                Player.transform.position = P_Save + new Vector3(-1, 0, 0) * (StaticMaster.privateDelta) / (100);
            }
            else if (Num == 6)
            {
                Player.transform.position = P_Save + new Vector3(-1, 0, -1) * (StaticMaster.privateDelta) / (100);
            }
            else if (Num == 7)
            {
                Player.transform.position = P_Save + new Vector3(0, 0, -1) * (StaticMaster.privateDelta) / (100);
            }
            else if (Num == 8)
            {
                Player.transform.position = P_Save + new Vector3(1, 0, -1) * (StaticMaster.privateDelta) / (100);
            }
            else if (Num == 1)
            {
                Player.transform.position = P_Save + new Vector3(1, 0, 0) * (StaticMaster.privateDelta) / (100);
            }
        }
        else
        {
            Player.transform.position = P_Save + new Vector3(0, 0, 0) * (StaticMaster.privateDelta) / (100);
        }
    }

    void C_Move(int Num)//カメラの移動先
    {
        if (StaticMaster.UI == 0)
        {
            if (Num == 2)
            {
                CameraObj.transform.position = C_Save + new Vector3(0, 0, 1) * StaticMaster.privateDelta / 100;
            }
            else if (Num == 3)
            {
                CameraObj.transform.position = C_Save + new Vector3(0, 0, 1) * StaticMaster.privateDelta / 100;
            }
            else if (Num == 4)
            {
                CameraObj.transform.position = C_Save + new Vector3(0, 0, 1) * StaticMaster.privateDelta / 100;
            }
            else if (Num == 5)
            {
                CameraObj.transform.position = C_Save + new Vector3(0, 0, 0) * StaticMaster.privateDelta / 100;
            }
            else if (Num == 6)
            {
                CameraObj.transform.position = C_Save + new Vector3(0, 0, -1) * StaticMaster.privateDelta / 100;
            }
            else if (Num == 7)
            {
                CameraObj.transform.position = C_Save + new Vector3(0, 0, -1) * StaticMaster.privateDelta / 100;
            }
            else if (Num == 8)
            {
                CameraObj.transform.position = C_Save + new Vector3(0, 0, -1) * StaticMaster.privateDelta / 100;
            }
            else
            {
                CameraObj.transform.position = C_Save + new Vector3(0, 0, 0) * StaticMaster.privateDelta / 100;
            }
        }
    }

    void StaticEnum(string State)
    {
        StaticMaster.gameSystemEnum = State;
    }

    public void winDes()
    {
        StaticMaster.tutorial = false;
        StartWindow.SetActive(false);
        stateCTRL = StateCTRL.MAINIDLE;
    }

    //ここから下は他のスクリプトからSendMessageを受ける用

    void StateMove()//UIから　タップしてる間呼ばれる
    {
        stateCTRL = StateCTRL.MAINMOVE;
    }

    void P_Damage(Vector3 E_pos)//EnemyMoveから
    {
        PlayerMove.FlashingFlag = true;
        Instantiate(HitEffect, E_pos + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));
        sp_Gauge.SendMessage("DestroyEnemyChargeBool");

        /// <summary>
        /// フィリア版ライフポイント　１ダメージ前提で処理
        /// </summary>
        _Philia_LifePoint -= 1;
        switch (_Philia_LifePoint)
        {
            case 2:
                _Philia_LifeImage[2].enabled = false;
                break;
            case 1:
                _Philia_LifeImage[1].enabled = false;
                break;
            case 0:
                _Philia_LifeImage[0].enabled = false;
                GameOverWindow[0].SetActive(true);
                stateCTRL = StateCTRL.WINDOW;
                break;
            default:
                break;
        }

    }

    void MoveCompletion()//UIから　指を離したときに移動するなら呼ばれる
    {
        if(ScoreCount) ScoreCount.SendMessage("TroubleCount");
        StaticMaster.privateDelta = 100;
        P_Move(StaticMaster.MoveNum);
        C_Move(StaticMaster.MoveNum);
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemy[i] == null)
            {
                Enemy.RemoveAt(i);
            }

            if (i == Enemy.Count - 1)
            {
                Debug.Log(i);
                Debug.Log(Enemy.Count);
                enemyMove = Enemy[i].GetComponent<EnemyMove>();
                enemyMove.SendMessage("_EnemyMove");
            }
        }
        stateCTRL = StateCTRL.MAINATTACK;
        Debug.Log("MoveCompletion");
        Debug.Log(Enemy.Count);
    }

    void DesEnemy(int enemyNum)//EnemyMoveから　クリア時に表示するスコアの換算用
    {
        desEnemy[enemyNum] += 1;
        if (enemyNum == 0)
        {
            StaticMaster.a = desEnemy[0];
        }
        else if (enemyNum == 1)
        {
            StaticMaster.b = desEnemy[1];
        }
        else if (enemyNum == 2)
        {
            StaticMaster.c = desEnemy[2];
        }
        else if (enemyNum == 3)//2017/08/29追加(小林)
        {
            StaticMaster.d = desEnemy[3];
        }
    }

    void sp()//PlayerMoveから　spの使用時に呼び出す
    {

        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Player.transform.position.x + sp_hanni_0.x <= Enemy[i].transform.position.x && Player.transform.position.x + sp_hanni_1.x >= Enemy[i].transform.position.x &&
               Player.transform.position.z + sp_hanni_0.z <= Enemy[i].transform.position.z && Player.transform.position.z + sp_hanni_1.z >= Enemy[i].transform.position.z)
            {
                enemyMove = Enemy[i].GetComponent<EnemyMove>();
                enemyMove.SendMessage("Destroy");
                sp_Gauge.SendMessage("DestroyEnemyChargeBool");
                Destroy(Enemy[i]);
                Enemy.RemoveAt(i);
                //EnemyAttack_hanni_0.RemoveAt(i);
                //EnemyAttack_hanni_1.RemoveAt(i);
                i = -1;
            }
        }

    }

    void damage()
    {
        //sceneChange.static_sceneName = "GameOver";
        //SceneChange.SendMessage("SceneChange");
        GameOverWindow[1].SetActive(true);
    }
    void PlayerPosReset()
    {
        Player.transform.position = new Vector3(3, 0, 0);
        CameraObj.transform.position = new Vector3(3, 0, 5);
        P_Save = Player.transform.position;
        C_Save = CameraObj.transform.position;
    }
}
