using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FunctionBar : MonoBehaviour {
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

    private Button showFcBtn;  //显示功能按钮条的按钮
    private GameObject uiShortCut;
    private Transform functionBg;

    private List<Transform> functionBtnList = new List<Transform>();
    private bool isBottomFubctionBarShow = true;

    Transform showFcBtnParent;
    RectTransform rec1;//显示功能条按钮的父层级Rect
    float w1; //控件宽度
    float h1; //控件高度

    RectTransform rec2;//功能条按钮的Rect
    float w2; //控件宽度
    float h2; //控件高度

    private Action hideShortCut1;
    private Action showShortCut1;

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

        showFcBtn = transform.parent.Find("ShowFunctionBarBtnBg/ShowFunctionBarBtn").GetComponent<Button>();
        functionBg = transform.Find("FbBg").transform;
        uiShortCut = transform.parent.Find("UIShortCut").gameObject;
        
        foreach (Transform temp in functionBg)
        {
            functionBtnList.Add(temp);
        }

        hideShortCut1 = HideShortCut1;
        showShortCut1 = ShowShortCut1;

        showFcBtnParent = showFcBtn.transform.parent;
        rec1 = showFcBtnParent.GetComponent<RectTransform>();//显示功能条按钮的父层级Rect
        w1 = rec1.rect.width; //控件宽度
        h1 = rec1.rect.height; //控件高度

        rec2 = GetComponent<RectTransform>();//功能条按钮的Rect
        w2 = rec2.rect.width; //控件宽度
        h2 = rec2.rect.height; //控件高度

        InitFunctionBarPos();
    }

    //注册button事件
    void RigisterListener()
    {
        showFcBtn.onClick.AddListener(OnBottomFunctionbarShowBtnClick);

        petBtn.onClick.AddListener(OnPetBtnClick);
        composeBtn.onClick.AddListener(OnComposeBtnClick);
        playerPropertyBtn.onClick.AddListener(OnPlayerPropertyBtnClick);
        taskBtn.onClick.AddListener(OnTaskBtnBtnClick);
        skillBtn.onClick.AddListener(OnSkillBtnBtnClick);
        storeBtn.onClick.AddListener(OnStoreBtnClick);
        bagBtn.onClick.AddListener(OnBagBtnClick);
        settingBtn.onClick.AddListener(OnSettingBtnClick);

        rechargeBtn.onClick.AddListener(OnRechargeBtnClick);
        prizeBtn.onClick.AddListener(PrizeClick);
        signBtn.onClick.AddListener(OnSignBtnClick);
    }

    #region OnClick
    //点击显示下面功能条按钮
    void OnBottomFunctionbarShowBtnClick()
    {
        if (isRight)//从右边出来
        {
            DoTweenEffectManager.MoveFronInScreen(gameObject, showFcBtn, DoTweenMoveDirection.Right,0.5f,true);
        }
        else
        {
            DoTweenEffectManager.MoveFronInScreen(gameObject, showFcBtn, DoTweenMoveDirection.Down, 0.5f);
        }
    }

    private bool isRight = true;

    #endregion

    #region OnClick
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

    private bool isShow = true;
    void PrizeClick()
    {
        DoTweenEffectManager.MoveFronInScreen(uiShortCut, prizeBtn, DoTweenMoveDirection.Down, 0.5f, false,hideShortCut1, showShortCut1);
    }

    private void HideShortCut1()
    {
        isShow = false;
        if (isRight)
        {
            isRight = false;
            DoTweenEffectManager.ClearInfo(gameObject);
            UpdateFunctionBarPos();
            DoTweenEffectManager.ClearInfo(gameObject);
        }
    }

    private void ShowShortCut1()
    {
        isShow = true;
        if (!isRight)
        {
            isRight = true;
            DoTweenEffectManager.ClearInfo(gameObject);
            UpdateFunctionBarPos();
            DoTweenEffectManager.ClearInfo(gameObject);
        }
    }

    void InitFunctionBarPos()
    {
        if (isRight)//如果快捷键显示，将功能条Z旋转-90，计算功能条位置的时候宽和高需要调换
        {
            float fcY = showFcBtnParent.localPosition.y+ h1 / 2 + w2/2;//功能条Y坐标
            float fcX = Screen.width/2 - h2 / 2;//功能条X坐标

            transform.localRotation = Quaternion.Euler(0,0,-90);
            foreach (Transform fcBtn  in functionBtnList)
            {
                fcBtn.localRotation = Quaternion.Euler(new Vector3(0,0,90));
            }
            transform.localPosition = new Vector3(fcX,fcY,transform.localPosition.z);
        }
        else
        {
            float fcX = showFcBtnParent.localPosition.x - w1 / 2 - w2 / 2;//功能条Y坐标
            float fcY = -Screen.height / 2 + h2 / 2;//功能条X坐标

            transform.localRotation = Quaternion.Euler(0, 0, 0);
            foreach (Transform fcBtn in functionBtnList)
            {
                fcBtn.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            transform.localPosition = new Vector3(fcX, fcY, transform.localPosition.z);
        }
    }

    void UpdateFunctionBarPos()
    {
        if (isRight)//如果快捷键显示，将功能条Z旋转-90，计算功能条位置的时候宽和高需要调换
        {
            float fcY = showFcBtnParent.localPosition.y + h1 / 2 + w2 / 2;//功能条Y坐标
            float fcX = Screen.width / 2 +h2 / 2;//功能条X坐标

            transform.localRotation = Quaternion.Euler(0, 0, -90);
            foreach (Transform fcBtn in functionBtnList)
            {
                fcBtn.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
            }
            transform.localPosition = new Vector3(fcX, fcY, transform.localPosition.z);

            Vector2 v = new Vector2(Screen.width / 2 - h2 / 2, showFcBtnParent.localPosition.y + h1 / 2 + w2 / 2);
            DoTweenEffectManager.MoveFromOutScreen(gameObject,showFcBtn,DoTweenMoveDirection.Left,v,0.5f,true);
        }
        else
        {
            float fcX = showFcBtnParent.localPosition.x - w1 / 2 - w2 / 2;//功能条Y坐标
            float fcY = -Screen.height / 2 - h2 / 2;//功能条X坐标

            transform.localRotation = Quaternion.Euler(0, 0, 0);
            foreach (Transform fcBtn in functionBtnList)
            {
                fcBtn.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            transform.localPosition = new Vector3(fcX, fcY, transform.localPosition.z);

            Vector2 v = new Vector2(showFcBtnParent.localPosition.x - w1 / 2 - w2 / 2, -Screen.height / 2 + h2 / 2);
            DoTweenEffectManager.MoveFromOutScreen(gameObject, showFcBtn, DoTweenMoveDirection.Down, v, 0.5f);
        }
    }
}
