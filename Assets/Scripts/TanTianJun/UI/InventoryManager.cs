using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    public static InventoryManager _instance;
    public TextAsset listinfo;
    public  Dictionary<int, Inventory> inventoryDict = new Dictionary<int, Inventory>();
    public List<InventoryItem> inventoryItemList = new List<InventoryItem>();
    public delegate void OnInventoryChangeEvent();
    public event OnInventoryChangeEvent OnInventoryChange;
    private void Awake()
    {
        _instance = this;
        ReadInventoryInfo();
        
    }
    private void Start()
    {
        ReadInventoryItemInfo();
    }
    void ReadInventoryInfo()
    {
        string str = listinfo.ToString();
        string[] itemStrArray = str.Split('\n');
        foreach (string itemStr in itemStrArray)
        {
           
            //ID 名称 图标 类型（Equip，Drug） 装备类型(Helm, Cloth, Weapon, Shoes, Necklace, Bracelet, Ring, Wing) 
            string[] proArray = itemStr.Split('|');
            Inventory inventory = new Inventory();
            inventory.ID = int.Parse(proArray[0]);
            inventory.Name = proArray[1];
            string path = proArray[2];
            inventory.Icon = Resources.Load("TanTianJun/Image/" + path, typeof(Sprite)) as Sprite; 
            switch (proArray[3])
            {
                case "Equip":
                    inventory.InventoryType = InventoryType.Equip;
                    break;
                case "Drug":
                    inventory.InventoryType = InventoryType.Drug;
                    break;
                case "Box":
                    inventory.InventoryType = InventoryType.Box;
                    break;
            }
            if (inventory.InventoryType == InventoryType.Equip)
            {
                switch (proArray[4])
                {
                    case "Helm":
                        inventory.EquipType = EquipType.Helmet;
                        break;
                    case "Cloth":
                        inventory.EquipType = EquipType.Clothes;
                        break;
                    case "Weapon":
                        inventory.EquipType = EquipType.Weapon;
                        break;
                    case "Shoes":
                        inventory.EquipType = EquipType.Shoes;
                        break;
                    case "Ring":
                        inventory.EquipType = EquipType.Ring;
                        break;
                    case "Wing":
                        inventory.EquipType = EquipType.Wing;
                        break;
                    case "Necklace":
                        inventory.EquipType = EquipType.Necklace;
                        break;
                    case "Bracelet":
                        inventory.EquipType = EquipType.Bracelet;
                        break;
                }
            }
            //售价 星级 品质 伤害 生命 战斗力 作用类型 作用值 描述
          
            if (inventory.InventoryType == InventoryType.Equip)
            {
                inventory.Price = int.Parse(proArray[5]);
                inventory.Startlevel = int.Parse(proArray[6]);
                inventory.Quality = int.Parse(proArray[7]);
                inventory.Damage = int.Parse(proArray[8]);
                inventory.Hp = int.Parse(proArray[9]);
                inventory.Power = int.Parse(proArray[10]);
            }
            if (inventory.InventoryType == InventoryType.Drug)
            {
                inventory.ApplyValue = int.Parse(proArray[12]);
            }
            inventory.Des = proArray[13];
            inventoryDict.Add(inventory.ID, inventory);
        }
    }
//完成角色信息的初始化，获得角色拥有的物品
    void ReadInventoryItemInfo()
    {
        //需要连接服务器 取得当前角色拥有的物品信息
        //随机生成主角拥有的物品
        for (int k = 0; k< 20; k++)
        {
            int id = Random.Range(1001, 1020);
            
            Inventory j=null;
            inventoryDict.TryGetValue(id, out j);
            if (j.InventoryType == InventoryType.Equip)
            {
                InventoryItem it = new InventoryItem();
                it.Inventory = j;
                it.Level = Random.Range(1, 10);
                it.Count = 1;
                inventoryItemList.Add(it);
            }
            else
            {
                //先判断备用里面是否存在
                InventoryItem it = null;
                bool isExit = false;
                foreach (InventoryItem temp in inventoryItemList)
                {
                    if (temp.Inventory.ID == id)
                    {
                        isExit = true;
                        it = temp;
                        break;
                    }
                }
                if (isExit)
                {
                    it.Count++;
                }
                else
                {
                    it = new InventoryItem();
                    it.Inventory = j;
                    it.Count = 1;
                    inventoryItemList.Add(it);
                }
            }
        }
        OnInventoryChange();
    }
}
