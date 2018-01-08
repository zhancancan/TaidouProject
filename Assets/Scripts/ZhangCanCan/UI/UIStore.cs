using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIStore : UIBase
{
    private ToggleGroup mainToggleGroup;    //主列表
    private ToggleGroup viceToggleGroup;    //副列表
    private Toggle mainActiveToggle;        //主列表激活的Toggle
    private Toggle viceActiveToggle;        //副列表激活的Toggle
    private GameObject mainToggleParent;    //主列表Item的父层级
    private GameObject viceToggleParent;    //副列表Item的父层级
    private Transform ItemBgParent;        //物品背景父层级
    private Button exit;

    //保存所有副列表Item,控制副列表的显隐
    private List<Dictionary<object, GameObject>> viceToggleList = new List<Dictionary<object, GameObject>>();
    //保存所有物体，控制物体的显隐
    private List<Dictionary<object, GameObject>> itemList = new List<Dictionary<object, GameObject>>();
    //保存物品的父层级Transform
    private List<Transform> itemBgList = new List<Transform>();

    //当前显示的副列表
    private List<GameObject> viceCurrentList = new List<GameObject>();
    //当前显示的物品
    private List<GameObject> itemCurrentList = new List<GameObject>();

    //副列表Toggle中文名
    private string[] equipLabelNameArr = new string[] { "武 器", "头 盔", "项 链", "戒 指", "手 镯", "衣 服", "鞋 子", "翅 膀" };
    private string[] drugLabelNameArr = new string[] { "魔 法", "血 量", "加 成" };

    void Awake()
    {
        mainToggleGroup = transform.Find("StoreBg/MainGroup").GetComponent<ToggleGroup>();
        viceToggleGroup = transform.Find("StoreBg/ViceGroup").GetComponent<ToggleGroup>();
        mainToggleParent = transform.Find("StoreBg/MainGroup/ScrollView/Viewport/Content").gameObject;
        viceToggleParent = transform.Find("StoreBg/ViceGroup/ScrollView/Viewport/Content").gameObject;
        ItemBgParent = transform.Find("StoreBg/ItemScrollView/Viewport/Content");
        exit = transform.Find("StoreBg/Exit").GetComponent<Button>();

        AddAllViceAndItemObjToDic(); //加载所有副列表
        AddAllItemBg();
    }

    void Start ()
    {
        exit.onClick.AddListener(() => { UIManager.Instance.PopUIPanel();});
        //副列表及物体首次显隐
        ShowViceItem();
        //注册监听
        foreach (Transform temp in mainToggleParent.transform)//主列表每个Toggle注册监听事件
        {
            temp.GetComponent<Toggle>().onValueChanged.AddListener(MainToggleValueChanged);
        }

        foreach (Transform temp in viceToggleParent.transform)//副列表每个Toggle注册监听事件
        {
            temp.GetComponent<Toggle>().onValueChanged.AddListener(AssistantToggleValueanged);
        }
    }
	
	void Update ()
	{

	}

    public override void OnEntering()
    {
        gameObject.SetActive(true);
    }

    public override void OnPausing()
    {
        gameObject.SetActive(false);
    }

    public override void OnResuming()
    {
        
    }

    public override void OnExiting()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 点击退出按钮
    /// </summary>
    void OnExitBtnClick()
    {
        UIManager.Instance.PopUIPanel();
    }

    /// <summary>
    /// 添加物品父层级到list
    /// </summary>
    void AddAllItemBg()
    {
        foreach (Transform temp in ItemBgParent)
        {
            itemBgList.Add(temp);
        }
    }

    /// <summary>
    /// 副列表选项以及物品添加到字典
    /// </summary>
    void AddAllViceAndItemObjToDic()
    {
        //主列表保存副列表Item
        //装备Item
        string[] equipEnumList = Enum.GetNames(typeof(ViceEquipItemType));    //枚举转成数组
        for (int i = 0; i < equipEnumList.Length; i++) { 
            viceToggleList.Add(AddPreObjToDic(__arglist(MainItemType.Equip, equipEnumList[i], equipLabelNameArr[i],i)));
        }
        //药品Item
        string[] drugEnumList = Enum.GetNames(typeof(ViceDrugItemType));    //枚举转成数组
        for (int i = 0; i < drugEnumList.Length; i++)
        {
            viceToggleList.Add(AddPreObjToDic(__arglist(MainItemType.Drug, drugEnumList[i], drugLabelNameArr[i], i)));
        }

        //副列表保存物体Item
        //武器
        //临时数据
        string[] weaponArr = new[] { "女性武器1", "男性武器1", "男性武器1" , "男性武器1"};
        string[] helmArr = new string[] { "女性帽子1", "男性头盔1" };
        string[] necklaceArr = new string[] { "女性项链1", "男性项链1" };
        string[] ringArr = new string[] { "女性戒指1", "男性戒指1" };
        string[] braceletArr = new string[] { "女性手镯1" , "男性手镯1" };
        string[] clothArr = new string[] {"女性盔甲1","男性盔甲1"};
        string[] shoesArr = new string[] { "女性靴子1" , "男性靴子1" };
        string[] wingArr = new string[] {"女性翅膀1","男性翅膀1"};
        for (int i = 0; i < weaponArr.Length; i++)
        {
            itemList.Add(AddPreObjToDic(__arglist(ViceEquipItemType.Weapon,weaponArr[i])));
        }
        for (int i = 0; i < helmArr.Length; i++)
        {
            itemList.Add(AddPreObjToDic(__arglist(ViceEquipItemType.Helm, helmArr[i])));
        }
        for (int i = 0; i < necklaceArr.Length; i++)
        {
            itemList.Add(AddPreObjToDic(__arglist(ViceEquipItemType.Necklace, necklaceArr[i])));
        }
        for (int i = 0; i < ringArr.Length; i++)
        {
            itemList.Add(AddPreObjToDic(__arglist(ViceEquipItemType.Ring,ringArr[i])));
        }
        for (int i = 0; i < braceletArr.Length; i++)
        {
            itemList.Add(AddPreObjToDic(__arglist(ViceEquipItemType.Bracelet, braceletArr[i])));
        }
        for (int i = 0; i < clothArr.Length; i++)
        {
            itemList.Add(AddPreObjToDic(__arglist(ViceEquipItemType.Cloth, clothArr[i])));
        }
        for (int i = 0; i < shoesArr.Length; i++)
        {
            itemList.Add(AddPreObjToDic(__arglist(ViceEquipItemType.Shoes,shoesArr[i])));
        }
        for (int i = 0; i < wingArr.Length; i++)
        {
            itemList.Add(AddPreObjToDic(__arglist(ViceEquipItemType.Wing,wingArr[i])));
        }

    }

    /// <summary>
    /// 副列表&物品添加到字典再将该字典保存到list中,设置相关属性
    /// </summary>
    /// <param name="__arglist">可变参数</param>
    /// <param name="enumType">枚举名</param>
    /// <param name="originalItemName">item原来名字</param>
    /// <param name="currentViceItemName">item当前名字</param>
    /// <param name="chName">Toggle中文名字</param>
    /// <param name="index">Toggle在当前Group中的index</param>
    Dictionary<object, GameObject>  AddPreObjToDic(__arglist)
    {
        object enumType = null;
        string currentViceItemName = null, chName = null;
        int index = 0;
        string imageName = null;
        GameObject viceOrItem;
        ArgIterator args = new ArgIterator(__arglist);
        //print(args.GetRemainingCount());
        Dictionary<object, GameObject> toggleDicDetial = new Dictionary<object, GameObject>();
        if (4 == args.GetRemainingCount())
        {
            enumType = TypedReference.ToObject(args.GetNextArg());
            currentViceItemName = TypedReference.ToObject(args.GetNextArg()).ToString();
            chName = TypedReference.ToObject(args.GetNextArg()).ToString();
            index = int.Parse(TypedReference.ToObject(args.GetNextArg()).ToString());
            //print(enumType + " "+ currentViceItemName+" "+chName+ " "+ index);
            viceOrItem = UIManager.Instance.GetUIPrefabInstance(ConstDates.UIStoreViceItem, currentViceItemName);

            //副列表属性设置
            viceOrItem.transform.SetParent(viceToggleParent.transform);//设置父层级
            viceOrItem.transform.Find("Label").GetComponent<Text>().text = chName;
            Toggle tgTemp = viceOrItem.GetComponent<Toggle>();
            if (0 == index)   //将Group组中的第一个Toggle激活
                tgTemp.isOn = true;
            tgTemp.group = viceToggleGroup; //给每个Toggle设置ToggleGroup
        }
        else if (2 == args.GetRemainingCount())
        {
            enumType = TypedReference.ToObject(args.GetNextArg());
            imageName = TypedReference.ToObject(args.GetNextArg()).ToString();
            //print(enumType+" "+imageName);
            viceOrItem = UIManager.Instance.GetUIPrefabInstance(ConstDates.UIStoreItem);

            //物品属性等设置
            SetItemProperty(viceOrItem,imageName);
        }
        else 
        {
            throw new Exception("参数错误！");
        }
        toggleDicDetial.Add(enumType, viceOrItem);
        return toggleDicDetial;
    }

    /// <summary>
    /// 物品属性等设置
    /// </summary>
    /// <param name="item">物品</param>
    /// <param name="imageName">名字</param>
    void SetItemProperty(GameObject item,string imageName)
    {
        item.GetComponent<Image>().sprite = TextureManager.Instance.GetSprite(ConstDates.ResourceImagesDirTtj, imageName);
        item.transform.SetParent(ItemBgParent);
    }

    /// <summary>
    /// 显示当前副列表选项
    /// </summary>
    void ShowViceItem()
    {
        viceCurrentList.Clear();
        //print("1--" + mainToggleGroup.ActiveToggles().First());
        mainActiveToggle = mainToggleGroup.ActiveToggles().First();
        if (null != mainActiveToggle)//当前总列表有某项被激活
        {
            MainItemType enumType = (MainItemType) Enum.Parse(typeof(MainItemType), mainActiveToggle.name);  //获取总列表当前激活的那一项对应枚举
            for (int i = 0; i < viceToggleList.Count; i++)
            {
                //print(viceToggleList[i].Keys.First().GetType());
                if (viceToggleList[i].ContainsKey(enumType)) {    //将list中包含当前总列表激活项对应的副列表项保存，其它不显示
                    //viceToggleList[i].Values.First().SetActive(true);  //toggleListDetial[i][0].SetActive(true);   //这种写法错误[index][key]所以这里没有key=0的值
                    viceCurrentList.Add(viceToggleList[i].Values.First());
                }
                else
                    viceToggleList[i].Values.First().SetActive(false);
            }
          
            //副列表显示效果
            StartCoroutine(UIActiveShowStyle());

            //点击主列表也要刷新副列表
            ShowItemByMianItem();
        }
    }

    /// <summary>
    /// UI界面从隐藏到显示 间隔Time.deltaTime
    /// </summary>
    /// <param name="uiObj"></param>
    /// <returns></returns>
    public IEnumerator UIActiveShowStyle()
    {
        for (int i = 0; i < viceCurrentList.Count; i++)
        {
            viceCurrentList[i].SetActive(true);
            yield return new WaitForSeconds(Time.deltaTime*2);
        }
        //viceCurrentList.Clear();  放在这里清空list，有时候多点击其它选项，在点击另一个选项，会刷新不了，所以在ShowViceItem()开始的时候调用
    }

    /// <summary>
    /// UI界面重0-1 scale 变化
    /// </summary>
    /// <param name="uiObj"></param>
    /// <returns></returns>
    public IEnumerator UIScaleShowStyle()
    {
        float scaleChangeSpeed = 0.2f;

        for (int i = 0; i < itemCurrentList.Count; i++)
        {
            Transform uiObjTransform = itemCurrentList[i].transform;

            for (int j = 0; j < 5; j++)
            {
                if (Vector3.one == uiObjTransform.localScale)//房主
                {
                    break;
                }
                uiObjTransform.localScale += Vector3.one * scaleChangeSpeed;
                yield return null;
            }
        }
    }

    /// <summary>
    /// 依据主副列表某单项显隐物品
    /// </summary>
    void ShowItemByViceItem(object enumType)
    {
        print("ShowItemByViceItem");
        itemCurrentList.Clear();
        int index = 0;//物品背景标志位
        for (int i = 0; i < itemList.Count; i++)
        {
            GameObject item = itemList[i].Values.First(); 
            //print(itemList[i].Keys.First().enumType());
            if (itemList[i].ContainsKey(enumType)) //将list中包含当前副列表激活项对应物品显示，其它不显示
            {
                item.SetActive(true); //显示
                item.transform.SetParent(itemBgList[index++]);
                item.transform.localScale = Vector3.zero;
                item.transform.localPosition = Vector3.zero;

                itemCurrentList.Add(item);
            }
            else
            {
                item.SetActive(false);  //隐藏
                item.transform.SetParent(ItemBgParent);//设置父层级到content
            }
        }

        //物品显示效果
        //for (int i = 0; i < itemCurrentList.Count; i++)
        //{
            StartCoroutine(UIScaleShowStyle());
        //}
        
    }

    /// <summary>
    /// 依据主列带副列表选项显隐物品
    /// </summary>
    void ShowItemByMianItem()
    {
        //print("1--" + viceToggleGroup.ActiveToggles().First());
        if (0 != viceToggleGroup.ActiveToggles().Count())
        {
            viceActiveToggle = viceToggleGroup.ActiveToggles().First();
        }
        if (null != viceActiveToggle)//当前副列表有某项被激活
        {
            MainItemType mainEnumType = (MainItemType)Enum.Parse(typeof(MainItemType), mainActiveToggle.name,true);  //获取总列表当前激活的那一项对应枚举
            switch (mainEnumType)
            {
                case MainItemType.Equip:
                    ViceEquipItemType equipEnum = (ViceEquipItemType)Enum.Parse(typeof(ViceEquipItemType), viceActiveToggle.name, true);  //获取副列表当前激活的那一项对应枚举
                    ShowItemByViceItem(equipEnum);
                    break;
                case MainItemType.Drug:
                    ShowItemByViceItem("未实现");
                    break;
                default:
                    ShowItemByViceItem("未实现");
                    break;
            }
        }
    }

    /// <summary>
    /// 主列表监听事件
    /// </summary>
    void MainToggleValueChanged(bool isOn)
    {
        if (isOn)   //这里必须加ison判断，不然会会执行两次
            ShowViceItem();
    }

    /// <summary>
    /// 副列表监听事件
    /// </summary>
    void AssistantToggleValueanged(bool isOn)
    {
        
        if (isOn)   //这里必须加ison判断，不然会会执行两次
        {
            ShowItemByMianItem();
        }
            
    }
}
