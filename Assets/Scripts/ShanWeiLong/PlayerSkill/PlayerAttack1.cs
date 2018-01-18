using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack1 : MonoBehaviour {

    Dictionary<string, PlayerEffect> effectDic = new Dictionary<string, PlayerEffect>();
    PlayerEffect[] effectArray;

    PlayerEffect BloodSpray;
    PlayerEffect Crack;
    PlayerEffect Fire;
    PlayerEffect FireDragon;
    PlayerEffect FireDragonRoll;
    PlayerEffect Ice;
    PlayerEffect IceArrow;
    PlayerEffect IceMake;
    PlayerEffect MageAttack;
    PlayerEffect MonsterRaids;
    PlayerEffect MuzzleFlash;
    PlayerEffect Shock_Bomb;
    PlayerEffect Tonado_Electro;

    Animator animPlay;

    private void Awake()
    {
        BloodSpray = Resources.Load<PlayerEffect>(ConstDates.ResourceEffectPrefabDirSwl + ConstDates.BloodSpray);
        Crack = Resources.Load<PlayerEffect>(ConstDates.ResourceEffectPrefabDirSwl + ConstDates.Crack);
        Fire = Resources.Load<PlayerEffect>(ConstDates.ResourceEffectPrefabDirSwl + ConstDates.Fire);
        FireDragon = Resources.Load<PlayerEffect>(ConstDates.ResourceEffectPrefabDirSwl + ConstDates.FireDragon);
        FireDragonRoll = Resources.Load<PlayerEffect>(ConstDates.ResourceEffectPrefabDirSwl + ConstDates.FireDragonRoll);
        Ice = Resources.Load<PlayerEffect>(ConstDates.ResourceEffectPrefabDirSwl + ConstDates.Ice);
        IceArrow = Resources.Load<PlayerEffect>(ConstDates.ResourceEffectPrefabDirSwl + ConstDates.IceArrow);
        IceMake = Resources.Load<PlayerEffect>(ConstDates.ResourceEffectPrefabDirSwl + ConstDates.IceMake);
        MageAttack = Resources.Load<PlayerEffect>(ConstDates.ResourceEffectPrefabDirSwl + ConstDates.MageAttack);
        MonsterRaids = Resources.Load<PlayerEffect>(ConstDates.ResourceEffectPrefabDirSwl + ConstDates.MonsterRaids);
        MuzzleFlash = Resources.Load<PlayerEffect>(ConstDates.ResourceEffectPrefabDirSwl + ConstDates.MuzzleFlash);
        Shock_Bomb = Resources.Load<PlayerEffect>(ConstDates.ResourceEffectPrefabDirSwl + ConstDates.Shock_Bomb);
        Tonado_Electro = Resources.Load<PlayerEffect>(ConstDates.ResourceEffectPrefabDirSwl + ConstDates.Tonado_Electro);
        effectArray = new PlayerEffect[] { BloodSpray , Crack , Fire , FireDragon , FireDragonRoll , Ice ,
                                         IceArrow,IceMake,MageAttack,MonsterRaids,MuzzleFlash,Shock_Bomb,Tonado_Electro
                                        };
    }

    private void Start()
    {
        PlayerEffect[] peArray = GetComponentsInChildren<PlayerEffect>();
        foreach (PlayerEffect pe in peArray)
        {
            effectDic.Add(pe.gameObject.name, pe);
        }
        foreach (PlayerEffect pe in effectArray)
        {
            effectDic.Add(pe.gameObject.name, pe);
        }
        animPlay = GetComponent<Animator>();
    }

    //0 普通攻击，技能1，2，3
    //1 特效名
    //2 声音
    //3 技能产生的位移
    //4 技能跳跃的高度
    void Attack(string args)
    {
        string[] proArray = args.Split(',');
        //1.展示特效
        string effectName = proArray[1];
        ShowPlayerEffect(effectName);
        //2.播放声音

        //3.位移 前冲的效果
        float moveForword = float.Parse(proArray[3]);
        if (moveForword > 0.1f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }
        else if(moveForword < -0.1f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
        }
    }

    //自身特效
    void ShowPlayerEffect(string effectName)
    {
        PlayerEffect pe;
        //根据Key获取关联的值，如果取到返回true，否则返回flase
        if(effectDic.TryGetValue(effectName,out pe))
        {
            pe.Show();
        }
    }

    //恶魔之手
    void ShowEffectDevilHand()
    {
        string effectName = "DevilHandMobile";
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        Instantiate(pe, new Vector3(transform.position.x, transform.position.y, transform.position.z + 3), Quaternion.identity);
        //ArrayList array = GetEnemyInAttackRange();//枚举值攻击方向
        //foreach (GameObject go in array)
        //{
        //    RaycastHit hit;
        //    bool collider = Physics.Raycast(go.transform.position + Vector3.up, Vector3.down, out hit, 10f, LayerMask.GetMask(""));
        //    if (collider)
        //    {
        //        Instantiate(pe, hit.point, Quaternion.identity);
        //    }
        //}
    }

    #region  战士技能特效
    //血喷
    void ShowBloodSpray(string effectName)
    {
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        Instantiate(pe,transform.position,Quaternion.identity);
        //goEffect.GetComponent<EffectSettings>().Target = ;
        //ArrayList array = GetEnemyInAttackRange();  //枚举值攻击方向
        //foreach (GameObject go in array)
        //{
        //   
        //}
    }

    //冰
    void ShowIceMake(string effectName)
    {
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        Instantiate(pe, new Vector3(transform.position.x, transform.position.y, transform.position.z + 5), Quaternion.identity);
    }

    //震
    void ShowShockBomb(string effectName)
    {
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        Instantiate(pe, new Vector3(transform.position.x, transform.position.y, transform.position.z + 5), Quaternion.identity);
    }

    //地裂
    void ShowCrack(string effectName)
    {
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        GameObject go = (Instantiate(pe, new Vector3(transform.position.x, transform.position.y, transform.position.z + 8), Quaternion.Euler(0, -90, 0)) as PlayerEffect).gameObject;
        Destroy(go, 5);
    }
    #endregion

    #region 法师技能特效
    //法师普攻
    void ShowMageAttack(string effectName)
    {
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        GameObject go = (Instantiate(pe, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity) as PlayerEffect).gameObject;
        Destroy(go, 5);
    }

    //冰火
    void ShowFire(string effectName)
    {
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        GameObject go = (Instantiate(pe, transform.position, Quaternion.identity) as PlayerEffect).gameObject;
        Destroy(go, 10);
    }

    void ShowIce(string effectName)
    {
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        GameObject go = (Instantiate(pe,transform.position, Quaternion.identity) as PlayerEffect).gameObject;
        Destroy(go, 5);
    }

    //火龙卷 
    void ShowFireDragonRoll(string effectName)
    {
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        GameObject go = (Instantiate(pe, new Vector3(transform.position.x, transform.position.y, transform.position.z + 5), Quaternion.identity) as PlayerEffect).gameObject;
        Destroy(go, 10);
    }

    //怪兽突袭 
    void ShowMonsterRaids(string effectName)
    {
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        GameObject go = (Instantiate(pe,transform.position, Quaternion.identity) as PlayerEffect).gameObject;
        Destroy(go, 10);
    }
    #endregion

    #region 弓箭手技能特效
    //弓手普攻
    void ShowBiu(string effectName)
    {
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        Instantiate(pe, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 0.5f), Quaternion.identity);
    }

    //电光龙卷 
    void ShowTonadoElectro(string effectName)
    {
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        GameObject go = (Instantiate(pe, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), Quaternion.identity) as PlayerEffect).gameObject;
        go.AddComponent<Rigidbody>().useGravity = false;
        go.GetComponent<Rigidbody>().velocity = transform.forward * 2f;
    }

    //火龙出世
    void ShowFireDragon(string effectName)
    {
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        GameObject go = (Instantiate(pe, new Vector3(transform.position.x, transform.position.y, transform.position.z + 5), Quaternion.identity) as PlayerEffect).gameObject;
        Destroy(go, 6);
    }

    //冰箭雨 
    void ShowIceArrow(string effectName)
    {
        PlayerEffect pe;
        effectDic.TryGetValue(effectName, out pe);
        for (int i = 0; i <= 5; i++)
        {
           Instantiate(pe,
           new Vector3(
               Random.Range(transform.position.x - 3, transform.position.x + 3),
               0,
               Random.Range(transform.position.z + 4, transform.position.z + 10)
               ), Quaternion.Euler(-90,0,0));
        }
    }
    #endregion

    //周围敌人
    //ArrayList GetEnemyInAttackRange()
    //{

    //}

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        animPlay.SetTrigger("Attack");
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        animPlay.SetTrigger("Skill1");
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        animPlay.SetTrigger("Skill2");
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        animPlay.SetTrigger("Skill3");
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha4))
    //    {
    //        animPlay.SetTrigger("Skill4");
    //    }
    //}
}
