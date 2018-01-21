using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private GameObject pet;
    private GameObject target;
    private Vector3 enemyPos;
    private CharacterController cc;
    private int hp = 200;
    private int hpTotal = 0;  //记录血量
    private int attackRate = 2;  //攻击速率
    private int damage = 20;  //攻击力
    private float playerDistance = 15;   //人物跟怪物的距离
    private float attackDistance = 2;    //攻击距离
    private float distance = 0;          
    private float attackTimer = 0; //计时

    private Animation anim;

    Animator Lion;

    private GameObject bloodBar;   //血条
    private GameObject bloodGo;    //生成的血条
    private Slider bloodSlider;

    void Start ()
    {
        enemyPos = transform.position;
        hpTotal = hp;
        player = GameObject.FindGameObjectWithTag(Tags.Player);
        pet = GameObject.FindGameObjectWithTag(Tags.Pet);
        cc = GetComponent<CharacterController>();
	    anim = GetComponent<Animation>();
	    InvokeRepeating("PlayerOrPet", 0, 0.1f);
        bloodBar = Resources.Load<GameObject>("ShanWeiLong/Prefabs/Enemys/BloodBg");
	    Transform bloodPoint = transform.Find("BloodPoint");
	    bloodSlider = bloodBar.transform.Find("Blood").GetComponent<Slider>();
        bloodGo = Instantiate(bloodBar, bloodPoint.position, Quaternion.identity);
	    bloodGo.transform.parent = bloodPoint;

        Lion = GameObject.Find("Lion").GetComponent<Animator>();

    }
	
	
	void Update ()
	{
        if (hp <= 0)
	    {
	        transform.Translate(-transform.up*1f*Time.deltaTime);
	        Destroy(gameObject, 3);
	        return;
	    }
	    PlayerOrPet();
        if (distance > playerDistance)
        {
            if (Vector3.Distance(transform.position, enemyPos) <= 0.1f)
            {
                anim.CrossFade("idle");
            }
            else
            {
                transform.LookAt(enemyPos);
                transform.position += transform.forward * 1f * Time.deltaTime;
                anim.Play("walk");
            }
        }
	    else 
	    {
	        if (distance < attackDistance)
	        {
	            attackTimer += Time.deltaTime;
	            if (attackTimer > attackRate)
	            {
	                PlayerOrPet();
                    Vector3 targetPos = target.transform.position;
                    targetPos.y = transform.position.y;
                    transform.LookAt(targetPos);
                    //攻击
                    anim.Play("attack01");
                    attackTimer = 0;
                }
                if (!anim.Play("attack01"))
                {
                    anim.CrossFade("idle");
                }
	        }
	        else
	        {
	            anim.Play("walk");
                Move();
            }
	    }
	    bloodGo.transform.LookAt(Camera.main.transform.position);
	}

    //void CalcDistance()
    //{
    //    PlayerOrPet();
    //}

    void Move()
    {
        PlayerOrPet();
        Vector3 targetPos = target.transform.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
        cc.SimpleMove(transform.forward*1f);
    }

    void TakeDamage()
    {
        if (hp <= 0) return;
        //受到伤害
        bloodSlider.value = (float) hp/hpTotal;
        anim.Play("takedamage");
        if (hp <= 0)
        {
            Dead();
        }
    }

    void PlayerOrPet()
    {
        //找宠物
        if (Vector3.Distance(pet.transform.position, transform.position) < playerDistance)
        {
            target = pet;
        }
        //找玩家
        if (Vector3.Distance(player.transform.position, transform.position)<playerDistance)
        {
            target = player;
        }
        if (target == player || target == pet)
        {
            distance = Vector3.Distance(target.transform.position, transform.position);
        }
    }

    //void Attack()
    //{
    //    distance = Vector3.Distance(player.transform.position, transform.position);
    //    if (distance < attackDistance)
    //    {
    //        player.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
    //    }
    //}

    void Dead()
    {
        anim.Play("die");
    }
}
