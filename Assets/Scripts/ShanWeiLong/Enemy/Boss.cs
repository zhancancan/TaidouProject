using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Transform player;
    private Rigidbody rig;
    private Animator anim;

    private float angleView = 30;   //视野范围
    private float attackDistance = 3;  //攻击距离
    private float playerDistance = 15;
    private float attackTime = 1;
    private float timer = 0;
    private float hp = 2000;
    private bool isAttack = false;

	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player").transform;
	    rig = GetComponent<Rigidbody>();
	    anim = GetComponent<Animator>();
	}
	
	
	void Update ()
	{
	    if (isAttack == true) return;
	    Vector3 playerPos = player.position;
        //将玩家的Y轴与Boss的Y轴同步
        playerPos.y = transform.position.y;
        //玩家与Boss前方的夹角
	    float angle = Vector3.Angle(playerPos - transform.position, transform.forward);
	    if (angle < angleView/2)
	    {
            //攻击视野之内
            float distance = Vector3.Distance(player.position, transform.position);
	        if (distance > playerDistance)
	        {
                anim.SetBool("Walk", false);
                return;
	        }
	        else
	        {
                if (distance < attackDistance)
                {
                    //攻击
                    if (isAttack == false)
                    {
                        timer += Time.deltaTime;
                        if (timer >= attackTime)
                        {
                            Attack();
                        }
                    }
                }
                else
                {
                    //追击
                    anim.SetBool("Walk", true);
                    transform.position += transform.forward*2f*Time.deltaTime;
                    //rig.MovePosition(transform.position + transform.forward * 2f * Time.deltaTime);
                }
	        }
        }
	    else
	    {
	        anim.SetBool("Walk", true);
            //Boss朝向
	        Quaternion targetRotation = Quaternion.LookRotation(playerPos - transform.position);
            //旋转
	        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 1f*Time.deltaTime);
	    }
	}

    private int index = 0;
    void Attack()
    {
        anim.SetBool("Walk", false);
        isAttack = true;
        index++;
        if (index == 4) index = 1;
        anim.SetTrigger("Attack0" + index);
    }

    void BackToIdle()
    {
        isAttack = false;
    }
}
