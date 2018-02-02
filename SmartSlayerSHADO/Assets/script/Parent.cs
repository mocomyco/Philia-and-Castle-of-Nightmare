using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour {
    public string ParentName;
    private GameObject _Parent;

	void Start () {
        _Parent = GameObject.Find(ParentName);
        gameObject.transform.parent = _Parent.transform;
	}
	
}
