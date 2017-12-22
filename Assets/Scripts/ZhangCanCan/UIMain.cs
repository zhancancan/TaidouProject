﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain:UIBase{
    private Button playerPropertyBtn;

    void Awake()
    {
        playerPropertyBtn = transform.Find("FunctionBar/SettingBtn").GetComponent<Button>();
    }

    void Start()
    {
        playerPropertyBtn.onClick.AddListener(OnPlayerPropertyBtnClick);
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

    /// <summary>
    /// 点击人物属性按钮
    /// </summary>
    void OnPlayerPropertyBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIPlayerProperty);
    }
}
