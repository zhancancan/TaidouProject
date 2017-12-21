using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayInfo : MonoBehaviour
{
    public static PlayInfo _instance;
    public InventoryItem helmet, clothes, weapon, ring, wing, necklace, bracelet, shoes;

    //int helmetID, clothesID, weaponID, ringID, wingID, necklaceID, braceletID, shoesID;
    //public int HelmetID
    //{
    //    get
    //    {
    //        return helmetID;
    //    }
    //    set
    //    {
    //        helmetID = value;
    //    }
    //}
    //public int ClothesID { get { return clothesID; } set { clothesID = value; } }
    //public int WeaponID { get { return weaponID; } set { weaponID = value; } }
    //public int RingID { get { return ringID; } set { ringID = value; } }
    //public int WingID { get { return wingID; }set { wingID = value; } }
    //public int NecklaceID { get { return necklaceID; } set { necklaceID = value; } }
    //public int BraceletID { get { return braceletID; }set { braceletID = value; } }
    //public int ShoesID { get { return shoesID; }set { shoesID = value; } }
    public delegate void OnPlayInfoChangedEvent(InfoType type);
    public event OnPlayInfoChangedEvent OnPlayInfoChanged;
    private void Awake()
    {
        _instance = this;
    }

    public void DressOn(InventoryItem it)
    {
        it.Isdressed = true;

        bool isdressed = false;
        InventoryItem inventoryItemDressed = null;
        switch (it.Inventory.EquipType)
        {
            case EquipType.Bracelet:
                if (bracelet != null)
                {
                    isdressed = true;
                    inventoryItemDressed = bracelet;
                }
                bracelet = it;
                break;
            case EquipType.Clothes:
                if (clothes != null)
                {
                    isdressed = true;
                    inventoryItemDressed = clothes;
                }
                clothes = it;
                break;
            case EquipType.Helmet:
                if (helmet != null)
                {
                    isdressed = true;
                    inventoryItemDressed = helmet;
                }
                helmet = it;
                break;
            case EquipType.Necklace:
                if (necklace != null)
                {
                    isdressed = true;
                    inventoryItemDressed = necklace;
                }
                necklace = it;
                break;
            case EquipType.Ring:
                if (ring != null)
                {
                    isdressed = true;
                    inventoryItemDressed = ring;
                }
                ring = it;
                break;
            case EquipType.Shoes:
                if (shoes != null)
                {
                    isdressed = true;
                    inventoryItemDressed = shoes;

                }
                shoes = it;
                break;
            case EquipType.Weapon:
                if (weapon != null)
                {
                    isdressed = true;
                    inventoryItemDressed = weapon;
                }
                weapon = it;
                break;
            case EquipType.Wing:
                if (wing != null)
                {
                    isdressed = true;
                    inventoryItemDressed = wing;
                }
                wing = it;
                break;
        }
        if (isdressed)
        {
            inventoryItemDressed.Isdressed = false;
            InventoryUI._instance.AddInventoryItem(inventoryItemDressed);
        }
        OnPlayInfoChanged(InfoType.Equip);
    }
    public void DressOff(InventoryItem it)
    {

        switch (it.Inventory.EquipType)
        {
            case EquipType.Bracelet:
                if (bracelet != null)
                {
                    bracelet = null;
                }
                break;
            case EquipType.Clothes:
                if (clothes != null)
                {
                    clothes = null;
                }
                break;
            case EquipType.Helmet:
                if (helmet != null)
                {
                    helmet = null;
                }
                break;
            case EquipType.Necklace:
                if (necklace != null)
                {
                    necklace = null;
                }
                break;
            case EquipType.Ring:
                if (ring != null)
                {
                    ring = null;
                }
                break;
            case EquipType.Shoes:
                if (shoes != null)
                {
                    shoes = null;
                }
                break;
            case EquipType.Weapon:
                if (weapon != null)
                {
                    weapon = null;
                }
                break;
            case EquipType.Wing:
                if (wing != null)
                {
                    wing = null;
                }
                break;
        }
        it.Isdressed = false;
        InventoryUI._instance.AddInventoryItem(it);
        OnPlayInfoChanged(InfoType.Equip);
    }

}
