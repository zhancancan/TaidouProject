using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPlayerProperty : UIBase
{
    private Button exitBtn;

    void Awake()
    {
        exitBtn = transform.Find("PlayerPropertyBg/Exit").GetComponent<Button>();
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

    /// <summary>
    /// 退出button点击
    /// </summary>
    void OnExitBtnClick()
    {
        UIManager.Instance.PopUIPanel();
    }

}
