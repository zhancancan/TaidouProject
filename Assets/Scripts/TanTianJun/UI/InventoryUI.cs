using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    public static InventoryUI _instance;
    public   List<InventoryItemUI> itemUIList = new List<InventoryItemUI>();//所有物品格子
    Button tidybtn;
    Text lattice;
    int count = 0;
    private void Awake()
    {
        _instance = this;
        tidybtn = GameObject.Find("BagDetails/tidybtn").GetComponent<Button>();
        tidybtn.onClick.AddListener(UpdateShow);
        lattice = GameObject.Find("Lattice").GetComponent<Text>();
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
        count = temp;
        for (int i = temp; i < itemUIList.Count; i++)
        {
            
            itemUIList[i].Clear();
        }
        lattice.text = count + "/40";
    }
    //TODO
    public void AddInventoryItem(InventoryItem it)
    {
        foreach (InventoryItemUI itUI in itemUIList)
        {
            if (itUI.it == null)
            {
                itUI.SetInventoryItem(it);
                count++;
                break;
            }
        }
        lattice.text = count + "/40";
    }
    public void UpdateCount()
    {
        count = 0;
        foreach (InventoryItemUI itUI in itemUIList)
        {
            if (itUI.it != null)
            {
                count++;
            }
        }
        lattice.text = count + "/40";
    }
}
