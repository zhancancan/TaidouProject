using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPlayerProperty : UIBase
{
    private Button exitBtn;
    private Button renameBtn;
    private Image expImg;
    private Text levelTxt;
    private Text vipTxt;
    private Text battleTxt;
    private Text hpTxt;
    private Text attackTxt;
    private Text defeatTxt;
    private Text critTxt;
    private Text powerSumTxt;
    private Text powerRemainTxt;
    private Text temperSumTxt;
    private Text temperRemainTxt;
    private Text powerRecoverTimeTxt;
    private Text temperRecoverTimeTxt;

    private GameObject uiRename;

    void Awake()
    {
        exitBtn = transform.Find("PlayerPropertyBg/Exit").GetComponent<Button>();
        renameBtn = transform.Find("PlayerPropertyBg/Rename").GetComponent<Button>();

        expImg = transform.Find("PlayerPropertyBg/ExpImg").GetComponent<Image>();

        levelTxt = transform.Find("PlayerPropertyBg/Level").GetComponent<Text>();
        vipTxt = transform.Find("PlayerPropertyBg/VipLevel").GetComponent<Text>();
        battleTxt = transform.Find("PlayerPropertyBg/BattleCount").GetComponent<Text>();
        hpTxt = transform.Find("PlayerPropertyBg/HpCount").GetComponent<Text>();
        attackTxt = transform.Find("PlayerPropertyBg/AttackCount").GetComponent<Text>();
        defeatTxt = transform.Find("PlayerPropertyBg/DefeatCount").GetComponent<Text>();
        critTxt = transform.Find("PlayerPropertyBg/CritCount").GetComponent<Text>();
        powerSumTxt = transform.Find("PlayerPropertyBg/PowerSum").GetComponent<Text>();
        powerRemainTxt = transform.Find("PlayerPropertyBg/PowerRemain").GetComponent<Text>();
        temperSumTxt = transform.Find("PlayerPropertyBg/TemperSum").GetComponent<Text>();
        temperRemainTxt = transform.Find("PlayerPropertyBg/TemperRemain").GetComponent<Text>();
        powerRecoverTimeTxt = transform.Find("PlayerPropertyBg/PowerRecoverTime").GetComponent<Text>();
        temperRecoverTimeTxt = transform.Find("PlayerPropertyBg/TemperRecoverTime").GetComponent<Text>();

        uiRename = transform.Find("UIRename").gameObject;
    }

    void Start()
    {
        exitBtn.onClick.AddListener(OnExitBtnClick);
        renameBtn.onClick.AddListener(OnRenameBtnClick);
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
    /// 退出button点击
    /// </summary>
    void OnExitBtnClick()
    {
        if (uiRename.activeSelf)
        {
            uiRename.SetActive(false);
        }
        UIManager.Instance.PopUIPanel();
    }

    void OnRenameBtnClick()
    {
        if (!uiRename.activeSelf)
        {
            uiRename.SetActive(true);
        }
    }
}
