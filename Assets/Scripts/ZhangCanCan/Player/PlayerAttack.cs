using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerState state = PlayerState.ControlWalk;
    public PlayerAttackState attackState = PlayerAttackState.Idle;

    private PlayerStatus playerStatus;
    private PlayerDir playerDir;
    private PlayerMove playerMove;

    private GameObject player;
    private List<Renderer> pRenderList = new List<Renderer>();
    private List<Color> normalColorList = new List<Color>();
    private Dictionary<string, GameObject> skillEffectDictionary = new Dictionary<string, GameObject>();
    public Transform targetEnemy;
    public AudioClip missClip;
    private Animator animator;

    private Skill skilTemp; //在快捷键按下的时候，记录释放技能的信息

    private bool needGotoEnemy;
//    public bool isLockingTarget;
    private bool showEffect = false;

    public string anima_normalAttack;
    public string anima_idle;
    public string anima_now;
    public string anima_death;

    public float normalAttackTime;
    private float normalAttackRate;
    private float timer = 0;
    public float normalAttackMinDistance = 2;
    public float skillAttackMinDistance = 10;
//    public float minDistance = 10;
    private float missRate = 0.25f;

    private bool isSkillAttack = false;//是否从技能锁定状态中点击攻击
    private Vector3 skillReleasePos;//AOE技能释放位置

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
        playerDir = player.GetComponent<PlayerDir>();
        playerMove = player.GetComponent<PlayerMove>();
        playerStatus = player.GetComponent<PlayerStatus>();
        animator = GetComponent<Animator>();

        foreach (Transform temp in player.transform)
        {
            Renderer render = temp.GetComponent<MeshRenderer>();
            if (null != render)
            {
                pRenderList.Add(render);
                normalColorList.Add(render.material.color);
            }
        }
//        foreach (var skillEffectPrefab in skillEffectList)
//        {
//            skillEffectDictionary.Add(skillEffectPrefab.name, skillEffectPrefab);
//        }
    }

    void Start()
    {

    }

    //技能快捷键按下时调用
    public void UseSkill(Skill skill)
    {
        targetEnemy = null;
        skillReleasePos = Vector3.zero;
        switch (skill.applyType)
        {
            case ApplyType.Passive:
                StartCoroutine(UsePassiveSkill(skill));
                break;
            case ApplyType.Buff:
                StartCoroutine(UseBuffSkill(skill));
                break;
            case ApplyType.SingleTarget:
                skilTemp = skill;
                OnSingleTargetSkillUse(skill);
                break;
            case ApplyType.MultiTarget:
                skilTemp = skill;
                OnMultiTargetSkillUse(skill);
                break;
        }
    }

    //使用单体攻击技能，改变鼠标为锁定状态
    void OnSingleTargetSkillUse(Skill skill)
    {
        state = PlayerState.SkillAttack;
        CursorManager.Instance.SetCursorLookTarget();
//        isLockingTarget = true;
        this.skilTemp = skill;
    }

    //使用AOE技能，改变鼠标为锁定状态
    void OnMultiTargetSkillUse(Skill skill)
    {
        state = PlayerState.SkillAttack;
        CursorManager.Instance.SetCursorLookTarget();
//        isLockingTarget = true;
        this.skilTemp = skill;
    }

    void Update()
    {
        if (state == PlayerState.Death) return; //玩家死亡
        //射线检测是否点击到敌人,且不是在技能释放状态，根据检测的结果，对玩家的状态进行赋值
        if (Input.GetMouseButton(0) && state != PlayerState.SkillAttack)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            
            if (isCollider && hitInfo.collider.tag == Tags.Enemy)   //检测到敌人
            {
                print(1);
                targetEnemy = hitInfo.collider.transform;   //赋值敌人
                state = PlayerState.NormalAttack;   //控制状态设置为攻击
            }
            else
            {
                print(2);
                state = PlayerState.ControlWalk;    //控制状态设置为行走
                targetEnemy = null; //敌人置空
            }
        }

        #region MyRegion
        //根据玩家的状态，控制玩家的行为
        if (state == PlayerState.NormalAttack)  //控制状态设置为普通攻击
        {
            if (targetEnemy == null)    //敌人为空
            {
                print(3);
                state = PlayerState.ControlWalk;    //控制状态设置为行走
                return;
            }

            float distance = Vector3.Distance(transform.position, targetEnemy.position);    //玩家和敌人的距离
            Vector3 targetDirection = new Vector3(targetEnemy.position.x, transform.position.y,targetEnemy.position.z);   //人物方向
            transform.LookAt(targetDirection);  //玩家朝向敌人

            if (distance <= normalAttackMinDistance) //距离范围内，进行攻击
            {

                print(4);
                attackState = PlayerAttackState.Attack;  //攻击状态设置为攻击

                timer += Time.deltaTime;

//                anima.CrossFade(anima_now);

                if (timer > normalAttackTime)
                {
                    if (!showEffect)
                    {
//                        GameObject.Instantiate(skillEffect_slash, target_enemy.position, Quaternion.identity);
//                        targetEnemy.GetComponent<Wolf>().TakeDemage(characterSataus.attack); //产生伤害
                        showEffect = true;
                    }
                    anima_now = anima_idle;
                }

                normalAttackRate = playerStatus.attackSpeed;
                if (timer >= (1f / normalAttackRate))
                {
                    timer = 0;
                    showEffect = false;
                    anima_now = anima_normalAttack;
                }
            }
            else //走向敌人
            {
                print(5);
                attackState = PlayerAttackState.Moving; //攻击状态设置为移动
                //记录打怪的时候人物的位置，不然怪物打死的时候会跑回去，之前CharacterDir记录了人物初始的位置
                playerDir.targetPositon = transform.position;
                playerMove.SimpleMove(targetEnemy.position);
            }
        }
        else if (state == PlayerState.Death)
        {
            // anima.CrossFade(anima_death);
        }
        #endregion

