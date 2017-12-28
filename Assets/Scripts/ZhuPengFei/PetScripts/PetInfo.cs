using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum PetInfoType
{
    PetName,
    PetHead,
    PetHP,
    StarLevel,
    PetAtk,
    //PetDef,
    PetCombat,
    PetSkill,
    PetEnergy,
    //-------------宠物-------------
    Pet,
    PetEquip,


    All
}
public class PetInfo : MonoBehaviour {

    //宠物信息单例
    public static PetInfo _petInstance;



    //宠物属性
    #region
    /*
     * 宠物名
     * 头像
     * 战斗力
     * 体力数
     */
    #endregion

    #region 宠物拥有的属性
    private string petName;           //宠物名
    private string petHead;           //宠物头像
    private float petHP;              //宠物生命值
    private int starLevelNum;            //宠物星阶等级
    private int petAtk;               //宠物攻击力
    //private int petDef;               //宠物防御力
    private int petCombat;            //宠物战斗力
    private string petSkill;          //宠物技能
    private int petEnergy;            //宠物活力值


    private int petWeaponID=0;            //宠物武器
    private int petEquipID=0;             //宠物装备
    #endregion

    [HideInInspector]
    public float petEnergyTimer;          //活力计时器

    //创建委托时间监听宠物属性面板是否有更改
    public delegate void OnPetInfoChangedEvent(PetInfoType type);
    public event OnPetInfoChangedEvent OnPetInfoChanged;





    #region  get/set
    public string PetName
    {
        get { return petName; }
        set { petName = value; }
    }
    public string PetHead
    {
        get { return petHead; }
        set { petHead = value; }
    }
    public float PetHP
    {
        get { return petHP; }
        set { petHP = value; }
    }
    public int StarLevelNum
    {
        get { return starLevelNum; }
        set { starLevelNum = value; }
    }
    public int PetAtk
    {
        get { return petAtk; }
        set { petAtk = value; }
    }
    //public int PetDef
    //{
    //    get { return petDef; }
    //    set { petDef = value; }
    //}
    public int PetCombat
    {
        get { return petCombat; }
        set { petCombat = value; }
    }
    public string PetSkill
    {
        get { return petSkill; }
        set { petSkill = value; }
    }
    public int PetEnergy
    {
        get { return petEnergy; }
        set { petEnergy = value; }
    }
    public int PetWeaponID
    {
        get { return petWeaponID; }
        set { petWeaponID = value; }
    }
    public int PetEquipID
    {
        get { return petEquipID; }
        set { petEquipID = value; }
    }
    #endregion


    void Awake()
    {
        _petInstance = this;
    }

    void Start()
    {
        PetInit();
    }
    void Update()
    {
        //活力值的自动增长
        if (this.petEnergyTimer < 100)
        {
            petEnergyTimer += Time.deltaTime;
            //60s增长一个活力值
            if (this.petEnergyTimer >= 60)
            {
                petEnergy++;
                petEnergyTimer -= 60;
                OnPetInfoChanged(PetInfoType.PetEnergy);
            }
        }
        //活力值如果满了，就不增长，一直保持计时器为0
        else
        {
            this.petEnergyTimer = 0;
        }
    }

    void PetInit()
    {
        this.petName = "烈焰狂狮";
        //头像直接在需要调用时在Resources中获取
        this.petHP = this.starLevelNum*100;
        this.starLevelNum = 3;
        this.petAtk = this.starLevelNum*20;
        //this.PetDef = 95;
        this.petCombat = (int)(this.petHP+this.petAtk);
        this.petSkill = "河东狮吼";
        this.petEnergy = 96;

        //宠物装备的ID号
        this.petEquipID = 1023;
        this.petWeaponID = 1024;

        //宠物生命伤害和战斗力的方法
        InitPetHpDamagePower();


        OnPetInfoChanged(PetInfoType.All);
    }

    void InitPetHpDamagePower()
    {
        this.petHP = this.starLevelNum * 100;
        this.petAtk = this.starLevelNum * 20;
        this.petCombat = (int)(this.petHP + this.petAtk);
        PutOnPetEquip(petEquipID);
        PutOnPetEquip(petWeaponID);
    }

    //宠物穿上装备
    void PutOnPetEquip(int id)
    {
        if (id == 0) return;
        Inventory inventory = null;
        InventoryManager._instance.inventoryDict.TryGetValue(id, out inventory);
        this.petHP += inventory.Hp;
        this.petCombat += inventory.Power;
        this.petAtk += inventory.Damage;
    }
    //宠物卸下装备
    void PutOffPetEquip(int id)
    {
        if (id == 0) return;
        Inventory inventory = null;
        InventoryManager._instance.inventoryDict.TryGetValue(id, out inventory);
        this.petHP -= inventory.Hp;
        this.petCombat -= inventory.Power;
        this.petAtk -= inventory.Damage;
    }
}
