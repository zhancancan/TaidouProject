using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnapsackRoleEquip : MonoBehaviour
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
    Button btn;
   
    private void Awake()
    {
        btn = transform.GetComponent<Button>();

        btn.onClick.AddListener(delegate () {
            if (it != null)
            {
                object[] objectArray = new object[3];
                objectArray[0] = it;
                objectArray[1] = false;
                objectArray[2] = this;

                transform.parent.parent.parent.SendMessage("OnInventoryClick", objectArray);
            }
        });
    }
    private void Update()
    {
        
    }
}

