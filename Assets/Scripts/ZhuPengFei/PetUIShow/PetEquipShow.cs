using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetEquipShow : MonoBehaviour {
    public static PetEquipShow _petEquipShow;

    private Button clothBtn;
    private InventoryItem it;
    Button btn;
    PetEquipPopup eq;
    private void Awake()
    {
        _petEquipShow = this;
        btn = transform.GetComponent<Button>();
        eq = new PetEquipPopup();
        btn.onClick.AddListener(delegate () {
            if (it != null)
            {
                object[] objectArray = new object[1];
                objectArray[0] = it;
                

                transform.parent.parent.parent.Find("PetEquipPopup").SendMessage("Show", objectArray);
                transform.parent.parent.parent.Find("PetEquipPopup/PetEquiptInf").gameObject.SetActive(true);
            }
        });
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
    //清除装备中的UI
    public void CleanPetEquipUI()
    {if (it == null) return;
        PetInfo._petInstance.PetDressOff(it);
        clothBtn.image.sprite=Resources.Load("TanTianJun/Image/bg_道具",typeof(Sprite)) as Sprite;
        it = null;
    }
}
