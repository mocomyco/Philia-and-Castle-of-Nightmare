using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour {
    private ParticleSystem a;
    void Start()
    {
        a = this.GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (a.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
