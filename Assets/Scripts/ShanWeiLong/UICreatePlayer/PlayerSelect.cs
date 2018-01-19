using System.Collections;
using System.Collections.Generic;
using TaidouCommon.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class PlayerSelect : MonoBehaviour
{
    RoleController rolecontroller;
    LoginController login;
    public static PlayerSelect _instance;
    private void Awake()
    {
        _instance = this;
        login = GetComponent<LoginController>();
        rolecontroller = transform.GetComponent<RoleController>();
        rolecontroller.OnAddRole += AddRole;
        rolecontroller.OnGetRole += GetRole;
       
    }
    public List<Role> rolelist = null;
    public void GetRole(List<Role> rolelist)
    {
        PlayerSelect._instance.rolelist = rolelist;
        if (rolelist != null && rolelist.Count > 0)
        {
            Role role = rolelist[0];
            SceneManager.LoadSceneAsync(ConstDates.SelectPlayerScene);
        }
        else
        {
            SceneManager.LoadSceneAsync(ConstDates.CreatePlayerSceneIndex);
        }
    }

    public void ShowChar(Role role)
    {
        int index;
       
            for (int i = 0; i < rolelist.Count; i++)
            {
                index = i;
                UISelectPlayer._instance.selectplayer[index].PersonName.text = rolelist[index].Name;
                UISelectPlayer._instance.selectplayer[index].profession.text = "<color=#F1FF00FF>" + rolelist[index].Profession + "</color>";
                UISelectPlayer._instance.selectplayer[index].level.text = "<color=#00FF7FFF>" + rolelist[index].Level + "</color>";
                if (rolelist[index].IsMan == true)
                {
                    if (rolelist[index].Profession == "战士")
                    {
                       UISelectPlayer._instance.selectplayer[index].seximg.sprite = Resources.Load("TanTianJun/Image/男战士", typeof(Sprite)) as Sprite;
                       UISelectPlayer._instance.selectplayer[index].seximg.DOFade(1, 0);
                     }
                    else if(rolelist[index].Profession == "法师")
                    {
                       UISelectPlayer._instance.selectplayer[index].seximg.sprite = Resources.Load("TanTianJun/Image/男法师", typeof(Sprite)) as Sprite;
                       UISelectPlayer._instance.selectplayer[index].seximg.DOFade(1, 0);
                    }
                   else
                   {
                      UISelectPlayer._instance.selectplayer[index].seximg.sprite = Resources.Load("TanTianJun/Image/男弓箭手", typeof(Sprite)) as Sprite;
                      UISelectPlayer._instance.selectplayer[index].seximg.DOFade(1, 0);
                   }
                }
                else
                {
                   if (rolelist[index].Profession == "战士")
                   {
                    UISelectPlayer._instance.selectplayer[index].seximg.sprite = Resources.Load("TanTianJun/Image/女战士", typeof(Sprite)) as Sprite;
                    UISelectPlayer._instance.selectplayer[index].seximg.DOFade(1, 0);
                   }
                   else if (rolelist[index].Profession == "法师")
                   {
                    UISelectPlayer._instance.selectplayer[index].seximg.sprite = Resources.Load("TanTianJun/Image/女法师", typeof(Sprite)) as Sprite;
                    UISelectPlayer._instance.selectplayer[index].seximg.DOFade(1, 0);
                   }
                   else
                   {
                    UISelectPlayer._instance.selectplayer[index].seximg.sprite = Resources.Load("TanTianJun/Image/女弓箭手", typeof(Sprite)) as Sprite;
                    UISelectPlayer._instance.selectplayer[index].seximg.DOFade(1, 0);
                   }
                }
            }
         
    }

    public void AddRole(Role role)
    {
        if (rolelist == null)
        {
            rolelist = new List<Role>();
        }
        rolelist.Add(role);
        SceneManager.LoadSceneAsync(ConstDates.SelectPlayerScene);

    }
    //添加角色
    public void ShowRole(Role role)
    {
        if (role == null)
        {
            if (rolelist != null)
            {
                if (rolelist.Count >= 5)
                {
                    MessageManager._instance.ShowMessage("角色已满");
                    return;
                }
                //for (int i = 0; i < rolelist.Count; i++)
                //{
                //    if (CharacterSelectController._instance.nametxt.text == rolelist[i].Name)
                //    {
                //        MessageManager._instance.ShowMessage("角色名重复");
                //        return;
                //    }
                //}
                  
            }
            Role roleAdd = new Role();
            roleAdd.Name = CharacterSelectController._instance.nametxt.text;
            roleAdd.Level = 1;
            roleAdd.Exp = 0;
            roleAdd.Coin = 20000;
            roleAdd.Diamond = 1000;
            roleAdd.Energy = 100;
            roleAdd.Toughen = 50;
            roleAdd.Profession = CharacterSelectController._instance.profession;
            roleAdd.IsMan = CharacterSelectController._instance.isman;
            rolecontroller.AddRole(roleAdd);

        }
      
     }
    public void Login()
    {
        login.Login(UILogin.Instance.username.text, UILogin.Instance.password.text);
    }
   
}