using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FunctionBar : MonoBehaviour {
    //UIFunctionBar
    private Button showBottomFunctionBarBtn;  //显示下面功能按钮条的按钮

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

    private bool isBottomFubctionBarShow = true;

    void Awake()
    {
        Init();
    }

    void Start ()
    {
        RigisterListener();
    }

    //初始化
    void Init()
    {
        //UIFunctionBar
        showBottomFunctionBarBtn = transform.parent.Find("ShowFunctionBarBtnBg/ShowFunctionBarBtn").GetComponent<Button>();

        petBtn = transform.Find("FbBg/PetBtn").GetComponent<Button>();
        forgeBtn = transform.Find("FbBg/ForgeBtn").GetComponent<Button>();
        composeBtn = transform.Find("FbBg/ComposeBtn").GetComponent<Button>();
        friendBtn = transform.Find("FbBg/FriendBtn").GetComponent<Button>();
        playerPropertyBtn = transform.Find("FbBg/PlayerPropertyBtn").GetComponent<Button>();
        taskBtn = transform.Find("FbBg/TaskBtn").GetComponent<Button>();
        skillBtn = transform.Find("FbBg/SkillBtn").GetComponent<Button>();
        battleBtn = transform.Find("FbBg/BattleBtn").GetComponent<Button>();
        storeBtn = transform.Find("FbBg/StoreBtn").GetComponent<Button>();
        bagBtn = transform.Find("FbBg/BagBtn").GetComponent<Button>();
        settingBtn = transform.Find("FbBg/SettingBtn").GetComponent<Button>();

        rechargeBtn = transform.parent.Find("RechargeSignPrize/RechargeBtn").GetComponent<Button>();
        prizeBtn = transform.parent.Find("RechargeSignPrize/PrizeBtn").GetComponent<Button>();
        signBtn = transform.parent.Find("RechargeSignPrize/SignBtn").GetComponent<Button>();
    }

    //注册button事件
    void RigisterListener()
    {
        showBottomFunctionBarBtn.onClick.AddListener(OnBottomFunctionbarShowBtnClick);

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

    void Update ()
    {
        
    }

    #region OnClick
    //点击显示下面功能条按钮
    void OnBottomFunctionbarShowBtnClick()
    {
            DoTweenEffectManager.MoveComponet(transform.gameObject, showBottomFunctionBarBtn, DoTweenMoveDirection.Down,0.5f);
    }

    // 点击宠物按钮
    void OnPetBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIPet);
    }

    // 点击宝石合成按钮
    void OnComposeBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIGemstoneCompose);
    }

    // 点击人物属性按钮
    void OnPlayerPropertyBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIPlayerProperty);
    }

    // 点击任务按钮
    void OnTaskBtnBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UITask);
    }

    // 点击技能按钮
    void OnSkillBtnBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UISkill);
    }

    // 点击背包按钮
    void OnBagBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIPet);
        UIManager.Instance.PushUIPanel(ConstDates.UIBag);
    }

    // 点击系统设定按钮
    void OnSettingBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UISystemSetting);
    }

    // 点击商城按钮
    void OnStoreBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIStore);
    }

    /// 点击充值按钮
    void OnRechargeBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIRecharge);
    }

    // 点击奖励按钮
    void OnPrizeBtnClick()
    {
        //UIManager.Instance.PushUIPanel(ConstDates.UIPrize);
    }

    // 点击签到按钮
    void OnSignBtnClick()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UISignIn);
    }
    #endregion

    
}
