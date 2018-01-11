using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MessageManager : MonoBehaviour {

    public static MessageManager _instance;
    Text txt;
    Image Messageimg;

    private void Awake()
    {
        _instance = this;
        txt = transform.Find("Text").GetComponent<Text>();
        Messageimg = transform.Find("Image").GetComponent<Image>();
    }
    public void ShowMessage(string message)
    {
        txt.text = message;
        Messageimg.DOFade(1, 0.5f).OnComplete(() => Messageimg.DOFade(0, 1f).OnComplete(()=>txt.text=""));
        txt.DOColor(Color.red, 0.5f).OnComplete(() => { txt.DOColor(Color.yellow, 0.7f); });
        

    }
}
