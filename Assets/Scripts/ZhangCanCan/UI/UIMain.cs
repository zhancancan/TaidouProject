using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class UIMain:UIBase{
    //UIFunctionBar
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

    private Button rechargeBtn;         //充值
    private Button prizeBtn;            //奖励
    private Button signBtn;             //签到

    //UIHead
    private Text levelTxt;              //等级
    private Text powerTxt;              //体力
    private Text temperTxt;             //历练
    private Image powerImg;
    private Image temperImg;
    private Button powerBtn;
    private Button temperBtn;

    //UIRich
    private Text diamonTxt;             //宝石
    private Text coinTxt;               //金币
    private Button diamonBtn;
    private Button coinBtn;

    void Awake()
    {
        //UIFunctionBar
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

        rechargeBtn = transform.Find("RechargeSignPrize/RechargeBtn").GetComponent<Button>();
        prizeBtn = transform.Find("RechargeSignPrize/PrizeBtn").GetComponent<Button>();
        signBtn = transform.Find("RechargeSignPrize/SignBtn").GetComponent<Button>();
        //UIHead
        levelTxt = transform.Find("HeadBg/Level").GetComponent<Text>();
        powerTxt = transform.Find("HeadBg/PowerCount").GetComponent<Text>();
        temperTxt = transform.Find("HeadBg/TemperCount").GetComponent<Text>();
        powerImg = transform.Find("HeadBg/PowerImg").GetComponent<Image>();
        temperImg = transform.Find("HeadBg/TemperImg").GetComponent<Image>();
        powerBtn = transform.Find("HeadBg/PowerAddBtn").GetComponent<Button>();
        temperBtn = transform.Find("HeadBg/TemperAddBtn").GetComponent<Button>();
        //UIRich
        diamonTxt = transform.Find("Rich/DiamonCount").GetComponent<Text>();
        coinTxt = transform.Find("Rich/CoinCount").GetComponent<Text>();
        diamonBtn = transform.Find("Rich/DiamonAddBtn").GetComponent<Button>();
        coinBtn = transform.Find("Rich/CoinAddBtn").GetComponent<Button>();

        //第一次进场景，加载所有UI界面
        UIManager.Instance.PushUIPanel(ConstDates.UIPet);
        UIManager.Instance.PushUIPanel(ConstDates.UIGemstoneCompose);
        UIManager.Instance.PushUIPanel(ConstDates.UIPlayerProperty);
        UIManager.Instance.PushUIPanel(ConstDates.UITask);
        UIManager.Instance.PushUIPanel(ConstDates.UISkill);
        UIManager.Instance.PushUIPanel(ConstDates.UIStore);
        UIManager.Instance.PushUIPanel(ConstDates.UISystemSetting);
        UIManager.Instance.PushUIPanel(ConstDates.UIRecharge);
        UIManager.Instance.PushUIPanel(ConstDates.UISignIn);
        UIManager.Instance.PushUIPanel(ConstDates.UIBag);

        PlayInfo._instance.OnPlayInfoChanged += this.OnPlayInfoChanged;
    }

    private void OnDestroy()
    {
        PlayInfo._instance.OnPlayInfoChanged -= this.OnPlayInfoChanged;
    }

    void Start()
    {
        petBtn.onClick.AddListener(OnPetBtnClick);
        composeBtn.onClick.AddListener(OnComposeBtnClick);
        playerPropertyBtn.onClick.AddListener(OnPlayerPropertyBtnClick);
        taskBtn.onClick.AddListener(OnTaskBtnBtnClick);
        skillBtn.onClick.AddListener(OnSkillBtnBtnClick);
        storeBtn.onClick.AddListener(OnStoreBtnClick);
        bagBtn.onClick.AddListener(OnBagBtnClick);
        settingBtn.onClick.AddListener(OnSettingBtnClick);

        rechargeBtn.onClick.AddListener(OnRechargeBtnClick);
        prizeBtn.onClick.AddListener(OnPrizeBtnClick);
        signBtn.onClick.AddListener(OnSignBtnClick);
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

    #region click
    /// <summary>
    /// 点击宠物按钮
    /// </summary>
    void OnPetBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIPet);
    }

    /// <summary>
    /// 点击宝石合成按钮
    /// </summary>
    void OnComposeBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIGemstoneCompose);
    }

    /// <summary>
    /// 点击人物属性按钮
    /// </summary>
    void OnPlayerPropertyBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIPlayerProperty);
    }

    /// <summary>
    /// 点击任务按钮
    /// </summary>
    void OnTaskBtnBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UITask);
    }

    /// <summary>
    /// 点击技能按钮
    /// </summary>
    void OnSkillBtnBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UISkill);
    }

    /// <summary>
    /// 点击背包按钮
    /// </summary>
    void OnBagBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIPet);
        UIManager.Instance.PushUIPanel(ConstDates.UIBag);
    }

    /// <summary>
    /// 点击系统设定按钮
    /// </summary>
    void OnSettingBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UISystemSetting);
    }

    /// <summary>
    /// 点击商城按钮
    /// </summary>
    void OnStoreBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIStore);
    }

    /// <summary>
    /// 点击充值按钮
    /// </summary>
    void OnRechargeBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIRecharge);
    }

    /// <summary>
    /// 点击奖励按钮
    /// </summary>
    void OnPrizeBtnClick()
    {
        //UIManager.Instance.PushUIPanel(ConstDates.UIPrize);
    }

    /// <summary>
    /// 点击签到按钮
    /// </summary>
    void OnSignBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UISignIn);
    }
    #endregion

    void OnPlayInfoChanged(InfoType type)
    {
        if(type == InfoType.All || type == InfoType.Name || type == InfoType.HeadPortait || type == InfoType.Level || type == InfoType.Energy || type == InfoType.Toughen || type == InfoType.Coin || type == InfoType.Diamond)
        {
            UpdateShow();
        }
    }

    private void UpdateShow()
    {
        PlayInfo info = PlayInfo._instance;
        levelTxt.text = info.Level.ToString();
        powerTxt.text = info.Power.ToString();
        temperTxt.text = info.Toughen.ToString();
        diamonTxt.text = info.Diamond.ToString();
        coinTxt.text = info.Coin.ToString();
    }
}
