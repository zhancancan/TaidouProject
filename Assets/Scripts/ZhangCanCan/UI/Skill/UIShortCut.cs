using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIShortCut : MonoBehaviour
{
    private GameObject player;
    private PlayerStatus playerStatus;
    private PlayerAttack playerAttack;
    private Transform shuCutGroup1;
    private Transform shuCutGroup2;

    private List<ShortCutItem> shuCutItemList = new List<ShortCutItem>();//存储每个快捷键的Item
    private Dictionary<KeyCode, ShortCutItem> shutCutDict = new Dictionary<KeyCode, ShortCutItem>();  //保存快捷键对应的按键，快捷键的Item

    void Awake()
    {
        shuCutGroup1 = transform.Find("ShutCutGroup1").transform;
        shuCutGroup2 = transform.Find("ShutCutGroup2").transform;
        foreach (Transform temp in shuCutGroup1)
        {
            shuCutItemList.Add(temp.GetComponent<ShortCutItem>());
        }
        foreach (Transform temp in shuCutGroup2)
        {
            shuCutItemList.Add(temp.GetComponent<ShortCutItem>());
        }

        shutCutDict.Add(KeyCode.Alpha1, shuCutItemList[0]);
        shutCutDict.Add(KeyCode.Alpha2, shuCutItemList[1]);
        shutCutDict.Add(KeyCode.Alpha3, shuCutItemList[2]);
        shutCutDict.Add(KeyCode.Alpha4, shuCutItemList[3]);
        shutCutDict.Add(KeyCode.Alpha5, shuCutItemList[4]);
        shutCutDict.Add(KeyCode.Alpha6, shuCutItemList[5]);
        shutCutDict.Add(KeyCode.Alpha7, shuCutItemList[6]);
        shutCutDict.Add(KeyCode.Alpha8, shuCutItemList[7]);
        shutCutDict.Add(KeyCode.Alpha9, shuCutItemList[8]);
        shutCutDict.Add(KeyCode.Alpha0, shuCutItemList[9]);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
        playerStatus = player.GetComponent<PlayerStatus>();
        playerAttack = player.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        ShutCutClick();
    }

    //技能快捷键点击
    void ShutCutClick()
    {
        if (playerAttack.state == PlayerState.Death) return;
        foreach (var key in shutCutDict.Keys)//遍历 0-9 按键是否按下
        {
            ShortCutItem shuCutItem;
            shutCutDict.TryGetValue(key, out shuCutItem);
            if (Input.GetKeyDown(key))//按键按下
            {
                UseShutCutSkill(shuCutItem);
            }
        }
    }

    //使用快捷键技能
    void UseShutCutSkill(ShortCutItem shutCutItem)
    {
        if (shutCutItem.shutCutType == ShutCutType.Skill)
        {
            Skill skill = SkillInfoData.GetInstance().GetSkillInfoById(shutCutItem.shutCutGoodsId);
            playerAttack.UseSkill(skill);
        }
        else if (shutCutItem.shutCutType == ShutCutType.Drug)
        {
            //ObjectsInfoClass info = ObjectsInfo._instance.GetObjectsInfoById(id);
            //if ((info.hp != 0 && playerStatus.hp == 100) || (info.mp != 0 && playerStatus.mp == 100)) return; //玩家满血或者满篮
            //playerStatus.AddHpMp(info.hp, info.mp);
            //BagItemCtr bagItem = null;
            //foreach (BagItemCtr temp in BagBarCtr._instance.bagItemList)
            //{
            //    if (temp.id == id)
            //    {
            //        bagItem = temp;
            //        break;
            //    }
            //}
            //bagItem.plusNum(-1);
            //if (bagItem.num == 0)
            //{
            //   Destroy(bagItem.GetComponentInChildren<GoodsItemCtr>().gameObject);
            //   bagItem.ClearInfo();
            //   this.transform.Find("ShutCutIcon").GetComponent<UISprite>().enabled = false;
            //}
        }
    }
}
