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
    public bool isLockingTarget;
    private bool showEffect = false;

    public string anima_normalAttack;
    public string anima_idle;
    public string anima_now;
    public string anima_death;

    public float normalAttackTime;
    private float normalAttackRate;
    private float timer = 0;
    public float minDistance = 5;
    private float missRate = 0.25f;

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

    void Update()
    {
        if (state == PlayerState.Death) return; //玩家死亡
        //射线检测是否点击到敌人,且不是在技能释放状态，根据检测的结果，对玩家的状态进行赋值
        if (Input.GetMouseButton(0) && !isLockingTarget)
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
        
        //根据玩家的状态，控制玩家的行为
        if (state == PlayerState.NormalAttack)  //控制状态设置为攻击
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

            if (distance <= minDistance) //距离范围内，进行攻击
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

        if (isLockingTarget && Input.GetMouseButtonDown(0))
        {
            OnLockTarget();
            OnLockMultiTarget();
        }
    }

    //当UseSkill技能键按下的时候，改变鼠标为锁定状态，这时候等待锁定目标后，执行技能攻击
    void OnLockTarget()
    {
        print(6);
        isLockingTarget = false;
        switch (skilTemp.applyType)
        {
            case ApplyType.SingleTarget:
                StartCoroutine(OnLockSingleTarget());
                break;
            case ApplyType.MultiTarget:
                StartCoroutine(OnLockMultiTarget());
                break;
        }
    }

    //锁定目标，释放单体技能
    IEnumerator OnLockSingleTarget()
    {
        print(7);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.tag == Tags.Enemy)
            {
                print(8);
                CursorManager.Instance.SetCursorAttack();
//                anima.CrossFade(skilTemp.aniname);
                yield return new WaitForSeconds(skilTemp.anitime);
                //isLockingTarget = false;
                state = PlayerState.NormalAttack;
                print(9);
                GameObject skillEffPrefab = null;
                skillEffectDictionary.TryGetValue(skilTemp.efx_name, out skillEffPrefab);
                if (hitInfo.collider != null)
                    Instantiate(skillEffPrefab, hitInfo.collider.transform.position, Quaternion.identity);

//                hitInfo.collider.GetComponent<Wolf>().TakeDemage(characterSataus.attack * skilTemp.applyValue / 100f);
            }
            else
            {
                print(10);
                state = PlayerState.ControlWalk;
                CursorManager.Instance.SetCursorNormal();
            }
        }
    }

    //锁定地点，释放AOE技能
    IEnumerator OnLockMultiTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo = new RaycastHit();
        bool isColider = Physics.Raycast(ray, out hitInfo);
        if (isColider && hitInfo.collider.CompareTag(Tags.Ground))
        {
            CursorManager.Instance.SetCursorNormal();
//            anima.CrossFade(skilTemp.aniname);
            yield return new WaitForSeconds(skilTemp.anitime);
            //isLockingTarget = false;
            state = PlayerState.ControlWalk;

            GameObject skillEffPrefab = null;
            skillEffectDictionary.TryGetValue(skilTemp.efx_name, out skillEffPrefab);
            if (hitInfo.collider != null)
            {
                GameObject go = Instantiate(skillEffPrefab, hitInfo.point + Vector3.up, Quaternion.identity) as GameObject;
//                go.GetComponent<MagicSphere>().attack = characterSataus.attack * skilTemp.applyValue / 100f;
            }
        }
        else
        {
            state = PlayerState.ControlWalk;
            CursorManager.Instance.SetCursorNormal();
        }
    }

    //技能快捷键按下时调用
    public void UseSkill(Skill skill)
    {
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
        isLockingTarget = true;
        this.skilTemp = skill;
    }

    //使用AOE技能，改变鼠标为锁定状态
    void OnMultiTargetSkillUse(Skill skill)
    {
        state = PlayerState.SkillAttack;
        CursorManager.Instance.SetCursorLookTarget();
        isLockingTarget = true;
        this.skilTemp = skill;
    }

    //使用增益技能
    IEnumerator UsePassiveSkill(Skill skill)
    {
        state = PlayerState.SkillAttack;
//        anima.CrossFade(skill.aniname);
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

        GameObject skillEffPrefab = null;
        skillEffectDictionary.TryGetValue(skill.efx_name, out skillEffPrefab);
        Instantiate(skillEffPrefab, transform.position, Quaternion.identity);
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

        GameObject skillEffPrefab = null;
        skillEffectDictionary.TryGetValue(skill.efx_name, out skillEffPrefab);
        Instantiate(skillEffPrefab, transform.position, Quaternion.identity);
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
