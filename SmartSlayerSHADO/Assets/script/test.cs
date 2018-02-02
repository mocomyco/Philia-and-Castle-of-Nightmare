using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class test : MonoBehaviour {
    // 要素を追加するコンテント
    [SerializeField]
    RectTransform content;

    // 生成する要素
    [SerializeField]
    RectTransform originalElement;
    [SerializeField]
    Text elementOriginalText;

    // テキスト入力フィールド
    [SerializeField]
    InputField input;

    void Awake()
    {
        originalElement.gameObject.SetActive(false);
    }

    public void OnSubmit()
    {
        // 入力フィールドを元に複製元のデータを改変
        // 入力フィールドは初期化する
        elementOriginalText.text = input.text;
        input.text = string.Empty;

        // content以下にoriginalElementを複製
        var element = GameObject.Instantiate<RectTransform>(originalElement);
        element.SetParent(content, false);
        element.SetAsFirstSibling();
        element.gameObject.SetActive(true);
    }
}