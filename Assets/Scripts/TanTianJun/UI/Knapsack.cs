using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Knapsack : MonoBehaviour {
 
    EquipPopup equip;
    InventoryPopup inventory;
    Scrollbar sc;
    ToggleGroup tg;
    Toggle t1;
    
    
    private void Awake()
    {

        inventory = transform.Find("BagDetails/InventoryPopup").GetComponent<InventoryPopup>();
        equip = transform.Find("BagDetails/EquipPopup").GetComponent<EquipPopup>();
        t1 = transform.Find("BagDetails/ToggleGroup/Toggle").GetComponent<Toggle>();
        sc = transform.Find("BagDetails/bagdetails/ScrInventory/Scrollbar").GetComponent<Scrollbar>();
        t1.onValueChanged.AddListener(sd);
        
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
            inventory.Show(it);
        }
      
    }
    
    void sd(bool iss)
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

}
