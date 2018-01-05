using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskItemUI : MonoBehaviour
{
    private Image tasktypeImg;
    private Text nameTxt;
    private Text desTxt01;
    private Text desTxt02;
    private Text progressTxt;
    private Text haveCompleteTxt;
    private Text awardTxt;
    private Image reward01Img;
    private Text reward01Txt;
    private Image reward02Img;
    private Text reward02Txt;
    private Button combatBtn;
    private Button rewardBtn;
    private Task task;
    private void Awake()
    {
        tasktypeImg = transform.Find("MainImg").GetComponent<Image>();
        nameTxt = transform.Find("LableTxt").GetComponent<Text>();
        desTxt01 = transform.Find("DesTxt01").GetComponent<Text>();
        desTxt02 = transform.Find("DesTxt02").GetComponent<Text>();
        progressTxt = transform.Find("ProgressTxt").GetComponent<Text>();
        haveCompleteTxt = transform.Find("HaveCompleteTxt").GetComponent<Text>();
        awardTxt = transform.Find("AwardTxt").GetComponent<Text>();
        reward01Img = transform.Find("Reward01Img").GetComponent<Image>();
        reward01Txt = transform.Find("Reward01Txt").GetComponent<Text>();
        reward02Img = transform.Find("Reward02Img").GetComponent<Image>();
        reward02Txt = transform.Find("Reward02Txt").GetComponent<Text>();
        combatBtn = transform.Find("CombatBtn").GetComponent<Button>();
        rewardBtn = transform.Find("RewardBtn").GetComponent<Button>();
    }
    public void SetTask(Task task)
    {
        this.task = task;
        switch (task.TaskType)
        {
            case TaskType.Main:
                tasktypeImg.name = "pic_主线";
                break;
            case TaskType.Reward:
                tasktypeImg.name = "pic_奖赏";
                break;
        }
        nameTxt.text = task.Name;
        desTxt01.text = task.Des;
        desTxt02.text = task.Des;
        if (task.Coin > 0 && task.Dainmond > 0)
        {
            reward01Img.name = "金币";
            reward01Txt.text = "X" + task.Coin;
            reward02Img.name = "钻石";
            reward02Txt.text = "X" + task.Dainmond;
        }
        else if (task.Coin > 0)
        {
            reward01Img.name = "金币";
            reward01Txt.text = "X" + task.Coin;
            reward02Img.gameObject.SetActive(false);
            reward02Txt.gameObject.SetActive(false);
        }
        else if (task.Dainmond > 0)
        {
            reward02Img.name = "钻石";
            reward02Txt.text = "X" + task.Dainmond;
            reward01Img.gameObject.SetActive(false);
            reward01Txt.gameObject.SetActive(false);
        }
        switch (task.TaskProgress)
        {
            case TaskProgress.NoStart:
                rewardBtn.gameObject.SetActive(false);
                combatBtn.name = "下一步";
                break;
            case TaskProgress.Accept:
                rewardBtn.gameObject.SetActive(false);
                combatBtn.name = "战斗";
                break;
            case TaskProgress.Complete:
                combatBtn.gameObject.SetActive(false);
                break;
        }

    }
}
