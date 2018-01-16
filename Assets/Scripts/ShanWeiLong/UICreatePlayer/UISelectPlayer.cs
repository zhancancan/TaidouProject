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
    public int index=-1;
    public List<RoleSelected> selectplayer;
    public static UISelectPlayer _instance;
    RoleController rolecontroller;
    private void Awake()
    {
        _instance = this;
        PersonName = transform.Find("LoginBg/PersonInformationControl/PersonInformationPanel/PersonName").GetComponent<Text>();
        profession = transform.Find("LoginBg/PersonInformationControl/PersonInformationPanel/PersonPosition").GetComponent<Text>();
        rolecontroller = transform.GetComponent<RoleController>();

        //rolecontroller.GetRole();
        //rolecontroller.OnAddRole += AddRole;
        //rolecontroller.OnGetRole += GetRole;

    }
    private void OnDestroy()
    {
        //rolecontroller.OnAddRole -= AddRole;
        //rolecontroller.OnGetRole -= GetRole;
    }
    public override void OnEntering()
    {
        rolelist = PlayerSelect._instance.rolelist;
        PlayerSelect._instance.GetRole(rolelist); 
        gameObject.SetActive(true);
        //AddController();
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
        PlayerPrefs.SetInt("Index", index);
        SceneManager.LoadSceneAsync(ConstDates.CreatePlayerSceneIndex);
    }

    /// <summary>
    /// 切换到主场景
    /// </summary>
    public void ChangerToMainScene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadSceneAsync(ConstDates.MainSceneIndex);
        
    }
    public List<Role> rolelist = null;
    //public void AddController()
    //{
       
    //    index = PlayerPrefs.GetInt("index");
    //    selectplayer[index].UpdateShow();
    //}
    //public void GetRole(List<Role> rolelist )
    //{
    //    UISelectPlayer._instance.rolelist = rolelist;
    //    if (rolelist != null&&rolelist.Count>0)
    //    {
    //        Role role = rolelist[0];
    //        ShowRole(role);
    //    }
    //    else
    //    {
    //        SceneManager.LoadSceneAsync(ConstDates.CreatePlayerSceneIndex);
    //    }
    //}
    //public void AddRole(Role role)
    //{
    //    if (rolelist == null)
    //    {
    //        rolelist = new List<Role>();
    //    }
    //    rolelist.Add(role);
    //    ShowRole(role);
    //}
    //public void ShowRole(Role role)
    //{
    //    PhotonEngine.Instance.role = role;
    //    PersonName.text = role.Name;

        
    //}
}
