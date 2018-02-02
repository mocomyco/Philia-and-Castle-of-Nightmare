using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeMove : MonoBehaviour {
    private Material meshrender;
    private Material FirstMaterial;
    public float GradationSpeed;
    public float MaxTransparency;
    private float a = 0.0f;
    private bool Change = true;
    private bool Stop = false;
    public bool UIMode;
    private bool Go = false;
    // Use this for initialization
    void Start()
    {
        meshrender = GetComponent<Renderer>().material;
        FirstMaterial = GetComponent<Renderer>().material;
        Go = true;
    }

    // Update is called once per frame
    void Update()
    {
        meshrender.color = new Color(FirstMaterial.color.r, FirstMaterial.color.g, FirstMaterial.color.b, a);
        if (Stop == false)
        {
            meshrender.color = new Color(FirstMaterial.color.r, FirstMaterial.color.g, FirstMaterial.color.b, a);
            if (Change == true)
            {
                a += GradationSpeed * Time.deltaTime;
            }
            if (Change == false)
            {
                a -= GradationSpeed * Time.deltaTime;
            }
            if (a >= MaxTransparency)
            {
                Change = false;
            }
            if (a <= 0.0f)
            {
                Change = true;
            }
        }
        if (UIMode == false)
        {
            if (Input.GetMouseButtonDown(0) == true && StaticMaster.AnchorNum == 0)
            {
                EnemyAttackRangeStop();
            }
            if (Input.GetMouseButtonUp(0) == true && StaticMaster.AnchorNum == 0)
            {
                EnemyAttackRangeGo();
            }
        }
        else if (UIMode == true)
        {
            if (Go == false && StaticMaster.AttackRange == true)
            {
                EnemyAttackRangeGo();
                Go = true;
            }
            if (Go == true && StaticMaster.AttackRange == false)
            {
                EnemyAttackRangeStop();
                Go = false;
            }
            if (Input.GetMouseButtonDown(0) == true && StaticMaster.AnchorNum == 0)
            {
                EnemyAttackRangeStop();
                Go = false;
                StaticMaster.AttackRange = false;
            }
        }
    }

    void EnemyAttackRangeStop()
    {
        Stop = true;
        a = 0.0f;
        Debug.Log("止められました");
    }

    void EnemyAttackRangeGo()
    {
        Stop = false;
        a = 0.0f;
        Debug.Log("動きました");
    }
}
