using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultCamera : MonoBehaviour {
    //追跡するオブジェクトの処理
    public GameObject ChaseObject;//追跡するオブジェクトを取得
    public Transform ChaseObjectTransform;//Objectの座標を取得
    public bool ChaseObjectNotMove;//Objectを動かさない場合チェックを入れる
    public bool BackMoveCamera;//後ろにカメラが後退する場合チェックを入れる
    public Vector3 ChaseObjectNextPosition;//Objectの移動先の座標入力
    public float ChaseObjectPositionSpeed;//Objectの移動速度を入力


    //シャドちゃんオブジェクトの処理
    public bool SyadoChangeObject;//シャドちゃんのオブジェクトを変える時にチェックを入れる
    public GameObject SyadoObject;//現在のシャドちゃんのオブジェクトを取得
    public GameObject NextSyadoObject;//次のシャドちゃんオブジェクトを取得

    //カメラオブジェクトの処理
    public bool CameraMoveTimeCheck;//カメラが動いて良いかの判定
    public float CameraMoveTime;//カメラが動き出すまでの時間
    private float NowTime;//現在の経過時間
    public bool CameraNotMove;//カメラを動かさない場合チェックを入れる
    public float CameraRotationSpeed;//カメラの角度変更の速度を入力

    //その他

    //次に使用するオブジェクトの処理
    public GameObject NextChaseObject;//次に使用するオブジェクト取得
    public GameObject NextCameraObject;//次に使用するカメラを取得

    //確認用(後に消す)
    public Vector3 DifferencePosition;//次の位置と現在位置の距離を算出



    // Use this for initialization
    void Start () {
        DifferencePosition = ChaseObjectNextPosition - ChaseObject.transform.position;//現在位置と次の位置との差を算出
    }
	
	// Update is called once per frame
	void Update () {
        //特定のオブジェクト(ChaseObject)の方向を向き続けるプログラム
        Quaternion targetRotation = Quaternion.LookRotation(ChaseObjectTransform.position - transform.position);//対象オブジェクトの位置を取得
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * CameraRotationSpeed);//カメラの角度を更新

        if(CameraMoveTimeCheck == false)
        {
           if(ChaseObjectNotMove == false) ChaseObject.transform.position += DifferencePosition * ChaseObjectPositionSpeed * Time.deltaTime;//カメラで追うオブジェクトを次の座標位置まで移動
            if (CameraNotMove == false) this.transform.position += DifferencePosition * ChaseObjectPositionSpeed * Time.deltaTime;//カメラを次の座標位置まで移動

            if (BackMoveCamera == false)
            {
                if (ChaseObject.transform.position.z <= ChaseObjectNextPosition.z)//オブジェクトが次の座標位置まで移動したら実行
                {
                    if (SyadoChangeObject == true)
                    {
                        SyadoObject.SetActive(false);
                        NextSyadoObject.SetActive(true);
                    }
                    NextChaseObject.SetActive(true);
                    NextCameraObject.SetActive(true);

                    ChaseObject.SetActive(false);
                    this.gameObject.SetActive(false);
                    Debug.Log("次のカメラに行きました");
                }
            }
            else if(BackMoveCamera == true)
            {
                if (ChaseObject.transform.position.z >= ChaseObjectNextPosition.z)//オブジェクトが次の座標位置まで移動したら実行
                {
                    if (SyadoChangeObject == true)
                    {
                        SyadoObject.SetActive(false);
                        NextSyadoObject.SetActive(true);
                    }
                    NextChaseObject.SetActive(true);
                    NextCameraObject.SetActive(true);

                    ChaseObject.SetActive(false);
                    this.gameObject.SetActive(false);
                    Debug.Log("次のカメラに行きました");
                }

            }
        }
        else if(CameraMoveTimeCheck == true)
        {
            NowTime += Time.deltaTime;
            if(NowTime >= CameraMoveTime)
            {
                NowTime = 0.0f;
                CameraMoveTimeCheck = false;
                Debug.Log("カメラを動かします");
            }

        }
        

      
    }
}
