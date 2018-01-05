using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskItemUI : MonoBehaviour
{
    private Image mainImg;
    private Image rewardImg;
    private Image dailyImg;
    private Text nameTxt;
    private Text desTxt;
    private Image reward01Img;
    private Text reward01Txt;
    private Image reward02Img;
    private Text reward02Txt;
    private Button combatBtn;
    private Button rewardBtn;
    private Text combatTxt;
    private Task task;
    private void Awake()
    {
        mainImg = transform.Find("MainImg").GetComponent<Image>();
        rewardImg = transform.Find("RewardImg").GetComponent<Image>();
        dailyImg = transform.Find("DailyImg").GetComponent<Image>();
        nameTxt = transform.Find("Content/LableTxt").GetComponent<Text>();
        desTxt = transform.Find("Content/DesTxt01").GetComponent<Text>();
        reward01Img = transform.Find("Content/Reward01Img").GetComponent<Image>();
        reward01Txt = transform.Find("Content/Reward01Txt").GetComponent<Text>();
        reward02Img = transform.Find("Content/Reward02Img").GetComponent<Image>();
        reward02Txt = transform.Find("Content/Reward02Txt").GetComponent<Text>();
        combatBtn = transform.Find("FightBtn").GetComponent<Button>();
        rewardBtn = transform.Find("RewardBtn").GetComponent<Button>();
        combatTxt = transform.Find("FightBtn/FightTxt").GetComponent<Text>();
    }
    public void SetTask(Task task)
    {
        this.task = task;
        switch (task.TaskType)
        {
            case TaskType.Main:
                rewardImg.gameObject.SetActive(false);
                dailyImg.gameObject.SetActive(false);
                break;
            case TaskType.Reward:
                mainImg.gameObject.SetActive(false);
                dailyImg.gameObject.SetActive(false);
                break;
            case TaskType.Daily:
                rewardImg.gameObject.SetActive(false);
                mainImg.gameObject.SetActive(false);
                break;
        }
        nameTxt.text = task.Name;
        desTxt.text = task.Des;
        
        if (task.Coin > 0 && task.Dainmond > 0)
        {
            
            reward01Txt.text = "X" + task.Coin;
            
            reward02Txt.text = "X" + task.Dainmond;
        }
        else if (task.Coin > 0)
        {
            
            reward01Txt.text = "X" + task.Coin;
            reward02Img.gameObject.SetActive(false);
            reward02Txt.gameObject.SetActive(false);
        }
        else if (task.Dainmond > 0)
        {
            
            reward02Txt.text = "X" + task.Dainmond;
            reward01Img.gameObject.SetActive(false);
            reward01Txt.gameObject.SetActive(false);
        }
        switch (task.TaskProgress)
        {
            case TaskProgress.NoStart:
                rewardBtn.gameObject.SetActive(false);
                combatTxt.text = "下一步";
                break;
            case TaskProgress.Accept:
                rewardBtn.gameObject.SetActive(false);
                combatTxt.text = "战斗";
                break;
            case TaskProgress.Complete:
                combatBtn.gameObject.SetActive(false);
                break;
        }

    }
}
