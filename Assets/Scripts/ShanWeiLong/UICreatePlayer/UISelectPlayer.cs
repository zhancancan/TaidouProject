using System.Collections;
using System.Collections.Generic;
using TaidouCommon.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISelectPlayer : UIBase {
    Text PersonName;
    Text profession;
    Image seximg;
    public List<RoleSelected> selectplayer;
    public static UISelectPlayer _instance;
    RoleController rolecontroller;
    private void Awake()
    {
        _instance = this;
        PersonName = transform.Find("LoginBg/PersonInformationControl/PersonInformationPanel/PersonName").GetComponent<Text>();
        profession = transform.Find("LoginBg/PersonInformationControl/PersonInformationPanel/PersonPosition").GetComponent<Text>();
        rolecontroller = transform.GetComponent<RoleController>();
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

  
  
}
