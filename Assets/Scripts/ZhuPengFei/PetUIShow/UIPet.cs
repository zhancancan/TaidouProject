﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPet : UIBase {
    Button exitBtn;
    void Awake()
    {
        exitBtn = transform.Find("Panel/PetClose").GetComponent<Button>();
    }

    void Start()
    {
        exitBtn.onClick.AddListener(OnExitBtnClick);
    }

    public override void OnEntering()
    {
        gameObject.SetActive(true);
    }

    public override void OnPausing()
    {
        gameObject.SetActive(false);
    }

    public override void OnResuming()
    {
        
    }

    public override void OnExiting()
    {
        gameObject.SetActive(false);
    }

    private void OnExitBtnClick()
    {
        UIManager.Instance.PopUIPanel();
    }
}
