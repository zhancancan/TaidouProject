using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public RoleType roleType = RoleType.Mage;

    public int level = 0;
    public float hp;
    public float hpMax;
    public float mp;
    public float mpMax;
    public float attack;
    public float attack_plus;
    public float defeat;
    public float defeat_plus;
    public float speed;
    public float speed_plus;
    public float attackSpeed;
    

    public void AddHpMp(int hp,int mp)
    {
        if (0 != hp)
        {
            this.hp += hp;
            if (this.hp>hpMax) this.hp = hpMax;
        }
        if (0 != mp)
        {
            this.mp += mp;
            if (this.mp > mpMax) this.mp = mpMax;
        }
    }
}
