using System.Collections;
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
        //AddUIPrefabs(ConstDates.UIStart);
        //AddUIPrefabs(ConstDates.UILogin);
        //AddUIPrefabs(ConstDates.UIRegister);
        //AddUIPrefabs(ConstDates.UISelectSever);
        //AddUIPrefabs(ConstDates.UISelectRole);        
        
        //hj
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UIStart);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UILogin);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UIRegister);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UISelectSever);
        AddUIPrefabs(ConstDates.ResourcePrefabDirHj,ConstDates.UISelectRole);
        //swl
        AddUIPrefabs(ConstDates.ResourcePrefabDirSwl, ConstDates.UISelectPlayer);
        AddUIPrefabs(ConstDates.ResourcePrefabDirSwl, ConstDates.UICreatePlayer);
        //zcc
        AddUIPrefabs(ConstDates.ResourcePrefabDirZcc, ConstDates.UIMain);
        AddUIPrefabs(ConstDates.ResourcePrefabDirZcc, ConstDates.UIPlayerProperty);
        //Ttj
        AddUIPrefabs(ConstDates.ResourcePrefabDirTtj, ConstDates.UIBag);
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
        if (obj) uiObject.Add(UIname, obj);
    }

    /// <summary>
    /// 界面入栈
    /// </summary>
    /// <param name="UIname">UI界面的名字</param>
    public void PushUIPanel(string UIname)
    {
        //说明栈内存在界面
        if (currentUIStack.Count > 0)
        {
            //返回栈顶界面不移除
            UIBase old_pop = currentUIStack.Peek();
            old_pop.OnPausing();//暂时停用
        }
        //创建界面
        UIBase new_pop = GetUIBase(UIname);
        new_pop.OnEntering();
        currentUIStack.Push(new_pop);
    }

    /// <summary>
    /// 创建界面
    /// </summary>
    /// <param name="UIname">UI界面的名字</param>
    /// <returns></returns>
    UIBase GetUIBase(string UIname)
    {
        //currentUI已经有该UI界面
        foreach (var name in uiHaveLoaded.Keys)
        {
            if (name == UIname)
            {
                return uiHaveLoaded[UIname];
            }
        }
        //如果currentUI没有界面，那么应该根据预支体实例化界面并保存在其中
        GameObject uiPrefab = uiObject[UIname];
        GameObject objUI = Instantiate(uiPrefab);
        print(objUI.name);
        objUI.name = UIname;

        UIBase uibase = objUI.GetComponent<UIBase>();
        uiHaveLoaded.Add(UIname, uibase);
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
            new_pop.OnEntering();
        }
    }

}
