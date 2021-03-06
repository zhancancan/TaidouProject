﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 该类管理所有UI界面
/// </summary>
public class UIManager : MonoBehaviour
{
    //单例
    private static UIManager _instance;
    public static UIManager Instance
    {
        get{ return _instance;}
    }

    //控制界面的显示与隐藏
    public Stack<UIBase> currentUIStack = new Stack<UIBase>();

    //根据名字保存所有已经显示过的页面
    public Dictionary<string, UIBase> uiHaveLoaded = new Dictionary<string, UIBase>();

    //保存所有的预支体
    Dictionary<string, GameObject> uiObject = new Dictionary<string, GameObject>();

    private void Awake()
    {
        //引用单例
        _instance = this;
        //加载资源

        //common
        AddUIPrefabs(ConstDates.ResourcePrefabDirCommon, ConstDates.UISystemSetting);
        //hj
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UIStart);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UILogin);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UIRegister);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UISelectSever);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UISelectRole);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UITask);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UIGemstoneCompose);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UITaskList);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj, ConstDates.UITranscript);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj, ConstDates.UIProgressBar);

        //swl
        AddUIPrefabs(ConstDates.ResourcePrefabDirSwl, ConstDates.UISelectPlayer);
        AddUIPrefabs(ConstDates.ResourcePrefabDirSwl, ConstDates.UICreatePlayer);
        AddUIPrefabs(ConstDates.ResourcePrefabDirSwl, ConstDates.UISkill);
        AddUIPrefabs(ConstDates.ResourcePrefabDirSwl, ConstDates.UISkillItem);
        AddUIPrefabs(ConstDates.ResourcePrefabDirSwl, ConstDates.UISkillPic);
        //zcc
        AddUIPrefabs(ConstDates.ResourcePrefabDirZcc, ConstDates.UIMain);
        AddUIPrefabs(ConstDates.ResourcePrefabDirZcc, ConstDates.UIPlayerProperty);
        AddUIPrefabs(ConstDates.ResourcePrefabDirZcc, ConstDates.UIStore);
        AddUIPrefabs(ConstDates.ResourcePrefabDirZcc, ConstDates.UIStoreViceItem);
        AddUIPrefabs(ConstDates.ResourcePrefabDirZcc, ConstDates.UIStoreItem);
        AddUIPrefabs(ConstDates.ResourcePrefabDirZcc, ConstDates.UIRecharge);
        AddUIPrefabs(ConstDates.ResourcePrefabDirZcc, ConstDates.UISignIn);
        //ttj
        AddUIPrefabs(ConstDates.ResourcePrefabDirTtj, ConstDates.UIBag);
        //zpf
        AddUIPrefabs(ConstDates.ResourcePrefabDirZpf, ConstDates.UIPet);
        AddUIPrefabs(ConstDates.ResourcePrefabDirZpf, ConstDates.UIPetMain);
        AddUIPrefabs(ConstDates.ResourcePrefabDirZpf, ConstDates.UILion);
        AddUIPrefabs(ConstDates.ResourcePrefabDirZpf, ConstDates.UIFairy);
        AddUIPrefabs(ConstDates.ResourcePrefabDirZpf, ConstDates.UIElf);
    }

    /// <summary>
    /// 加载所有的预支体界面
    /// </summary>
    /// <param name="selfPath">自己定义自己的预设体路径</param>
    /// <param name="uiName">UI界面的名字</param>
    void AddUIPrefabs(string selfPath,string uiName)
    {
        string path = selfPath + "/" + uiName;
        GameObject obj = Resources.Load<GameObject>(path);
        if (obj) uiObject.Add(uiName, obj);
    }

    /// <summary>
    /// 界面入栈
    /// </summary>
    /// <param name="uiName">UI界面的名字</param>
    public void PushUIPanel(string uiName)
    {
        //说明栈内存在界面
        if (currentUIStack.Count > 0)
        {
            //返回栈顶界面不移除
            UIBase old_pop = currentUIStack.Peek();
            old_pop.OnPausing();//暂时停用
        }
        //创建界面
        UIBase new_pop = GetUIBase(uiName);
        new_pop.OnEntering();
        currentUIStack.Push(new_pop);
    }

    /// <summary>
    /// 创建界面
    /// </summary>
    /// <param name="UIname">UI界面的名字</param>
    /// <returns></returns>
    UIBase GetUIBase(string uiName)
    {
        //currentUI已经有该UI界面
        foreach (var name in uiHaveLoaded.Keys)
        {
            if (name == uiName)
            {
                return uiHaveLoaded[uiName];
            }
        }
        //如果currentUI没有界面，那么应该根据预支体实例化界面并保存在其中
        GameObject uiPrefab = uiObject[uiName];
        GameObject objUI = Instantiate(uiPrefab);
        print(objUI.name);
        objUI.name = uiName;

        UIBase uibase = objUI.GetComponent<UIBase>();
        uiHaveLoaded.Add(uiName, uibase);
        return uibase;
    }

    /// <summary>
    /// 界面出栈
    /// </summary>
    public void PopUIPanel()
    {
        if (currentUIStack.Count == 0) return;
        UIBase old_pop = currentUIStack.Pop();
        old_pop.OnExiting();

        if (currentUIStack.Count > 0)
        {
            UIBase new_pop = currentUIStack.Peek();
            //new_pop.OnEntering();
        }
    }

    /// <summary>
    /// 获取UI预设体实例,可以修改名字
    /// </summary>
    /// <param name="originalUIName">UI预设体原来名字</param>
    /// <param name="currentUIName">UI预设体实例现在名字</param>
    public GameObject GetUIPrefabInstance(string originalUIName, string currentUIName = null)
    {
        GameObject uiPrefab = uiObject[originalUIName];
        GameObject objUI = Instantiate(uiPrefab);
        if (null != currentUIName) objUI.name = currentUIName;
        return objUI;
    }

    public GameObject GetUIPrefabInstance(string originalUIName, Transform parent, string currentUIName = null)
    {
        GameObject uiPrefab = uiObject[originalUIName];
        GameObject objUI = Instantiate(uiPrefab, parent);
        if (null != originalUIName) objUI.name = currentUIName;
        return objUI;
    }

    public GameObject GetUIPrefabInstance(string originalUIName, Transform parent, bool worldPositionStays, string currentUIName = null)
    {
        GameObject uiPrefab = uiObject[originalUIName];
        GameObject objUI = Instantiate(uiPrefab, parent, worldPositionStays);
        if (null != originalUIName) objUI.name = currentUIName;
        return objUI;
    }

    public GameObject GetUIPrefabInstance(string originalUIName, Vector3 position, Quaternion rotation, string currentUIName = null)
    {
        GameObject uiPrefab = uiObject[originalUIName];
        GameObject objUI = Instantiate(uiPrefab, position, rotation);
        if (null != originalUIName) objUI.name = currentUIName;
        return objUI;
    }

    public GameObject GetUIPrefabInstance(string originalUIName, Vector3 position, Quaternion rotation, Transform parent, string currentUIName = null)
    {
        GameObject uiPrefab = uiObject[originalUIName];
        GameObject objUI = Instantiate(uiPrefab, position, rotation, parent);
        if (null != originalUIName) objUI.name = currentUIName;
        return objUI;
    }
}
