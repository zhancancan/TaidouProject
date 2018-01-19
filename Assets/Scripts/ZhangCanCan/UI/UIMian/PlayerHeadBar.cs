using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeadBar : MonoBehaviour {
    //UIHead
    private Text levelTxt;              //等级
    private Text powerTxt;              //体力
    private Text temperTxt;             //历练
    private Image powerImg;
    private Image temperImg;
    private Button powerBtn;
    private Button temperBtn;

    void Awake()
    {
        //UIHead
        levelTxt = transform.Find("Level").GetComponent<Text>();
        powerTxt = transform.Find("PowerCount").GetComponent<Text>();
        temperTxt = transform.Find("TemperCount").GetComponent<Text>();
        powerImg = transform.Find("PowerImg").GetComponent<Image>();
        temperImg = transform.Find("TemperImg").GetComponent<Image>();
        powerBtn = transform.Find("PowerAddBtn").GetComponent<Button>();
        temperBtn = transform.Find("TemperAddBtn").GetComponent<Button>();
    }

    void Start()
    {
        PlayInfo._instance.OnPlayInfoChanged += this.OnPlayInfoChanged;
    }

    private void OnDestroy()
    {
        PlayInfo._instance.OnPlayInfoChanged -= this.OnPlayInfoChanged;
    }

    void OnPlayInfoChanged(InfoType type)
    {
        if (type == InfoType.All || type == InfoType.Name || type == InfoType.HeadPortait || type == InfoType.Level || type == InfoType.Energy || type == InfoType.Toughen || type == InfoType.Coin || type == InfoType.Diamond)
        {
            UpdateShow();
        }
    }

    private void UpdateShow()
    {
        PlayInfo info = PlayInfo._instance;
        levelTxt.text = info.Level.ToString();
        powerTxt.text = info.Power.ToString();
        temperTxt.text = info.Toughen.ToString();
    }
}
