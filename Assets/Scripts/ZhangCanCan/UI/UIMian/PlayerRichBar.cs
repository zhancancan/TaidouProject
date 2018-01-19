using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRichBar : MonoBehaviour {
    //UIRich
    private Text diamonTxt;             //宝石
    private Text coinTxt;               //金币
    private Button diamonBtn;
    private Button coinBtn;

    void Awake () {
        //UIRich
        diamonTxt = transform.Find("DiamonCount").GetComponent<Text>();
        coinTxt = transform.Find("CoinCount").GetComponent<Text>();
        diamonBtn = transform.Find("DiamonAddBtn").GetComponent<Button>();
        coinBtn = transform.Find("CoinAddBtn").GetComponent<Button>();
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
        diamonTxt.text = info.Diamond.ToString();
        coinTxt.text = info.Coin.ToString();
    }
}
