using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gif : MonoBehaviour {
    public Sprite[] frames;
    float framesPerSecond = 10.0f;
    public Image images;
    void Start()
    {

    }

    void Update()
    {
         int index =(int)(Time.time * framesPerSecond);
        index = index % frames.Length;
        images.sprite = frames[index];
    }
}
