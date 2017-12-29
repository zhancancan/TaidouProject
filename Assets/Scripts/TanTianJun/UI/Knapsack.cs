using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Knapsack : MonoBehaviour ,IDragHandler{
 
    EquipPopup equip;
    InventoryPopup inventory;
    Scrollbar sc;
    ToggleGroup tg;
    Toggle t1, t2;
    Button close;
    Button btnsale;
    Text pricesale;
    InventoryItemUI itUI;
    
    private void Awake()
    {

        inventory = transform.Find("BagDetails/InventoryPopup").GetComponent<InventoryPopup>();
        equip = transform.Find("BagDetails/EquipPopup").GetComponent<EquipPopup>();
        t1 = transform.Find("BagDetails/ToggleGroup/Toggle").GetComponent<Toggle>();               //页数
        t2 = transform.Find("BagDetails/ToggleGroup/Toggle1").GetComponent<Toggle>();
        sc = transform.Find("BagDetails/bagdetails/ScrInventory/Scrollbar").GetComponent<Scrollbar>();   //滚动
        t1.onValueChanged.AddListener(ison);
        close = transform.Find("BagDetails/Closebtn").GetComponent<Button>();    //关闭
        close.onClick.AddListener(() =>transform.gameObject.SetActive(false));
        btnsale = transform.Find("BagDetails/btnsale").GetComponent<Button>();     //出售按钮
        btnsale.onClick.AddListener(OnSale);
        pricesale = transform.Find("BagDetails/btnsale/saleprice").GetComponent<Text>();     //出售价格      
        DisableButton();
              
    }
    public void OnInventoryClick(object[] objectArray)
    {
        InventoryItem it = objectArray[0] as InventoryItem;
        bool isleft = (bool)objectArray[1];
        if (it.Inventory.InventoryType == InventoryType.Equip||it.Inventory.InventoryType==InventoryType.Pet||it.Inventory.InventoryType==InventoryType.PetEquip)
        {
            InventoryItemUI itUI = null;
            KnapsackRoleEquip roleEquip = null;
            if (isleft == true)
            {
                itUI = objectArray[2] as InventoryItemUI;
            }
            else
            {
                roleEquip = objectArray[2] as KnapsackRoleEquip;
            }
            inventory.CloseOn();
            equip.Show(it, itUI, roleEquip,isleft);
        }
        else 
        {
            InventoryItemUI itUI = objectArray[2] as InventoryItemUI;
            equip.closeon();
            inventory.Show(it,itUI);
        }
        if ((it.Inventory.InventoryType == InventoryType.Equip && isleft == true) || it.Inventory.InventoryType != InventoryType.Equip)
        {
            this.itUI= objectArray[2] as InventoryItemUI;
            EnableButton();
            pricesale.text = (this.itUI.it.Inventory.Price * this.itUI.it.Count).ToString();
        }
    }
    
    void ison(bool iss)
    {
        if (t1.isOn)
        {
            sc.value = 0;
        }
        else
        {
            sc.value = 1;
           
        }
    }
    void DisableButton()       //按钮的交互
    {
        pricesale.text = "";
        btnsale.interactable = false;
    }
    void EnableButton()
    {
        btnsale.interactable = true;
    }
    void OnSale()
    {
        int price = int.Parse(pricesale.text);
        PlayInfo._instance.AddCoin(price);
        InventoryManager._instance.RemoveInventoryItem(itUI.it);
        itUI.Clear();
        equip.close();
        inventory.Close();
        InventoryUI._instance.SendMessage("UpdateCount");
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.SetSiblingIndex(40);
        gameObject.transform.position = eventData.position;
    }
}
