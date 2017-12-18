using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knapsack : MonoBehaviour {

    EquipPopup equip;
    InventoryPopup inventory;
    private void Awake()
    {

        inventory = transform.Find("Character/BagDetails/InventoryPopup").GetComponent<InventoryPopup>();
        equip = transform.Find("Character/BagDetails/EquipPopup").GetComponent<EquipPopup>();
    }
    public void OnInventoryClick(object[] objectArray)
    {
        InventoryItem it = objectArray[0] as InventoryItem;
        bool isleft = (bool)objectArray[1];
        if (it.Inventory.InventoryType == InventoryType.Equip)
        {
            InventoryItemUI itUI = null;
            if (isleft == true)
            {
                itUI = objectArray[2] as InventoryItemUI;
            }
            equip.Show(it, itUI, isleft);
        }
        else 
        {
            inventory.Show(it);
        }
      
    }
}
