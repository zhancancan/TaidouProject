using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class UIMain:UIBase{
    void Awake()
    {
        //第一次进场景，加载所有UI界面
        UIManager.Instance.PushUIPanel(ConstDates.UIPet);
        UIManager.Instance.PushUIPanel(ConstDates.UIGemstoneCompose);
        UIManager.Instance.PushUIPanel(ConstDates.UIPlayerProperty);
        UIManager.Instance.PushUIPanel(ConstDates.UITask);
        UIManager.Instance.PushUIPanel(ConstDates.UISkill);
        UIManager.Instance.PushUIPanel(ConstDates.UIStore);
        UIManager.Instance.PushUIPanel(ConstDates.UISystemSetting);
        UIManager.Instance.PushUIPanel(ConstDates.UIRecharge);
        UIManager.Instance.PushUIPanel(ConstDates.UISignIn);
        UIManager.Instance.PushUIPanel(ConstDates.UIBag);
    }

    public override void OnEntering()
    {
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
       
    }
}
