using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private ObjectPoolManager _instance;

    public ObjectPoolManager Instance
    {
        get { return _instance; }
    }

    List<GameObject> gameObjList = new List<GameObject>();
    private int sumCount = 0;

    void Awake()
    {
        _instance = this;
    }

    /// <summary>
    /// 添加对象到对象池
    /// </summary>
    /// <param name="maxCount"></param>
    /// <param name="prefabName"></param>
    public void CreateObjsPool(string prefabOriginalName, int maxCount, PoolObjectType poType,Transform parent = null)
    {
        sumCount += maxCount;
        for (int i = 0; i <maxCount; i++)
        {
            //创建对象
            GameObject obj = PrefabManager.Instance.GetPrefabInstance(prefabOriginalName, prefabOriginalName);
            //添加脚本，初始化对象池属性
            PoolProperty pp = obj.AddComponent<PoolProperty>();
            pp.init(false,Vector3.zero,Quaternion.identity, Vector3.one,parent);
            pp.PoType = poType;

            obj.SetActive(false);
            gameObjList.Add(obj);
        }
    }

    /// <summary>
    /// 还原对象池属性,对象需要销毁的时候调用
    /// </summary>
    /// <param name="obj">需要还原的对象</param>
    /// <param name="parent">父节点</param>
    public void InitPoolProperty(GameObject obj, Transform parent = null)
    {
        obj.GetComponent<PoolProperty>().init(false, Vector3.zero, Quaternion.identity, Vector3.one,parent);
        obj.SetActive(false);
    }

    /// <summary>
    /// 根据对象的类型从对象池中显示一个对象
    /// </summary>
    /// <param name="poType">对象类型</param>
    /// <param name="position">位置</param>
    /// <param name="rotation">角度</param>
    /// <param name="scale">比例</param>
    /// <param name="parent">父节点</param>
    public void ShowObj(PoolObjectType poType,Vector3 position, Quaternion rotation, Vector3 scale, Transform parent = null)
    {
        string prefabName = null;
        for (int i = 0; i < sumCount; i++)
        {
            PoolProperty pp = gameObjList[i].GetComponent<PoolProperty>();
            if (pp.PoType == poType) prefabName = pp.gameObject.name;  //获取当前类型对象的预设体名字
            if (!pp.IsUsed && pp.PoType == poType)
            {
                pp.init(true, position, rotation, scale, parent);
                pp.gameObject.SetActive(true);
                return;
            }
        }
        //Debug.Log("enemy all busy! create new!");
        CreateObjsPool(prefabName,1, poType,parent);   //当对象池中的对象都已经被使用，添加一个对应类型的对象到对象池中
    }
    
}
