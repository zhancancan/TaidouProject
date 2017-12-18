using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InfoType
{
    Equip
}
public enum InventoryType
{
    Equip,
    Drug,
    Box
}
public enum EquipType
{
    Helmet,
    Clothes,
    Weapon,
    Shoes,
    Necklace,
    Bracelet,
    Ring,
    Wing

}
public class Inventory
{
    int id;//ID
    string name;//名称
    Sprite icon;//在图集中的名称
    InventoryType inventoryType;//物品类型
    EquipType equipType; //装备类型
    int price = 0;//价格
    int startlevel = 1;//星级
    int quality = 1;//品质
    int damage = 0;//伤害
    int hp = 0;//生命
    int power = 0;//战斗力
    InfoType infoType;//作用类型，表示作用在哪个属性之上
    int applyValue;//作用值
    string des;//描述
    public int ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }
    public InventoryType InventoryType
    {
        get { return inventoryType; }
        set { inventoryType = value; }
    }
    public EquipType EquipType
    {
        get { return equipType; }
        set { equipType = value; }
    }
    public int Price
    {
        get { return price; }
        set { price = value; }
    }
    public int Startlevel
    {
        get { return startlevel; }
        set { startlevel = value; }
    }
    public int Quality
    {
        get { return quality; }
        set { quality = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    public int Power
    {
        get { return power; }
        set { power = value; }
    }
    public InfoType InfoType
    {
        get { return infoType; }
        set { infoType = value; }
    }
    public int ApplyValue
    {
        get { return applyValue; }
        set { applyValue = value; }
    }
    public string Des
    {
        get { return des; }
        set { des = value; }
    }

}
