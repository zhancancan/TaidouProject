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
    int count = 1000;
    private void Awake()
    {
        unlockUI = transform.parent.parent.parent.parent.parent.Find("BagDetails/UnLocked").gameObject;
        truebtn = transform.parent.parent.parent.parent.parent.Find("BagDetails/UnLocked/truebtn").GetComponent<Button>();
        costcointxt = transform.parent.parent.parent.parent.parent.Find("BagDetails/UnLocked/costcointxt").GetComponent<Text>();
        falsebtn = transform.parent.parent.parent.parent.parent.Find("BagDetails/UnLocked/falsebtn").GetComponent<Button>();
        closebtn = transform.parent.parent.parent.parent.parent.Find("BagDetails/UnLocked/close").GetComponent<Button>();
        costcointxt.text = "需要花费" + count.ToString() + "金币";
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
    void costcoin()
    {
        count += 1000;
        unlockUI.gameObject.SetActive(false);
        costcointxt.text = "需要花费" + count.ToString() + "金币";
        PlayInfo._instance.CostCoin(count);
        if (isclick == false)
        {
            InventoryUI._instance.SendMessage("RemoveUnlock");
            Image.DOFade(0, 0.4f).OnComplete(changeimg);
        }
        
    }
    void cancelcost()
    {
        unlockUI.gameObject.SetActive(false);
    }
    void changeimg()
    {
        image.sprite = Resources.Load("TanTianJun/Image/开锁", typeof(Sprite)) as Sprite;
        image.DOFade(1, 0.4f).OnComplete(additui);
    }
    public void setimg()
    {
        Image.sprite = Resources.Load("TanTianJun/Image/关锁", typeof(Sprite)) as Sprite;
    }

    public void OnRemoveUnlock()
    {   if(isclick==false)
        Destroy(unlocked.GetComponent<UnlockedUI>());
    }
    void additui()
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
