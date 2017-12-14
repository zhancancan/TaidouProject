using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIRegister : UIBase
{
    Image failedBG;//注册失败界面
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
    }
    public void Onclick()
    {
        failedBG.gameObject.SetActive(false);
    }
}
