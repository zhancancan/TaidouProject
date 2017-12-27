using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    public static InventoryUI _instance;
   
    public   List<InventoryItemUI> itemUIList = new List<InventoryItemUI>();//所有物品格子
    public List<UnlockedUI> locklist = new List<UnlockedUI>();
    Button tidybtn;
    Text lattice;
    int count = 0;
    int temp = 0;
    private void Awake()
    {
        _instance = this;
        tidybtn = GameObject.Find("BagDetails/tidybtn").GetComponent<Button>();
        tidybtn.onClick.AddListener(UpdateShow);
        lattice = GameObject.Find("Lattice").GetComponent<Text>();
        InventoryManager._instance.OnInventoryChange += this.OnInventoryChange;
        for (int i = 0; i < locklist.Count; i++)
        {
            
            locklist[temp].setimg();
            locklist[temp].unlocked.interactable = false;
            temp++;
        }
        locklist[0].unlocked.interactable = true;
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
        lattice.text = count + "/"+itemUIList.Count;
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
        lattice.text = count + "/" + itemUIList.Count;
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
        lattice.text = count + "/" + itemUIList.Count;
    }
    public delegate void RemoveUnlockEvent();
    public event RemoveUnlockEvent OnRemoveUnlock;
    public void RemoveUnlock()
    {
        
        locklist.RemoveAt(0);

        OnRemoveUnlock();
        if (locklist.Count == 0)
        {
            return;
        }
        else locklist[0].unlocked.interactable = true;


    }
}
