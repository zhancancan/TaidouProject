using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain:UIBase{
    private Button petBtn;              //宠物
    private Button forgeBtn;            //锻造
    private Button composeBtn;          //宝石合成
    private Button friendBtn;           //好友
    private Button playerPropertyBtn;   //玩家属性
    private Button taskBtn;             //任务
    private Button skillBtn;            //技能
    private Button battleBtn;           //战斗
    private Button storeBtn;            //商城
    private Button bagBtn;              //背包
    private Button settingBtn;          //系统设定

    void Awake()
    {
        petBtn = transform.Find("FunctionBar/FbBg/PetBtn").GetComponent<Button>();
        forgeBtn = transform.Find("FunctionBar/FbBg/ForgeBtn").GetComponent<Button>();
        composeBtn = transform.Find("FunctionBar/FbBg/ComposeBtn").GetComponent<Button>();
        friendBtn = transform.Find("FunctionBar/FbBg/FriendBtn").GetComponent<Button>();
        playerPropertyBtn = transform.Find("FunctionBar/FbBg/PlayerPropertyBtn").GetComponent<Button>();
        taskBtn = transform.Find("FunctionBar/FbBg/TaskBtn").GetComponent<Button>();
        skillBtn = transform.Find("FunctionBar/FbBg/SkillBtn").GetComponent<Button>();
        battleBtn = transform.Find("FunctionBar/FbBg/BattleBtn").GetComponent<Button>();
        storeBtn = transform.Find("FunctionBar/FbBg/StoreBtn").GetComponent<Button>();
        bagBtn = transform.Find("FunctionBar/FbBg/BagBtn").GetComponent<Button>();
        settingBtn = transform.Find("FunctionBar/FbBg/SettingBtn").GetComponent<Button>();
    }

    void Start()
    {
        petBtn.onClick.AddListener(OnPetBtnClick);
        playerPropertyBtn.onClick.AddListener(OnPlayerPropertyBtnClick);
        bagBtn.onClick.AddListener(OnBagBtnClick);
    }

    public override void OnEntering()
    {
        gameObject.SetActive(true);
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
    /// 点击宠物按钮
    /// </summary>
    void OnPetBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIPet);
    }

    /// <summary>
    /// 点击人物属性按钮
    /// </summary>
    void OnPlayerPropertyBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIPlayerProperty);
    }

    /// <summary>
    /// 点击背包按钮
    /// </summary>
    void OnBagBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIBag);
    }
}