//--------------------------------------------------------------------
        if (state == PlayerState.SkillAttack)//控制状态设置为技能攻击
        {
            print("111111111111111111111111");
//            if (isLockingTarget && Input.GetMouseButtonDown(0))
            if (Input.GetMouseButtonDown(0))
            {
                print("222222222222222222222222222");
//                isLockingTarget = false;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.CompareTag(Tags.Enemy))
                    {
                        print("333333333333333333333333333333333");
                        targetEnemy = hitInfo.collider.transform;
                        print(targetEnemy.position+ "targetEnemy");
                    }
                    else if (hitInfo.collider.CompareTag(Tags.Ground))
                    {
                        print("44444444444444444444444444444444444");
                        skillReleasePos = hitInfo.point;
                        print(skillReleasePos + "skillReleasePos");
                    }
                    isSkillAttack = true;
                }

            }
        }

        if (isSkillAttack)
        {
            print("55555555555555555555555555555555555");
            switch (skilTemp.applyType)
            {
                case ApplyType.SingleTarget:
                    print("66666666666666666666666666666");
                    CursorManager.Instance.SetCursorNormal();
                    if (targetEnemy!=null)
                    {
                        float distance1 = Vector3.Distance(transform.position, targetEnemy.position);    //玩家和点击地方距离
//                        Vector3 targetDirection1 = new Vector3(targetEnemy.position.x, transform.position.y, targetEnemy.position.z);   //人物方向
                        Vector3 targetDirection1 = new Vector3(skillReleasePos.x, transform.position.y, skillReleasePos.z);   //人物方向
                        transform.LookAt(targetDirection1);  //玩家朝向敌人

                        if (distance1 <= skillAttackMinDistance) //距离范围内，进行攻击
                        {
                            state = PlayerState.ControlWalk;
                            playerDir.targetPositon = transform.position;//记录打怪的时候人物的位置，不然怪物打死的时候会跑回去，之前CharacterDir记录了人物初始的位置
                            isSkillAttack = false;
                            attackState = PlayerAttackState.Attack;  //攻击状态设置为技能攻击
                            StartCoroutine(OnLockSingleTarget(targetEnemy)); //播放特效计算伤害等
                        }
                        else //走向敌人
                        {
                            attackState = PlayerAttackState.Moving; //攻击状态设置为移动
                            playerMove.SimpleMove(targetEnemy.position);
                        }
                    }
                    else
                    {
                        state = PlayerState.ControlWalk;//控制状态设置为行走
                        isSkillAttack = false;//是否技能攻击为false
                        targetEnemy = null; //敌人置空
                    }
                    break;
                case ApplyType.MultiTarget:
                    print("77777777777777777777777777777777777");
                    CursorManager.Instance.SetCursorNormal();
                    if (skillReleasePos != Vector3.zero)
                    {
                        print("8888888888888888888888888888888888888");
                        float distance = Vector3.Distance(transform.position, skillReleasePos);    //玩家和点击地方距离
                        Vector3 targetDirection = new Vector3(skillReleasePos.x, transform.position.y, skillReleasePos.z);   //人物方向
                        transform.LookAt(targetDirection);  //玩家朝向敌人

                        if (distance <= skillAttackMinDistance) //距离范围内，进行攻击
                        {
                            print("99999999999999999999999999999999");
                            playerDir.targetPositon = transform.position;//记录打怪的时候人物的位置，不然怪物打死的时候会跑回去，之前CharacterDir记录了人物初始的位置
                            state = PlayerState.ControlWalk;//当距离合适的时候，直接将控制状态变为移动，不然玩家在移动到攻击位置的时候，还是会播放移动动画
                            isSkillAttack = false;
                            attackState = PlayerAttackState.Attack;  //攻击状态设置为技能攻击
                            StartCoroutine(OnLockMultiTarget(skillReleasePos));
                        }
                        else //走向敌人
                        {
                            print("10101010101010101010101010101010");
                            attackState = PlayerAttackState.Moving; //攻击状态设置为移动
                            playerMove.SimpleMove(targetDirection);
                        }
                    }
                    else
                    {
                        print("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz");
                        state = PlayerState.ControlWalk;//控制状态设置为行走
                        isSkillAttack = false;//是否技能攻击为false
                        targetEnemy = null; //敌人置空
                    }
                    break;
                }
         }
    }

    //锁定目标，释放单体技能
    IEnumerator OnLockSingleTarget(Transform target)
    {
//        CursorManager.Instance.SetCursorAttack();//设置鼠标为攻击
        animator.SetBool(skilTemp.aniname, true);//播放技能动画
        yield return new WaitForSeconds(1);//等待动画结束播放
        PrefabManager.Instance.GetPrefabInstance(skilTemp.effectName, target.position, Quaternion.identity, targetEnemy);//播放感觉特效
//        hitInfo.collider.GetComponent<Wolf>().TakeDemage(characterSataus.attack * skilTemp.applyValue / 100f);
    }

    //锁定地点，释放AOE技能
    IEnumerator OnLockMultiTarget(Vector3 target)
    {
        print("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
        animator.SetBool(skilTemp.aniname, true);//播放技能动画
        yield return new WaitForSeconds(1);
        print("ccccccccccccccccccccccccccccccccccccccccccccccccc");
        PrefabManager.Instance.GetPrefabInstance(skilTemp.effectName, target, Quaternion.identity);//播放感觉特效
//        go.GetComponent<MagicSphere>().attack = characterSataus.attack * skilTemp.applyValue / 100f;
    }

    //使用增益技能
    IEnumerator UsePassiveSkill(Skill skill)
    {
        state = PlayerState.SkillAttack;
//        anima.CrossFade(skill.aniname);
        while (animator.GetCurrentAnimatorStateInfo(0).IsName(skill.aniname))
        {
            
        }
        yield return new WaitForSeconds(skill.anitime);
        if (targetEnemy == null)
            state = PlayerState.ControlWalk;
        else
            state = PlayerState.NormalAttack;

        int hp = 0, mp = 0;
        if (ApplyProperty.HP == skill.applyProperty)
        {
            hp = skill.applyValue;
            playerStatus.AddHpMp(hp, 0);
        }
        else if (ApplyProperty.MP == skill.applyProperty)
        {
            mp = skill.applyValue;
            playerStatus.AddHpMp(0, mp);
        }
        PrefabManager.Instance.GetPrefabInstance(skill.effectName, transform.position, Quaternion.identity,transform);
    }

    //使用buff技能
    IEnumerator UseBuffSkill(Skill skill)
    {
        state = PlayerState.SkillAttack;
//        anima.CrossFade(skill.aniname);
        yield return new WaitForSeconds(skill.anitime);
        if (targetEnemy==null)
            state = PlayerState.ControlWalk;
        else
            state = PlayerState.NormalAttack;
        
        switch (skill.applyProperty)
        {
            case ApplyProperty.Attack:
                playerStatus.attack *= skill.applyValue/100f;
                break;
            case ApplyProperty.Def:
                playerStatus.defeat *= skill.applyValue / 100f;
                break;
            case ApplyProperty.Speed:
                playerStatus.speed *= skill.applyValue / 100f;
                break;
            case ApplyProperty.AttackSpeed:  
                if (playerStatus.attackSpeed<=1)
                    playerStatus.attackSpeed *= skill.applyValue / 100f;
                else
                    playerStatus.attackSpeed = 1;
                break;
        }
        PrefabManager.Instance.GetPrefabInstance(skill.effectName, transform.position, Quaternion.identity,transform);
    }

    public void TakeDemage(float attackEnemy)
    {
        if (state == PlayerState.Death) return;
        float def = playerStatus.defeat + playerStatus.defeat_plus;
        float temp = attackEnemy * (10f / def);
        if (temp < 1) temp = 1;

        float miss_value = Random.Range(0, 1f);
        if (miss_value < 0.25)
        {
            AudioSource.PlayClipAtPoint(missClip, transform.position);
            //            hudText.Add("miss", Color.gray, 1f);
        }
        else
        {
            playerStatus.hp -= (int)temp;
            //            hudText.Add(temp.ToString(), Color.red, 1f);
            StartCoroutine(ShowRedAttacked());
            if (playerStatus.hp < 0)
            {
//                anima.CrossFade(anima_death);
                state = PlayerState.Death;
            }
        }
    }

    //玩家受到攻击的时候变色
    IEnumerator ShowRedAttacked()
    {
        foreach (Renderer temp in pRenderList)
        {
            temp.material.color = Color.red;
        }
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < normalColorList.Count; i++)
        {
            pRenderList[i].material.color = normalColorList[i];
        }
    }
}
