using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPopup : MonoBehaviour {

    InventoryItem it;
    Image img;
    Text nametxt, destxt, btntxt;
    Button closebtn;
    Button usebtn, useallbtn;
    InventoryItemUI itUI;
    public PowerShow powershow;
    private void Awake()
    {
        img = transform.Find("Bg/Introduction/Img").GetComponent<Image>();
        nametxt = transform.Find("Bg/Introduction/NameText").GetComponent<Text>();
        destxt = transform.Find("Bg/Introduction/DesText").GetComponent<Text>();
        btntxt = transform.Find("Bg/useallbtn/Text/Text").GetComponent<Text>();
        closebtn = transform.Find("Bg/Close").GetComponent<Button>();
        closebtn.onClick.AddListener(Close);
        usebtn = transform.Find("Bg/usebtn").GetComponent<Button>();
        useallbtn = transform.Find("Bg/useallbtn").GetComponent<Button>();
        usebtn.onClick.AddListener(OnUse);
        useallbtn.onClick.AddListener(OnUseall);
    }
    public void Show(InventoryItem it,InventoryItemUI itUI)
    {
        gameObject.SetActive(true);
        this.it = it;
        this.itUI = itUI;
        img.sprite = it.Inventory.Icon;
        nametxt.text = it.Inventory.Name;
        destxt.text = it.Inventory.Des;
        btntxt.text = "(" + it.Count.ToString() + ")";
    } 
    public void OnUse()  //左击使用
    {
        int startvalue = PlayInfo._instance.GetOverallPower();
        itUI.ChangeCount(1);
        PlayInfo._instance.InventoryUse(it, 1);
        Close();
        int endvalue = PlayInfo._instance.GetOverallPower();
        powershow.ShowPowerChange(startvalue, endvalue);
        InventoryUI._instance.SendMessage("UpdateCount");
    }
    public void OnUseall()
    {
        int startvalue = PlayInfo._instance.GetOverallPower();
        itUI.ChangeCount(it.Count);
        PlayInfo._instance.InventoryUse(it, it.Count);
        Close();
        int endvalue = PlayInfo._instance.GetOverallPower();
        powershow.ShowPowerChange(startvalue, endvalue);
        InventoryUI._instance.SendMessage("UpdateCount");
    }
   
    void Clear()
    {
        this.it = null;
       this.itUI = null;
    }
    public void Close()
    {
        CloseOn();
        transform.parent.parent.SendMessage("DisableButton");
    }
    public void CloseOn()
    {
        Clear();
        gameObject.SetActive(false);
    }
}

