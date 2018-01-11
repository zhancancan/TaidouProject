﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstDates {

    //定义预支体路径
    //common
    public const string ResourcePrefabDirCommon = "Common/Prefabs";
    //hj
    public const string ResourcePrefabDirHj = "HuJian/Prefabs/UI";
    //swl
    public const string ResourcePrefabDirSwl = "ShanWeiLong/Prefabs/UI";
    public const string ResourcePlayerPrefabDirSwl = "ShanWeiLong/Prefabs/Player";
    public const string ResourceAnimatorPrefabDirSwl = "ShanWeiLong/Prefabs/Animators";
    public const string ResourceEffectPrefabDirSwl = "ShanWeiLong/Prefabs/MyEffect";
    //zcc
    public const string ResourcePrefabDirZcc = "ZhangCanCan/Prefabs/UI";
    public const string ResourceEffectPrefabDirZcc = "ZhangCanCan/Prefabs/Effects";
    public const string ResourceTexturePrefabDirZcc = "ZhangCanCan/Textures/MouseCursor";
    //ttj
    public const string ResourcePrefabDirTtj = "TanTianJun/Prefabs";
    //zpf
    public const string ResourcePrefabDirZpf = "ZhuPengFei/Prefabs";
    public const string ResourcePetPrefabDirZpf = "ZhuPengFei/Prefabs/Pet";

    //定义音频路径
    //public
    public const string ResourceAudiosDir = "Common/Audios";
    //hj
    public const string ResourceAudiosDirHj = "HuJian/Audios";

    //定义图片路径
    public const string ResourceTexturesDirZpf = "ZhuPengFei/Textures";

    //定义image路径
    public const string ResourceImagesDirTtj = "TanTianJun/Image";

    //定义精灵路径
    public const string ResourceSpritesDirSwl = "ShanWeiLong/Sprites";

    //背景音频
    //hj
    public const string Bgm_1 = "UIStartBGM";

    //图片
    //zpf
    public const string Head_Lion = "Head_Lion";
    public const string Head_Fairy = "Head_Fairy";
    public const string Head_Elf = "Head_Elf";
    //zcc
    public const string Cursor_Normal = "Cursor_Normal";
    public const string Cursor_NpcTalk = "Cursor_NpcTalk";
    public const string Cursor_Attack = "Cursor_Attack";
    public const string Cursor_LockTarget = "Cursor_LockTarget";
    public const string Cursor_Pick = "Cursor_Pick";

    //精灵图片
    //swl
    public const string VideoPlay = "播放";
    public const string VideoPause = "暂停";

    //UI界面预制体
    //common
    public const string UISystemSetting = "UISystemSetting";
    //hj
    public const string UIStart = "UIStart";    
    public const string UILogin = "UILogin";
    public const string UIRegister = "UIRegister";
    public const string UISelectSever = "UISelectSever";
    public const string UISelectRole = "UISelectRole";
    public const string UITask = "UITask";
    public const string UIGemstoneCompose = "UIGemstoneCompose";
    public const string UITaskList = "UITaskList";
    //swl
    public const string UISelectPlayer = "UISelectPlayer";
    public const string UICreatePlayer = "UICreatePlayer";
    //zcc
    public const string UIMain = "UIMain";
    public const string UIPlayerProperty = "UIPlayerProperty";
    public const string UIStore = "UIStore";
    public const string UIStoreViceItem = "UIStoreViceItem";
    public const string UIStoreItem = "UIStoreItem";
    public const string UIRecharge = "UIRecharge";
    //ttj
    public const string UIBag = "UIBag";
    //zpf
    public const string UIPet = "UIPet";
    public const string UIPetMain = "UIPetMain";
    public const string UIElf = "UIElf";
    public const string UILion = "UILion";
    public const string UIFairy = "UIFairy";

    //特效预制体
    //zcc
    public const string Effect_MouseClick_Green = "Effect_MouseClick_Green";

    //宠物
    //zpf
    public const string Elf = "Elf";
    public const string Fairy = "Fairy";
    public const string Lion = "Lion";

    //当前运行场景的名字
    //hj
    public const string StartScene = "StartScene";
    //swl
    public const string SelectPlayerScene = "SelectPlayerScene";
    public const string CreatePlayerScene = "CreatePlayerScene";
    //zcc
    public const string MainScene = "MainScene";

    //人物角色预制体
    //swl
    public const string ArcherFemale = "/Archer_Female";
    public const string ArcherMale = "/Archer_Male";
    public const string MageFemale = "/Mage_Female";
    public const string MageMale = "/Mage_Male";
    public const string WarriorFemale = "/Warrior_Female";
    public const string WarriorMale = "/Warrior_Male";

    //技能特效预制体
    //swl
    public const string BloodSpray = "/BloodSpray/BloodSpray";
    public const string Crack = "/Crack/Crack";
    public const string Fire = "/FireAndIce/Fire";
    public const string Ice = "/FireAndIce/Ice";
    public const string FireDragon = "/FireDragon/FireDragon";
    public const string FireDragonRoll = "/FireDragonRoll/FireDragonRoll";
    public const string IceArrow = "/IceArrow/IceArrow";
    public const string IceMake = "/IceMake/IceMake";
    public const string MageAttack = "/MageAttack/MageAttack";
    public const string MonsterRaids = "/MonsterRaids/MonsterRaids";
    public const string MuzzleFlash = "/Perfab/MuzzleFlash";
    public const string Shock_Bomb = "/Perfab/Shock_Bomb";
    public const string Tonado_Electro = "/Perfab/Tonado_Electro";

    //人物状态机
    public const string WarriorAnimator = "/WarriorAnim";
    public const string MageAnimator = "/MageAnim";
    public const string ArcherAnimator = "/ArcherAnim";

    //当前场景的Index
    public const int StartSceneIndex = 0;
    public const int SelectPlayerSceneIndex = 1;
    public const int CreatePlayerSceneIndex = 2;
    public const int MainSceneIndex = 3;
}
