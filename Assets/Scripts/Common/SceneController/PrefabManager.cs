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
    public Dictionary<string, GameObject> prefabObject = new Dictionary<string, GameObject>();

    void Awake ()
    {
        _instance = this;
        //zcc
        AddPrefabs(ConstDates.ResourceEffectPrefabDirZcc,ConstDates.Effect_MouseClick_Green);

        //zpf
        //宠物UI预制体
        AddPrefabs(ConstDates.ResourcePetPrefabDirZpf, ConstDates.Lion);
        AddPrefabs(ConstDates.ResourcePetPrefabDirZpf, ConstDates.Elf);
        AddPrefabs(ConstDates.ResourcePetPrefabDirZpf, ConstDates.Fairy);
        //宠物特效预制体
        AddPrefabs(ConstDates.ResourcePetPrefabEffectZpf, ConstDates.LionEffect);
        AddPrefabs(ConstDates.ResourcePetPrefabEffectZpf, ConstDates.ElfEffect);
        AddPrefabs(ConstDates.ResourcePetPrefabEffectZpf, ConstDates.FairyEffect);      
    }

    /// <summary>
    /// 加载所有的预支体
    /// </summary>
    /// <param name="selfPath">自己定义自己的预设体路径</param>
    /// <param name="name">预设体名字</param>
    void AddPrefabs(string selfPath, string name)
    {
        string path = selfPath + "/" + name;
        GameObject obj = Resources.Load<GameObject>(path);
        if (obj) prefabObject.Add(name, obj);
    }

    /// <summary>
    /// 获取预设体实例,可以修改名字
    /// <param name="originalName">预设体原来名字</param>
    /// <param name="currentName">预设体实例现在名字</param>
    public GameObject GetPrefabInstance(string originalName, string currentName=null)
    {
        GameObject prefab = prefabObject[originalName];
        GameObject obj = Instantiate(prefab);
        if (null != currentName) obj.name = currentName;
        return obj;
    }

    public GameObject GetPrefabInstance(string originalName, Transform parent, string currentName = null)
    {
        GameObject prefab = prefabObject[originalName];
        GameObject obj = Instantiate(prefab,parent);
        if (null != currentName) obj.name = currentName;
        return obj;
    }

    public GameObject GetPrefabInstance(string originalName, Transform parent,bool worldPositionStays, string currentName = null)
    {
        GameObject prefab = prefabObject[originalName];
        GameObject obj = Instantiate(prefab, parent,worldPositionStays);
        if (null != currentName) obj.name = currentName;
        return obj;
    }

    public GameObject GetPrefabInstance(string originalName, Vector3 position, Quaternion rotation, string currentName = null)
    {
        GameObject prefab = prefabObject[originalName];
        GameObject obj = Instantiate(prefab, position, rotation);
        if (null != currentName) obj.name = currentName;
        return obj;
    }

    public GameObject GetPrefabInstance(string originalName, Vector3 position, Quaternion rotation,Transform parent, string currentName = null)
    {
        GameObject prefab = prefabObject[originalName];
        GameObject obj = Instantiate(prefab, position, rotation, parent);
        if (null != currentName) obj.name = currentName;
        return obj;
    }

}
