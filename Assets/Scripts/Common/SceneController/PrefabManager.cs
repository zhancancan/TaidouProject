using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {
    //单例
    private static PrefabManager _instance;
    public static PrefabManager Instance
    {
        get { return _instance; }
    }

    //保存所有的预支体
    private Dictionary<string, GameObject> prefabObject = new Dictionary<string, GameObject>();

    void Awake ()
    {
        _instance = this;

        AddUIPrefabs(ConstDates.ResourceEffectPrefabDirZcc,ConstDates.Effect_MouseClick_Green);
    }

    /// <summary>
    /// 加载所有的预支体
    /// </summary>
    /// <param name="selfPath">自己定义自己的预设体路径</param>
    /// <param name="name">预设体名字</param>
    void AddUIPrefabs(string selfPath, string name)
    {
        string path = selfPath + "/" + name;
        GameObject obj = Resources.Load<GameObject>(path);
        if (obj) prefabObject.Add(name, obj);
    }

    /// <summary>
    /// 获取预设体实例
    /// </summary>
    /// <param name="name">预设体名字</param>
    public GameObject GetUIPrefabInstance(string name)
    {
        GameObject prefab = prefabObject[name];
        GameObject obj = Instantiate(prefab);
        return obj;
    }

    /// <summary>
    /// 获取预设体实例,并且修改名字
    /// </summary>
    /// <param name="originalName">预设体原来名字</param>
    /// <param name="currentName">预设体实例现在名字</param>
    public GameObject GetUIPrefabInstance(string originalName, string currentName)
    {
        GameObject prefab = prefabObject[originalName];
        GameObject obj = Instantiate(prefab);
        obj.name = currentName;
        return obj;
    }
}
