using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //管理所有的页面显示
    Stack<UIBase> UIStack = new Stack<UIBase>();

    //根据名字保存所有进栈的界面
    Dictionary<string, UIBase> currentUI = new Dictionary<string, UIBase>();

    //保存所有的预支体
    Dictionary<string, GameObject> UIObject = new Dictionary<string, GameObject>();

    private void Awake()
    {
        //引用单例
        _instance = this;
        //加载资源
        //AddUIPrefabs(ConstDates.UIStart);
        //AddUIPrefabs(ConstDates.UILogin);
        //AddUIPrefabs(ConstDates.UIRegister);
        //AddUIPrefabs(ConstDates.UISelectSever);
        //AddUIPrefabs(ConstDates.UISelectRole);        
        
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UIStart);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UILogin);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UIRegister);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UISelectSever);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UISelectRole);

        AddUIPrefabs(ConstDates.ResourcePrefabDirZcc, ConstDates.UIMain);
    }

    /// <summary>
    /// 加载所有的预支体界面
    /// </summary>
    /// <param name="UIname">UI界面的名字</param>
    //void AddUIPrefabsHj(string UIname)
    //{
    //    string path = ConstDates.ResourcePrefabDirHj + "/" + UIname;
    //    GameObject obj = Resources.Load<GameObject>(path);
    //    if (obj) UIObject.Add(UIname, obj);
    //}

    /// <summary>
    /// 加载所有的预支体界面
    /// </summary>
    /// <param name="selfPath">自己定义自己的预设体路径</param>
    /// <param name="UIname">UI界面的名字</param>
    void AddUIPrefabs(string selfPath,string UIname)
    {
        string path = selfPath + "/" + UIname;
        GameObject obj = Resources.Load<GameObject>(path);
        if (obj) UIObject.Add(UIname, obj);
    }

    /// <summary>
    /// 界面入栈
    /// </summary>
    /// <param name="UIname">UI界面的名字</param>
    public void PushUIPanel(string UIname)
    {
        //说明栈内存在界面
        if (UIStack.Count > 0)
        {
            //返回栈顶界面不移除
            UIBase old_pop = UIStack.Peek();
            old_pop.OnPausing();//暂时停用
        }
        //创建界面
        UIBase new_pop = GetUIBase(UIname);
        new_pop.OnEntering();
        UIStack.Push(new_pop);
    }

    /// <summary>
    /// 创建界面
    /// </summary>
    /// <param name="UIname">UI界面的名字</param>
    /// <returns></returns>
    UIBase GetUIBase(string UIname)
    {
        foreach (var name in currentUI.Keys)
        {
            if (name == UIname)
            {
                return currentUI[UIname];
            }
        }
        //如果currentUI没有界面，那么应该根据预支体实例化界面并保存在其中
        GameObject UIPrefab = UIObject[UIname];
        GameObject objUI = Instantiate(UIPrefab);
        objUI.name = UIname;

        UIBase uibase = objUI.GetComponent<UIBase>();
        currentUI.Add(UIname, uibase);
        return uibase;
    }

    /// <summary>
    /// 界面出栈
    /// </summary>
    public void PopUIPanel()
    {
        if (UIStack.Count == 0) return;
        UIBase old_pop = UIStack.Pop();
        old_pop.OnExiting();

        if (UIStack.Count > 0)
        {
            UIBase new_pop = UIStack.Peek();
            new_pop.OnEntering();
        }
    }

}
