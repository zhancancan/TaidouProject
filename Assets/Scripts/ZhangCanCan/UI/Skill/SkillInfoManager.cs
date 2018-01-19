using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SkillInfoData
{
    private static SkillInfoData _instance;
    private SkillInfoData()
    {
        ReadSkillInfo();
    }
    public static SkillInfoData GetInstance()
    {
        if (null == _instance)
        {
            _instance = new SkillInfoData();
        }
        return _instance;
    }

    private Dictionary<int,Skill> skillDictionary = new Dictionary<int,Skill>();    //id，技能，字典

    public List<int> warriorSkillIdArr = new List<int>();   //战士技能Id
    public List<int> mageSkillIdArr = new List<int>();      //法师技能Id
    public List<int> archerSkillIdArr = new List<int>();    //射手技能Id

    //获取技能
    public Skill GetSkillInfoById(int id)
    {
        Skill skill;
        skillDictionary.TryGetValue(id, out skill);
        return skill;
    }

    //读取技能信息
   public void ReadSkillInfo()
    {
        TextAsset skillAsset = Resources.Load("ZhangCanCan/Txt/SkillInfo", typeof(TextAsset)) as TextAsset;
        Skill skill;
        //Debug.Log(skillAsset);
        string str = skillAsset.text;
        string tempStr = str.Replace("\r\n", "\n");
        string[] skillInfoList = tempStr.Split('\n');
        for (int i = 1; i < skillInfoList.Length-1; i++)
        {
            string[] skillInfo = skillInfoList[i].Split(',');
            //技能类型
            ApplyType applyTypeTemp = 0;
            switch (skillInfo[4].Trim())
            {
                case "Passive":
                    applyTypeTemp = ApplyType.Passive;
                    break;
                case "Buff":
                    applyTypeTemp = ApplyType.Buff;
                    break;
                case "SingleTarget":
                    applyTypeTemp = ApplyType.SingleTarget;
                    break;
                case "MultiTarget":
                    applyTypeTemp = ApplyType.MultiTarget;
                    break;
            }
            //应用属性
            ApplyProperty applyPropertyTemp = 0;
            switch (skillInfo[5].Trim())
            {
                case "HP":
                    applyPropertyTemp = ApplyProperty.HP;
                    break;
                case "MP":
                    applyPropertyTemp = ApplyProperty.MP;
                    break;
                case "Attack":
                    applyPropertyTemp = ApplyProperty.Attack;
                    break;
                case "Def":
                    applyPropertyTemp = ApplyProperty.Def;
                    break;
                case "Speed":
                    applyPropertyTemp = ApplyProperty.Speed;
                    break;
                case "AttackSpeed":
                    applyPropertyTemp = ApplyProperty.AttackSpeed;
                    break;
            }
            //适合角色
            ApproRole approRoleTemp = 0;
            switch (skillInfo[10].Trim())
            {
                case "Magician":
                    approRoleTemp = ApproRole.Magician;
                    mageSkillIdArr.Add(int.Parse(skillInfo[0].Trim()));
                    break;
                case "Swordman":
                    approRoleTemp = ApproRole.Swordman;
                    warriorSkillIdArr.Add(int.Parse(skillInfo[0].Trim()));
                    break;
                case "":
                    archerSkillIdArr.Add(int.Parse(skillInfo[0].Trim()));
                    break;
            }
            //释放类型
            ReleaseType releaseTypeTemp = 0;
            switch (skillInfo[12].Trim())
            {
                case "Self":
                    releaseTypeTemp = ReleaseType.Self;
                    break;
                case "Enemy":
                    releaseTypeTemp = ReleaseType.Enemy;
                    break;
                case "Position":
                    releaseTypeTemp = ReleaseType.Position;
                    break;
            }
            skill = new Skill(int.Parse(skillInfo[0].Trim()),skillInfo[1].Trim(),skillInfo[2].Trim(),skillInfo[3].Trim(),applyTypeTemp,applyPropertyTemp,int.Parse(skillInfo[6].Trim()),
                int.Parse(skillInfo[7].Trim()), int.Parse(skillInfo[8].Trim()), int.Parse(skillInfo[9].Trim()),approRoleTemp,
                int.Parse(skillInfo[11].Trim()),releaseTypeTemp, float.Parse(skillInfo[13].Trim()),skillInfo[14].Trim(),skillInfo[15].Trim(),float.Parse(skillInfo[16].Trim()));
            skillDictionary.Add(skill.id,skill);
            //print(skill.ToString());
        }
    }

}

