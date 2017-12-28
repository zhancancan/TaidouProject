using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetEquipShow : MonoBehaviour {

    private Button clothBtn;
    private InventoryItem it;
    private void Awake()
    {
        clothBtn = this.GetComponent<Button>();
    }

    public void SetPetID(int id)
    {
        Inventory inventory = null;
        bool isExit = InventoryManager._instance.inventoryDict.TryGetValue(id, out inventory);
        if (isExit)
        {
            clothBtn.image.sprite = inventory.Icon;
        }

        
    }

    public void SetInventoryItem(InventoryItem it)
    {
        if (it == null) return;

        this.it = it;
        clothBtn.image.sprite = it.Inventory.Icon;
    }
    void abcd()
    {if (it == null) return;
        PetInfo._petInstance.PetDressOff(it);
        clothBtn.image.sprite=Resources.Load("TanTianJun/Image/bg_道具",typeof(Sprite)) as Sprite;
        it = null;
    }
}
