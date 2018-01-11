using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRecharge : UIBase
{
    private Button exit;
    private Button diamonRechargeBtn;
    private Button coinRechargeBtn;

    private GameObject diamonRechargePanel;
    private GameObject coinRechargePanel;

    void Awake()
    {
        exit = transform.Find("RechargeBg/Exit").GetComponent<Button>();
        diamonRechargeBtn = transform.Find("RechargeBg/DiamonRecharge").GetComponent<Button>();
        coinRechargeBtn = transform.Find("RechargeBg/CoinRecharge").GetComponent<Button>();

        diamonRechargePanel = transform.Find("RechargeBg/DiamonRechargePanel").gameObject;
        coinRechargePanel = transform.Find("RechargeBg/CoinRechargePanel").gameObject;
    }

	void Start () {
	    exit.onClick.AddListener(() => { UIManager.Instance.PopUIPanel();});
        diamonRechargeBtn.onClick.AddListener(OnDiamonRechargeBtnClick);
	    coinRechargeBtn.onClick.AddListener(OnCoinRechargeBtnClick);
    }
	
	void Update () {
		
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

    void OnDiamonRechargeBtnClick()
    {
        if (!diamonRechargePanel.gameObject.activeSelf)
        {
            diamonRechargePanel.SetActive(true);
            coinRechargePanel.SetActive(false);
        }
    }

    void OnCoinRechargeBtnClick()
    {
        if (!coinRechargePanel.gameObject.activeSelf)
        {
            coinRechargePanel.SetActive(true);
            diamonRechargePanel.SetActive(false);
        }
    }
}
