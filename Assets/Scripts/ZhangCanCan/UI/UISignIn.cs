using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISignIn : UIBase
{
    private Button exit;
    private Text dateNow;
    private GameObject dateParent;

    private List<Button> dateBtList = new List<Button>();
    private List<Image> checkImgList = new List<Image>();

    private DateTime dt = DateTime.Now;
    private int yearNow;
    private int monthNow;
    private int dayNow;
    private int daysInMonth;    //当前年月对应的天数
    private int firstDayOfMonthInWeek;  //当前年月第一天是星期几

    void Awake()
    {
        exit = transform.Find("SignInBg/Exit").GetComponent<Button>();
        dateNow = transform.Find("SignInBg/DeatilTimeBg/DeatilTime").GetComponent<Text>();
        dateParent = transform.Find("SignInBg/DayOfDonthBg").gameObject;

        foreach (Transform day in dateParent.transform)
        {
            dateBtList.Add(day.GetComponent<Button>());
            checkImgList.Add(day.Find("Checkmark").GetComponent<Image>());
        }

        yearNow = dt.Year;
        monthNow = dt.Month;
        dayNow = dt.Day;
        dateNow.text = string.Format("{0} 年 {1} 月", yearNow, monthNow);

        daysInMonth = DateTime.DaysInMonth(yearNow, monthNow);  
        firstDayOfMonthInWeek = (int)dt.AddDays(-dayNow+1).DayOfWeek;

        for (int i = 0; i < dateBtList.Count; i++)
        {
            //屏蔽当前月第一天前面的按钮交互
            if (i < firstDayOfMonthInWeek)
            {
                dateBtList[i].interactable = false;
            }
            else
            {
                if (7 == firstDayOfMonthInWeek) //这个月的第一天是周日
                {
                    if (i >= daysInMonth)   //大于这个月的总天数
                    {
                        dateBtList[i].interactable = false;
                    }
                    //将当天对应的按钮设置监听
                    EventTriggerListener.GetListener(dateBtList[dayNow-1].gameObject).onPointerClick += OnSignInBtnClick;
                }
                else
                {
                    if (i >= firstDayOfMonthInWeek + daysInMonth)   //大于这个月的总天数+这个月的第一天是周几
                    {
                        dateBtList[i].interactable = false;
                    }
                    EventTriggerListener.GetListener(dateBtList[dayNow+ firstDayOfMonthInWeek-1].gameObject).onPointerClick += OnSignInBtnClick;
                }
            }
        }

        //dateNow.text = dt.GetDateTimeFormats('y')[0];
        //解析年月数据 得到日期
        //        if (null != 解析年月数据) //之前存储过
        //        {
        //            if (dateNow.text == 解析年月数据) //还是当前月
        //            {
        //                //解析 之前签到的数据
        //                //界面刷新
        //            }
        //            else //当前月已经变更
        //            {
        //                //刷新界面
        //                //存储数据
        //            }
        //        }
        //        else //第一次游戏
        //        {
        //            //获取当前年月
        //            //显示界面
        //            //存储数据
        //        }

    }

	void Start () {
		exit.onClick.AddListener(()=>{UIManager.Instance.PopUIPanel();});
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

    //点击签到按钮
    void OnSignInBtnClick(GameObject obj, PointerEventData data)
    {
        Button bt = obj.GetComponent<Button>();
        int index = dateBtList.IndexOf(bt);
        if (!checkImgList[index].enabled)
        {
            checkImgList[index].enabled = true;
        }
        else
        {
            return;
        }
    }

}
