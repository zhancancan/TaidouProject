using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetEquipShow : MonoBehaviour {

    private Button clothBtn;

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
}
