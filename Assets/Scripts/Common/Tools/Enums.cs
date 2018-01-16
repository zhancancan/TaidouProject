using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//zcc
//UIStore
public enum MainItemType
{
    Equip,
    Drug,
    Material,
    Artifact,
    Fashion,
    Pet,
    Diamon,
    Gemstone,
    Coin,
}

public enum ViceEquipItemType
{
    Weapon,
    Helm,
    Necklace,
    Ring,
    Bracelet,
    Cloth,
    Shoes,
    Wing,
}

public enum ViceDrugItemType
{
    HP,
    MP
}

//PoolProperty
public enum PoolObjectType
{
    Enemy1,
    Enemy2,
    Enemy3
}

//PlayerMove
public enum PlayerMoveState //移动状态
{
    Idle,
    Walk
}

//PlayerAttack
public enum PlayerState //控制状态
{
    ControlWalk,
    NormalAttack,
    SkillAttack,
    Death
}

public enum PlayerAttackState   //攻击状态
{
    Moving,
    Idle,
    Attack
}

//Skill
public enum ApplyType{
    Passive,
    Buff,
    SingleTarget,
    MultiTarget
}