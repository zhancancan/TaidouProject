using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Knapsack : MonoBehaviour {
 
    EquipPopup equip;
    InventoryPopup inventory;
    Scrollbar sc;
    ToggleGroup tg;
    Toggle t1, t2;
    Button close;
    
    
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
                              //整理
    }
    public void OnInventoryClick(object[] objectArray)
    {
        InventoryItem it = objectArray[0] as InventoryItem;
        bool isleft = (bool)objectArray[1];
        if (it.Inventory.InventoryType == InventoryType.Equip)
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
            
            equip.Show(it, itUI, roleEquip,isleft);
        }
        else 
        {
            InventoryItemUI itUI = objectArray[2] as InventoryItemUI;
            inventory.Show(it,itUI);
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
   void OnClearUp()
    {

    }
   

}
