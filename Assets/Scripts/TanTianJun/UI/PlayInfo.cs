using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerType
{
    Warrior,
    FemaleAssassion
} 

public class PlayInfo : MonoBehaviour
{
    #region property
    string _name;   //姓名
    string _headPortrait;  //头像 
    int _level=1;   //等级
    int _power = 1;  //战斗力
    int exp;    //经验
    int _diamond;   //钻石
    int _coin;      //金币
    int _energy;    //体力
    int _toughen;   //历练
    PlayerType playertype;
    #endregion
    public static PlayInfo _instance;
    public InventoryItem helmet, clothes, weapon, ring, wing, necklace, bracelet, shoes;
    #region set;get
    
    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public string HeadPortrait
    {
        get
        {
            return _headPortrait;
        }

        set
        {
            _headPortrait = value;
        }
    }

    public int Level
    {
        get
        {
            return _level;
        }

        set
        {
            _level = value;
        }
    }

    public int Power
    {
        get
        {
            return _power;
        }

        set
        {
            _power = value;
        }
    }

    public int Exp
    {
        get
        {
            return exp;
        }

        set
        {
            exp = value;
        }
    }

    public int Diamond
    {
        get
        {
            return _diamond;
        }

        set
        {
            _diamond = value;
        }
    }

    public int Coin
    {
        get
        {
            return _coin;
        }

        set
        {
            _coin = value;
        }
    }

    public int Energy
    {
        get
        {
            return _energy;
        }

        set
        {
            _energy = value;
        }
    }

    public int Toughen
    {
        get
        {
            return _toughen;
        }

        set
        {
            _toughen = value;
        }
    }

    public PlayerType Playertype
    {
        get
        {
            return playertype;
        }

        set
        {
            playertype = value;
        }
    }
    #endregion

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
    }    //穿装备
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
    }   //脱装备
    public void InventoryUse(InventoryItem it,int count)
    {    //使用效果
        //TODO
        //使用完是否存在
        it.Count -= count;
        if (it.Count <= 0)
        {
            InventoryManager._instance.inventoryItemList.Remove(it);
        }
    }
    public int GetOverallPower()
    {
        float power = this.Power;
        if (helmet != null)
        {
            power += helmet.Inventory.Power * (1 + (helmet.Level - 1) / 10f);
        }
        if (clothes != null)
        {
            power += clothes.Inventory.Power * (1 + (clothes.Level - 1) / 10f);
        }
        if (weapon != null)
        {
            power += weapon.Inventory.Power * (1 + (weapon.Level - 1) / 10f);
        }
        if (ring != null)
        {
            power += ring.Inventory.Power * (1 + (ring.Level - 1) / 10f);
        }
        if (wing != null)
        {
            power += wing.Inventory.Power * (1 + (wing.Level - 1) / 10f);
        }
        if (necklace != null)
        {
            power += necklace.Inventory.Power * (1 + (necklace.Level - 1) / 10f);
        }
        if (bracelet != null)
        {
            power += bracelet.Inventory.Power * (1 + (bracelet.Level - 1) / 10f);
        }
        if (shoes != null)
        {
            power += shoes.Inventory.Power * (1 + (shoes.Level - 1) / 10f);
        }
        return (int)power;
    }
}
