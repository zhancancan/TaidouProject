using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UILogin : UIBase {
    Image failedBg;//登陆失败界面
    Button LoginBtn; //登陆按钮\
    [HideInInspector]
    public Text username;
    [HideInInspector]
    public InputField password;
    private static UILogin _instance;
    public static UILogin Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        _instance = this;
        username = transform.Find("UIBG/LoginBG/AccountTxt/InputAccount/Text").GetComponent<Text>();
        password = transform.Find("UIBG/LoginBG/PassWordTxt /InputAccount").GetComponent<InputField>();
        LoginBtn =transform.Find("UIBG/LoginBG/LoginBtn") .GetComponent<Button>();
        LoginBtn.onClick.AddListener(() => { PlayerSelect._instance.Login(); });
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
