using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

    public static SkillManager _instance;

    public TextAsset skillInfoText;

    ArrayList skillList = new ArrayList();

    private void Awake()
    {
        _instance = this;
        InitSkill();
    }

    void InitSkill()
    {
        string[] skillArray = skillInfoText.ToString().Split('\n');
        foreach (string str in skillArray)
        {
            string[] proArray = str.Split(',');
            Skill skill = new Skill();
            skill.Id = int.Parse(proArray[0]);
            skill.Name = proArray[1];
            string path = proArray[2];
            skill.Icon = Resources.Load(path, typeof(Sprite)) as Sprite;
            //switch (proArray[3])
            //{
            //    case "Warrior":

            //        break;
            //    case "FemaleAssassin":
            //        break;     
            //}
            switch (proArray[4])
            {
                case "Basic":
                    skill.SkillType = SkillType.Basic;
                    break;
                case "Skill":
                    skill.SkillType = SkillType.Skill;
                    break;
            }
            switch (proArray[5])
            {
                case "Baisc":
                    skill.PosType = PosType.Basic;
                    break;
                case "One":
                    skill.PosType = PosType.One;
                    break;
                case "Two":
                    skill.PosType = PosType.Two;
                    break;
                case "Three":
                    skill.PosType = PosType.Three;
                    break;
                case "Four":
                    skill.PosType = PosType.Four;
                    break;
                case "Five":
                    skill.PosType = PosType.Five;
                    break;
            }
            skill.ColdTime = int.Parse(proArray[6]);
            skill.Damage = int.Parse(proArray[7]);
            skill.Level = 1;
            skillList.Add(skill);
        }
    }

    public Skill GetSkillByPosition(PosType posType)
    {
        //PlayerInfo info = PlayerInfo._instance;
        foreach (Skill skill in skillList)
        {
            //if (skill.PosType == posType && skill.PlayerType == info.PlayerType)
            //{
            //    return skill;
            //}
        }
        return null;
    }

}
