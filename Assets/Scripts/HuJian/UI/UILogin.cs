using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UILogin : UIBase {
    Image failedBg;//登陆失败界面
    Button LoginBtn; //登陆按钮
    LoginController login;
    Text username;
    Text password;
    private static UILogin _instance;
    public static UILogin Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        _instance = this;
        login = this.GetComponent<LoginController>();
        username = transform.Find("UIBG/LoginBG/AccountTxt/InputAccount/Text").GetComponent<Text>();
        password = transform.Find("UIBG/LoginBG/PassWordTxt /InputAccount/Text").GetComponent<Text>();
        LoginBtn =transform.Find("UIBG/LoginBG/LoginBtn") .GetComponent<Button>();
        LoginBtn.onClick.AddListener(() => { login.Login(username.text,password.text); });
    }
    public override void OnEntering()
    {
        failedBg = transform.Find("FailedBG").GetComponent<Image>();   
        gameObject.SetActive(true);

    }
    public override void OnPausing()
    {

    }
    public override void OnResuming()
    {

    }
    public override void OnExiting()
    {
        gameObject.SetActive(false);
    }
    
    /// <summary>
    /// 切换到选择角色场景
    /// </summary>
    public void ChangeToSelectPlayerScene()
    {
        //    //if(xxx)
        //    //判断登陆是否成功，如果成功则跳转到开始界面
        //    UIManager.Instance.PopUIPanel();
        //    //如果失败则跳转到失败界面
        //    //else{xxx}
        //    //gameObject.SetActive(true);
        //    //failedBg.gameObject.SetActive(true);

        //SceneManager.LoadSceneAsync(ConstDates.SelectPlayerSceneIndex);
    }
    public void Onclick()
    {
        failedBg.gameObject.SetActive(false);
    }
    public void Exc()
    {
        gameObject.SetActive(false);
        UIManager.Instance.PushUIPanel(ConstDates.UIStart);
    }
    public void Error()
    {
        failedBg.gameObject.SetActive(true);

    }
}
