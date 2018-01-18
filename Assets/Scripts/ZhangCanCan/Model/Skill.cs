using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill {

    public int id;
    public string name;
    public string iconName;
    public string des;
    public ApplyType applyType;
    public ApplyProperty applyProperty;
    public int applyValue;
    public int applyTime;
    public int mp;
    public int coldTime;
    public ApproRole approRole;
    public int level;
    public ReleaseType releaseType;
    public float distance;
    public string efx_name;
    public string aniname;
    public float anitime = 0;

    public Skill(int id, string name, string iconName, string des, ApplyType applyType,
        ApplyProperty applyProperty, int applyValue, int applyTime, int mp, int coldTime,
        ApproRole approRole, int level, ReleaseType releaseType, float distance, string efx_name, string aniname, float anitime)
    {
        this.id = id;
        this.name = name;
        this.iconName = iconName;
        this.des = des;
        this.applyType = applyType;
        this.applyProperty = applyProperty;
        this.applyValue = applyValue;
        this.applyTime = applyTime;
        this.mp = mp;
        this.coldTime = coldTime;
        this.approRole = approRole;
        this.level = level;
        this.releaseType = releaseType;
        this.distance = distance;
        this.efx_name = efx_name;
        this.aniname = aniname;
        this.anitime = anitime;
    }

    public override string ToString()
    {
        return string.Format("Id: {0}, Name: {1}, IconName: {2}, Des: {3}, ApplyType: {4}, ApplyProperty: {5}, " +
                             "ApplyValue: {6}, ApplyTime: {7}, Mp: {8}, ColdTime: {9}, ApproRole: {10}, Level: {11}," +
                             " ReleaseType: {12}, Distance: {13}, EfxName: {14}, Aniname: {15}, Anitime: {16}",
            id, name, iconName, des, applyType, applyProperty, applyValue, applyTime, mp, coldTime,
            approRole, level, releaseType, distance, efx_name, aniname, anitime);
    }
}
