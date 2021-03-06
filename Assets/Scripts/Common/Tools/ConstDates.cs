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
    public const string ResourcePlayerPrefabDirSwl = "ShanWeiLong/Prefabs/Player/";
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
    public const string ResourcePetPrefabEffectZpf = "ZhuPengFei/PetEffect";

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
    //common
    public const string CloseSound = "关闭";
    public const string OpenSound = "打开菜单";
    public const string ButtonSound = "按钮";
    public const string ErrorSound = "错误";   
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
    public const string UITranscript = "UIMap";
    public const string UIProgressBar = "UIProgressBar";
    //swl
    public const string UISelectPlayer = "UISelectPlayer";
    public const string UICreatePlayer = "UICreatePlayer";
    public const string UISkill = "UISkill";
    public const string UISkillItem = "UISkillItem";
    public const string UISkillPic = "UISkillPic";
    //zcc
    public const string UIMain = "UIMain";
    public const string UIPlayerProperty = "UIPlayerProperty";
    public const string UIStore = "UIStore";
    public const string UIStoreViceItem = "UIStoreViceItem";
    public const string UIStoreItem = "UIStoreItem";
    public const string UIRecharge = "UIRecharge";
    public const string UISignIn = "UISignIn";
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
    //宠物特效预制体
    public const string ElfEffect = "ElfEffect";
    public const string LionEffect = "LionEffect";
    public const string FairyEffect = "FairyEffect";

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
    public const string ArcherFemale = "Archer_Female";
    public const string ArcherMale = "Archer_Male";
    public const string MageFemale = "Mage_Female";
    public const string MageMale = "Mage_Male";
    public const string WarriorFemale = "Warrior_Female";
    public const string WarriorMale = "Warrior_Male";

    //技能特效预制体
    //swl
    public const string HP = "HP";//加血
    public const string MP = "MP";//加蓝
    //战士
    public const string BloodSpray = "BloodSpray";//大吼
    public const string Crack = "Crack";//地裂斩
    public const string IceMake = "IceMake";//冰
    public const string Shock_Bomb = "ShockBomb";//爆炸
    //法师
    public const string MageAttack = "MageAttack";//普攻
    public const string Fire = "Fire";//地圈火
    public const string Ice = "Ice";//地圈冰
    public const string FireDragonRoll = "FireDragonRoll";//火龙卷风
    public const string MonsterRaids = "MonsterRaids";//召唤怪物攻击
    //射手
    public const string FireDragon = "FireDragon";//火龙
    public const string IceArrow = "IceArrow";//冰雨
    public const string MuzzleFlash = "MuzzleFlash";//普攻
    public const string Tonado_Electro = "TonadoElectro";//电龙卷风

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
