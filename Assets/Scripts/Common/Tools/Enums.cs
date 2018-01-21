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
public enum PlayerMoveState
{//移动状态
    Idle,
    Walk,
    Run
}

//PlayerAttack
public enum PlayerState
{//控制状态
    ControlWalk,
    NormalAttack,
    SkillAttack,
    Death
}

public enum PlayerAttackState
{//攻击状态
    Moving,
    Idle,
    Attack
}

//Skill
public enum ApproRole
{//适合角色
    Warrior,
    Male,
    Archer
}

public enum ApplyType
{//作用类型  
    Passive,
    Buff,
    SingleTarget,
    MultiTarget
}

public enum ApplyProperty
{//作用属性
    Attack,
    Def,
    Speed,
    AttackSpeed,
    HP,
    MP
}

public enum ReleaseType
{//释放类型
    Self,
    Enemy,
    Position
}

//UIShutCut
public enum ShutCutType
{//快捷键类型
    Skill,
    Drug,
    None
}

//PlayerStatus
public enum RoleType
{//角色类型
    Mage,
    Warrior,
    Archer
}