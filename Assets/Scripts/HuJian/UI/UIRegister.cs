using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIRegister : UIBase
{
    Image failedBG;//注册失败界面
    Text username;
    Text password;
    Text againpassword;
    RegisterController register;
    GameObject MessagePanel;
   
    private void Awake()
    {
        username = transform.Find("UIBG/RegisterBG/AccountTxt/InputAccount/Text").GetComponent<Text>();
        password=transform.Find("UIBG/RegisterBG/PassWordTxt /InputAccount/Text").GetComponent<Text>();
        againpassword = transform.Find("UIBG/RegisterBG/AgainPassWordTxt/InputAccount/Text").GetComponent<Text>();
        MessagePanel = transform.Find("MessagePanel").gameObject;
      
        register = GetComponent<RegisterController>();
    }
    public override void OnEntering()
    {
        failedBG = transform.Find("FailedBG").GetComponent<Image>();
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
    public void Exc()
    {
        gameObject.SetActive(false);
        UIManager.Instance.PushUIPanel(ConstDates.UIStart);
    }
    public void Onclick()
    {
        gameObject.SetActive(false);
    }
    public void Register()
    {
        
        if (username.text == null || username.text.Length <= 3)
        {
           
            MessageManager._instance.ShowMessage("字符少于3个");
            return;
        }
        if (password.text == null || password.text.Length <= 3)
        {
            MessageManager._instance.ShowMessage("字符少于3个");
            return;
        }
        if (password.text != againpassword.text)
        {
            MessageManager._instance.ShowMessage("密码不一致");
            return;
        }
       
        register.Register(username.text, password.text);
    }
}
