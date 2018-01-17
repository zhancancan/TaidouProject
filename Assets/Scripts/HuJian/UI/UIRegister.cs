using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Text.RegularExpressions;

public class UIRegister : UIBase
{
    Image failedBG;//注册失败界面
    Text username;
    InputField password;
    InputField againpassword;
    RegisterController register;
    GameObject MessagePanel;
   
    private void Awake()
    {
        username = transform.Find("UIBG/RegisterBG/AccountTxt/InputAccount/Text").GetComponent<Text>();
        password=transform.Find("UIBG/RegisterBG/PassWordTxt /InputAccount").GetComponent<InputField>();
        againpassword = transform.Find("UIBG/RegisterBG/AgainPassWordTxt/InputAccount").GetComponent<InputField>();
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
    Regex reg = new Regex(@"(?i)^[a-z][\w]{3,10}$");
    Regex regps = new Regex(@"^[a-zA-Z]\w{5,11}$");
    public void Register()
    {
        
        if (username.text == null||password.text==null )
        {
           
            MessageManager._instance.ShowMessage("用户名或密码不能为空");
            return;
        }
        else if(!reg.IsMatch(username.text))
        {
            MessageManager._instance.ShowMessage("用户名只能由字母开头长度为4-10个字母或者数字或下划线组成的字符串组成");
            return;
        }
        else if (!regps.IsMatch(password.text))
        {
            MessageManager._instance.ShowMessage("密码只能以字母开头,长度在6~12之间,只能包含字母、数字和下划线");
            return;
        }
       else if (password.text != againpassword.text)
        {
            MessageManager._instance.ShowMessage("密码不一致");
        }
        register.Register(username.text, password.text);
    }
}
