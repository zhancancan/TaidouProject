using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
    public static InventoryUI _instance;
  public   List<InventoryItemUI> itemUIList = new List<InventoryItemUI>();//所有物品格子

    private void Awake()
    {
        _instance = this;
        InventoryManager._instance.OnInventoryChange += this.OnInventoryChange;
    }
   
    private void OnDestroy()
    {
        InventoryManager._instance.OnInventoryChange -= this.OnInventoryChange;
    }
    void OnInventoryChange()
    {
        UpdateShow();
    }
    void UpdateShow()
    {
        for (int i = 0; i < InventoryManager._instance.inventoryItemList.Count; i++)
        {
            InventoryItem it = InventoryManager._instance.inventoryItemList[i];
            itemUIList[i].SetInventoryItem(it);
        }
        for (int i = InventoryManager._instance.inventoryItemList.Count; i < itemUIList.Count; i++)
        {
            
            itemUIList[i].Clear();
        }
    }
    //TODO
    public void AddInventoryItem(InventoryItem it)
    {
        foreach (InventoryItemUI itUI in itemUIList)
        {
            if (itUI.it == null)
            {
                itUI.SetInventoryItem(it);
                break;
            }
        }
    }
}
