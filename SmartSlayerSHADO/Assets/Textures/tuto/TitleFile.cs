using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFile : MonoBehaviour {

    [Header("背景")]
   public Sprite _BackGroundSprite;
    private Image _BackGroundImage;

    [Header("フィリア")]
    public Sprite _FiriaSprite;
    private Image _FiriaImage;

    [Header("タイトル")]
    public Sprite _TitleSprite;
    private Image _TitleImage;

    [Header("タッチでスタート")]
    public Sprite _TapToStartSprite;
    private Image _TapToStartImage;

    [SerializeField]
    [Header("タップのアルファ値変更スピード(0~1)")]
    private float _TapSpriteColorAlfaChangeSpeed;

    [SerializeField]
    [Header("タップのスプライトのアルファ値")]
    private float _TapSpriteColorAlfa;
   private float _PrivatePlus_OR_MinusSignSpeed = 1;//点滅の正負符号


    private void Start()
    {
        //ゲットコンポーネントでな
        //スペル間違いしないで
        _BackGroundImage = GameObject.Find("Canvas/BackGround").GetComponent<Image>();
        _BackGroundImage.sprite = _BackGroundSprite;
        _FiriaImage = GameObject.Find("Canvas/Firia").GetComponent<Image>();
        _FiriaImage.sprite = _FiriaSprite;
        _TitleImage = GameObject.Find("Canvas/Title").GetComponent<Image>();
        _TitleImage.sprite = _TitleSprite;
        _TapToStartImage = GameObject.Find("Canvas/TapToStart").GetComponent<Image>();
        _TapToStartImage.sprite = _TapToStartSprite;
    }


    private void Update()
    {
        TapSpriteColorScaleChange();
    }


    /// <summary>
    /// タップを点滅させる
    /// </summary>
    private void TapSpriteColorScaleChange()
    {
        
        _TapSpriteColorAlfa = _TapToStartImage.color.a;//アルファ値を代入

        //1以上で下降、０以下で上昇
       if(_TapSpriteColorAlfa >=0.99f)
        {
            _PrivatePlus_OR_MinusSignSpeed = -1;
        }
        else if(_TapSpriteColorAlfa <=0.5f)
        {
            _PrivatePlus_OR_MinusSignSpeed  = 1;
        }

        _TapSpriteColorAlfa += _TapSpriteColorAlfaChangeSpeed * _PrivatePlus_OR_MinusSignSpeed;//インスペクターのスピードと正負符号を代入
        _TapToStartImage.color = new Color(1,1,1, _TapSpriteColorAlfa);
    }

}
