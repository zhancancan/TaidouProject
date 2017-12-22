using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventoryItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image image;
    Text txt;//物品的数量
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
    Text Txt
    {
        get
        {
            if (txt == null)
            {
                txt = transform.Find("Text").GetComponent<Text>();
            }
            return txt;
        }
    }
    public InventoryItem it;
    public void SetInventoryItem(InventoryItem it)
    {
        this.it = it;
        Image.sprite = it.Inventory.Icon;
        if (it.Count <= 1)
        {
            Txt.text = "";
        }
        else
        {
            Txt.text = it.Count.ToString();
        }
    }
    public void Clear()
    {
        it = null;
        Txt.text = "";
        Image.sprite = Resources.Load("TanTianJun/Image/bg_道具", typeof(Sprite)) as Sprite;
    }
    Button btn;
    EquipPopup eq;
    private void Awake()
    {
        btn = GetComponent<Button>();
        eq = new EquipPopup();
        btn.onClick.AddListener(delegate () {
            if (it != null)
            {
                object[] objectArray = new object[3];
                objectArray[0] = it;
                objectArray[1] = true;
                objectArray[2] = this;

                transform.parent.parent.parent.parent.parent.SendMessage("OnInventoryClick", objectArray);
            }
        });
    }

    public float Interval = 0.5f;
    private float firstClicked = 0;
    private float secondClicked = 0;
    bool isclick = false;


    bool isenter = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isenter == true)
        {
            secondClicked = Time.realtimeSinceStartup;

            if (secondClicked - firstClicked < Interval && isclick == false)
            {
                if (it != null && it.Inventory.InventoryType == InventoryType.Equip)
                {
                    eq.Onequip(it);
                    Clear();
                }
                else if(it!=null &&it.Inventory.InventoryType==InventoryType.Drug|it.Inventory.InventoryType==InventoryType.Box)
                {
                   
                    it.Count -= 1;
                    
                    if (it.Count == 1) { Txt.text = ""; }
                    else  if (it.Count<=0)
                    {
                        InventoryManager._instance.inventoryItemList.Remove(it);
                        Clear();

                    }
                    else { Txt.text = it.Count.ToString(); }
                }
                isclick = true;
            }
            else
            {
                firstClicked = secondClicked;
                isclick = false;
            }
        }

    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        isenter = true;

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isenter = false;
    }
    public void ChangeCount(int count)//物品数量的改变
    {
        if(it.Count-count<=0) {  Clear(); }
        else if (it.Count - count == 1) { Txt.text = ""; }
        else { Txt.text = (it.Count - count).ToString(); }
    }
}
