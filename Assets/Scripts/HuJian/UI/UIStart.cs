using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIStart :UIBase
{
    Image pleaseLoginbg;
    Button loginBtn;
    GameObject TotalList;
    GameObject SelectSeverBG;
    Button SeverBtn;
    public override void OnEntering()
    {

        TotalList = transform.Find("StartBG/TotalList").gameObject;
        SelectSeverBG = transform.Find("StartBG/SelectSeverBG").gameObject;
        SeverBtn = transform.Find("StartBG/SelectSeverBG/SeverBtn").GetComponent<Button>();
        SeverBtn.onClick.AddListener(() => {
            TotalList.gameObject.SetActive(true);
            SelectSeverBG.gameObject.SetActive(false);
        });
        SoundManager.Instance.PlayBGSound(ConstDates.ResourceAudiosDirHj, ConstDates.Bgm_1);
        pleaseLoginbg = transform.Find("StartBG/PleaseLoginBG").GetComponent<Image>();
        loginBtn = pleaseLoginbg.transform.Find("PleaseLoginBtn").GetComponent<Button>();

        pleaseLoginbg.gameObject.SetActive(false);
    }
    public override void OnPausing()
    {

        
    }
    public override void OnResuming()
    {

       

    }
    public override void OnExiting()
    {
        //进到下个界面关闭声音
        SoundManager.Instance.StopBGSound();
        gameObject.SetActive(false);

    }
    //跳转
    public void GoToSelectSever()
    {
        //UIManager.Instance.PushUIPanel(ConstDates.UISelectSever);
        TotalList.gameObject.SetActive(false);
        SelectSeverBG.gameObject.SetActive(true);
    }
    public void GoToLogin()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UILogin);
    }
    public void GoToRegister()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIRegister);
    }
    public void GoToSelectRole()
    {
        //if (PlayerLogin.isLogin)
        //{            
        //UIManager.Instance.PushUIPanel(ConstDates.UISelectRole);
        //}
        //else
        //{
        //    pleaseLoginbg.gameObject.SetActive(true);
        //}      
    }
    public void Onclick()
    {
        pleaseLoginbg.gameObject.SetActive(false);
    }
     GameObject serverSelectedGo;
    GameObject selectedserver;
    public void OnServerSelect(GameObject serverGo)
    {
        //sp = serverGo.GetComponent<ServerProperty>();
        serverSelectedGo = transform.Find("StartBG/SelectSeverBG/SeverContentImg").gameObject;
        serverSelectedGo.GetComponent<Image>().sprite = serverGo.GetComponent<Image>().sprite;
        serverSelectedGo.transform.Find("SeverNameTxt").GetComponent<Text>().text = serverGo.transform.Find("SeverNameTxt").GetComponent<Text>().text;
        serverSelectedGo.transform.Find("SeverNameTxt").GetComponent<Text>().color = serverGo.transform.Find("SeverNameTxt").GetComponent<Text>().color;
        selectedserver = transform.Find("StartBG/TotalList/SelectSeverBtn").gameObject;
        selectedserver.transform.Find("Text").GetComponent<Text>().text = serverGo.transform.Find("SeverNameTxt").GetComponent<Text>().text;
        selectedserver.transform.Find("Text").GetComponent<Text>().color = serverGo.transform.Find("SeverNameTxt").GetComponent<Text>().color;



    }
}
