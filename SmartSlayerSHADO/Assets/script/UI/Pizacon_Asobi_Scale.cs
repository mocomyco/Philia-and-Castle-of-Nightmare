using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pizacon_Asobi_Scale : MonoBehaviour {
    private RectTransform _Size;
	// Use this for initialization
	void Start () {
        _Size = GetComponent<RectTransform>();
        _Size.localScale = new Vector3(StaticMaster.Asobi * 2, StaticMaster.Asobi * 2, 1);
	}

}
