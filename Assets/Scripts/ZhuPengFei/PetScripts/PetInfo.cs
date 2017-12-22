using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private string petName;           //宠物名
    private string petHead;           //宠物头像
    private float petHP;              //宠物生命值
    private int starLevel;            //宠物星阶等级
    private int petAtk;               //宠物攻击力
    private int petDef;               //宠物防御力
    private int petCombat;            //宠物战斗力
    private string petSkill;          //宠物技能
    private int petEnergy;            //宠物活力值



    private float energyTimer;          //活力计时器
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
    public int StarLevel
    {
        get { return starLevel; }
        set { starLevel = value; }
    }
    public int PetAtk
    {
        get { return petAtk; }
        set { petAtk = value; }
    }
    public int PetDef
    {
        get { return petDef; }
        set { petDef = value; }
    }
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
    #endregion


    void Awake()
    {
        _petInstance = this;
    }


    void Update()
    {
        //活力值的自动增长
        if (this.energyTimer<100)
        {
            energyTimer += Time.deltaTime;
            //60s增长一个活力值
            if (this.energyTimer>=60)
            {
                petEnergy++;
                energyTimer -= 60;
            }
        }
        //活力值如果满了，就不增长，一直保持计时器为0
        else
        {
            this.energyTimer = 0;
        }
    }

    void petInit()
    {
        this.petName = "烈焰狂狮";
        this.petHead = "Head_Lion";
        this.petHP = 90;
        this.starLevel = 1;
        this.petAtk = 110;
        this.PetDef = 95;
        this.petCombat = 1125;
        this.petSkill = "狮吼";
        this.petEnergy = 95;
    }


}
