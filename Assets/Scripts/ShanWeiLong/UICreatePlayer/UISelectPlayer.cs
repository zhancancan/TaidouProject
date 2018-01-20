using System;
using System.Collections;
using System.Collections.Generic;
using TaidouCommon.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISelectPlayer : UIBase{
    Text PersonName;
    Text profession;
    Image seximg;
    Button right, left;
    bool isleft=false;
    bool isright=false;
    public List<RoleSelected> selectplayer;
    public static UISelectPlayer _instance;
    private void Awake()
    {
        _instance = this;
        PersonName = transform.Find("LoginBg/PersonInformationControl/PersonInformationPanel/PersonName").GetComponent<Text>();
        profession = transform.Find("LoginBg/PersonInformationControl/PersonInformationPanel/PersonPosition").GetComponent<Text>();
        right = transform.Find("LoginBg/Panel/rightbtn").GetComponent<Button>();
        left = transform.Find("LoginBg/Panel/leftbtn").GetComponent<Button>();
        EventTriggerListener.GetListener(left.gameObject).onPointerDown += onleftdown;
        EventTriggerListener.GetListener(left.gameObject).onPointerUp += onleftup;
        EventTriggerListener.GetListener(right.gameObject).onPointerDown += onrightdown;
        EventTriggerListener.GetListener(right.gameObject).onPointerUp += onrightup;

    }

    private void onrightup(GameObject go, PointerEventData eventData)
    {
        isright = false;
    }

    private void onrightdown(GameObject go, PointerEventData eventData)
    {
        isright = true;
    }

    private void onleftup(GameObject go, PointerEventData eventData)
    {
        isleft = false;
    }

    private void onleftdown(GameObject go, PointerEventData eventData)
    {
        isleft = true;
    }
    private void Update()
    {
        if (isleft == true)
        {
            leftrotate();
        }
        else if(isright==true)
        {
            rightrotate();
        }
    }
    GameObject it;

    public void leftrotate()
    {
        it = GameObject.FindGameObjectWithTag("Role");
        if (it!=null)
        {   
            it.transform.Rotate(Vector3.up * 5);
        }
        else
        {
            return;
        }
        
    }

    public void rightrotate()
    {
        it = GameObject.FindGameObjectWithTag("Role");
        if (it != null)
        {
            it.transform.Rotate(-Vector3.up * 5);
        }
        else
        {
            return;
        }
    }

    private void OnDestroy()
    {
       
    }
    public override void OnEntering()
    {
        gameObject.SetActive(true);
    }
    private void Start()
    {
        PlayerSelect._instance.ShowChar(PlayerSelect._instance.rolelist[0]);
        selectplayer[0].SendMessage("UpdateShow");
        
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
    /// 切换到创建角色场景
    /// </summary>
    public void ChangerToCreatePlayerScene()
    {
        
        SceneManager.LoadSceneAsync(ConstDates.CreatePlayerSceneIndex);
    }
    public void change()
    {
        SceneManager.LoadSceneAsync(ConstDates.MainScene);
        
    }

   
}
