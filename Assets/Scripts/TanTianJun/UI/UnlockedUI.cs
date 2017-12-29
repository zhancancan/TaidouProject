using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

public class UnlockedUI : MonoBehaviour{
    GameObject unlockUI ;
    Button truebtn, falsebtn, closebtn;
    public  Button unlocked;
    bool isclick = true;
    Text costcointxt;
    Image image;
    Image Image
    {
        get
        {
            if (image == null)
            {
                image = transform.Find("item").GetComponent<Image>();
            }
            return image;
        }
    }
    InventoryItemUI it;
   public  int count = 0;
    private void Awake()
    {
        unlockUI = transform.parent.parent.parent.parent.parent.Find("BagDetails/UnLocked").gameObject;
        truebtn = transform.parent.parent.parent.parent.parent.Find("BagDetails/UnLocked/truebtn").GetComponent<Button>();
        costcointxt = transform.parent.parent.parent.parent.parent.Find("BagDetails/UnLocked/costcointxt").GetComponent<Text>();
        falsebtn = transform.parent.parent.parent.parent.parent.Find("BagDetails/UnLocked/falsebtn").GetComponent<Button>();
        closebtn = transform.parent.parent.parent.parent.parent.Find("BagDetails/UnLocked/close").GetComponent<Button>();
        falsebtn.onClick.AddListener(cancelcost);
        closebtn.onClick.AddListener(cancelcost);
        unlocked = transform.GetComponent<Button>();
        unlocked.onClick.AddListener(() => { isclick = false; unlockUI.gameObject.SetActive(true); });
        truebtn.onClick.AddListener(costcoin);
        it = transform.GetComponent<InventoryItemUI>();
    
    }
    
    private void OnDestroy()
    {
        InventoryUI._instance.OnRemoveUnlock -= OnRemoveUnlock;
    }

    void Start () {
        InventoryUI._instance.OnRemoveUnlock += OnRemoveUnlock;
    }
	
	void Update () {
		
	}
    int CoinNeed=1000;
    bool isSuccess;
    void costcoin()      //点击是消耗金钱
    {
            unlockUI.gameObject.SetActive(false);
        if (isclick == false)
        {
            
             isSuccess = PlayInfo._instance.Getcoin(count);
            if (isSuccess)
            {
                PlayInfo._instance.Getcoin(count);
                InventoryUI._instance.SendMessage("RemoveUnlock");
                Image.DOFade(0, 0.4f).OnComplete(changeimg);
                costcointxt.text = "需要花费" + count.ToString() + "金币";    //下一个需要背包花费的金钱
            }
            else
            {
                
            }
         
        }
           
        
    }
    void cancelcost()         //否 关闭
    {
        unlockUI.gameObject.SetActive(false);
    }
    void changeimg()        //改变图片
    {
        image.sprite = Resources.Load("TanTianJun/Image/开锁", typeof(Sprite)) as Sprite;
        image.DOFade(1, 0.4f).OnComplete(additui);
    }
    public void setimg()       //初始图片
    {
        Image.sprite = Resources.Load("TanTianJun/Image/关锁", typeof(Sprite)) as Sprite;
    }

    public void OnRemoveUnlock()          //移除脚本
    {
        count += 1000;
       if (isclick == false)
        {
            Destroy(unlocked.GetComponent<UnlockedUI>());
        }
    }
    void additui()            //添加脚本 背包格子初始化
    {
        image.DOFade(0, 0.4f).OnComplete(() => {
            image.sprite = Resources.Load("TanTianJun/Image/bg_道具", typeof(Sprite)) as Sprite;
            image.DOFade(1, 0);
            unlockUI.AddComponent<InventoryItemUI>();
            InventoryUI._instance.itemUIList.Add(it);
            it.Clear();
            InventoryUI._instance.UpdateShow();
            }
        );
       
    }
    
}
