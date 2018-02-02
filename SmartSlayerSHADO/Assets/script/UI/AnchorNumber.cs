using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnchorNumber : MonoBehaviour, IPointerDownHandler
{
    public int Num;
   
    public bool startswitch;

    
    public void OnPointerDown(PointerEventData EventSystem)
    {
        if (StaticMaster.Pause == true) return;
        StaticMaster.AnchorNum = Num;
    }
}
