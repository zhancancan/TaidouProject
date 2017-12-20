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
    public override void OnEntering()
    {
        
        gameObject.SetActive(true);
        //播放声音
        //SoundManager.Instance.PlayBGSound(ConstDates.Bgm_1);
        SoundManager.Instance.PlayBGSound(ConstDates.ResourceAudiosDirHj,ConstDates.Bgm_1);
        pleaseLoginbg = GameObject.Find("PleaseLoginBG").GetComponent<Image>();
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
        UIManager.Instance.PushUIPanel(ConstDates.UISelectSever);
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
}
