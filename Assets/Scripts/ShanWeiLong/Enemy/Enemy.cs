using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private CharacterController cc;
    private int hp = 200;
    private int hpTotal = 0;  //记录血量
    private int attackRate = 2;  //攻击速率
    private int damage = 20;  //攻击力
    private float playerDistance = 15;   //人物跟怪物的距离
    private float attackDistance = 2;
    private float distance = 0;
    private float attackTimer = 0; //计时

    private Animation anim;

    private GameObject bloodBar;
    private GameObject bloodGo;
    private Slider bloodSlider;

    void Start ()
	{
        hpTotal = hp;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cc = GetComponent<CharacterController>();
	    anim = GetComponent<Animation>();
	    InvokeRepeating("CalcDistance", 0, 0.1f);
        bloodBar = Resources.Load<GameObject>("BloodBg");
	    Transform bloodPoint = transform.Find("BloodPoint");
	    bloodSlider = bloodBar.transform.Find("Blood").GetComponent<Slider>();
        bloodGo = Instantiate(bloodBar, bloodPoint.position, Quaternion.identity);
	    bloodGo.transform.parent = bloodPoint;
	}
	
	
	void Update ()
	{
        if (hp <= 0)
	    {
	        transform.Translate(-transform.up*1f*Time.deltaTime);
	        Destroy(gameObject, 3);
	        return;
	    }
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > playerDistance)
	    {
	        return;
	    }
	    else
	    {
	        if (distance < attackDistance)
	        {
	            attackTimer += Time.deltaTime;
	            if (attackTimer > attackRate)
	            {
                    Vector3 targetPos = player.position;
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

    void CalcDistance()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
    }

    void Move()
    {
        Vector3 targetPos = player.position;
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

    void Attack()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < attackDistance)
        {
            player.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }

    void Dead()
    {
        anim.Play("die");
    }
}
