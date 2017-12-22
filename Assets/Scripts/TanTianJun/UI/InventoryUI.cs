using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    public static InventoryUI _instance;
    public   List<InventoryItemUI> itemUIList = new List<InventoryItemUI>();//所有物品格子
    Button tidybtn;
    private void Awake()
    {
        _instance = this;
        tidybtn = GameObject.Find("BagDetails/tidybtn").GetComponent<Button>();
        tidybtn.onClick.AddListener(UpdateShow);
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
     public void UpdateShow()
    {
        int temp = 0;
        for (int i = 0; i < InventoryManager._instance.inventoryItemList.Count; i++)
        {
            InventoryItem it = InventoryManager._instance.inventoryItemList[i];
            if (it.Isdressed == false)
            {
                itemUIList[temp].SetInventoryItem(it);
                temp++;
            }
        }
        for (int i = temp; i < itemUIList.Count; i++)
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
