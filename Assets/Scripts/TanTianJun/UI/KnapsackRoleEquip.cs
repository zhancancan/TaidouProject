using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class KnapsackRoleEquip : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    Image img;
    public  InventoryItem it;
    Image Img
    {
        get
        {
            if (img == null)
            {
                img = transform.GetComponent<Image>();
            }
            return img;
        }
    }
    
   
    public void SetId(int id)
    {
        Inventory inventory = null;
        bool isExit = InventoryManager._instance.inventoryDict.TryGetValue(id, out inventory);
        if (isExit)
        {
            Img.sprite = inventory.Icon;
        }
    }
    public void SetInventoryItem(InventoryItem it)
    {if (it == null) return;
        this.it = it;

        Img.sprite = it.Inventory.Icon;
    }
    public void Clear()
    {
        it = null;
        Img.sprite = Resources.Load("TanTianJun/Image/bg_道具", typeof(Sprite)) as Sprite;
    }
    Button btn;
    EquipPopup eq;
    private void Awake()
    {
        btn = transform.GetComponent<Button>();
        eq = new EquipPopup();
        btn.onClick.AddListener(delegate () {
            if (it != null)
            {
                object[] objectArray = new object[3];
                objectArray[0] = it;
                objectArray[1] = false;
                objectArray[2] = this;

                transform.parent.parent.SendMessage("OnInventoryClick", objectArray);
            }
        });
    }
    bool isenter;
    public void OnPointerEnter(PointerEventData eventData)
    {
        isenter = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isenter = false;
    }
    public float Interval = 0.5f;

    private float firstClicked = 0;
    private float secondClicked = 0;
    bool isclick = false;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isenter == true)
        {
            secondClicked = Time.realtimeSinceStartup;

            if (secondClicked - firstClicked < Interval && isclick == false )
            {   
                if (it != null && it.Inventory.InventoryType == InventoryType.Equip)
                {
                   
                    eq.Offequip(it);
                    Clear();
                    



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
   
}

