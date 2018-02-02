using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoEnd : MonoBehaviour
{
    public Tuto_States TStates;
    public Image[] tutoClear;
    public Image FCanvas;
    private sceneChange sChange;

    void Awake()
    {
        //if (StaticMaster.Language == "Japanese")
        //{
        //    tutoClear[0].enabled = false;
            
        //}
        //else if (StaticMaster.Language == "English")
        //{
            
        //    tutoClear[1].enabled = false;
        //}
       
    }
    void Start()
    {
        //if (StaticMaster.Language == "Japanese")
        //{
        //    tutoClear[0].enabled = true;
        //    Destroy(tutoClear[1]);
        //}
        //else if (StaticMaster.Language == "English")
        //{
        //    Destroy(tutoClear[0]);
        //    tutoClear[1].enabled = true;
        //}
       
        sChange = GetComponent<sceneChange>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("End", 4);
    }

    void End()
    {
        //if (StaticMaster.Language == "Japanese")
        //{
        //    tutoClear[0].enabled = false;

        //}
        //else if (StaticMaster.Language == "English")
        //{

        //    tutoClear[1].enabled = false;
        //}
        sChange.SendMessage("SceneChange");
    }
}
