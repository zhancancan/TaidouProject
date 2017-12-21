using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetMoveAndAttack : MonoBehaviour
{

    //英雄
    GameObject hero;
    //敌人
    GameObject enemy;
    //移动速度
    public float speed = 1.0f;
    //宠物动画组件
    Animator petAnim;
    //自动寻路组件
    private NavMeshAgent petAgent;

    //没遇见敌人
    bool NoMeetEnemy = true;
    //宠物是否攻击
    bool IsPetAtk = true;


    private void Start()
    {
        //获取英雄对象
        hero = GameObject.FindGameObjectWithTag("Hero");
        //获取敌人对象
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        //获取动画组件
        petAnim = this.GetComponent<Animator>();
        //获取自动寻路组件
        petAgent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //如果找到英雄对象
        if (hero != null)
        {
            //如果没遇到敌人
            if (NoMeetEnemy)
            {
                //宠物与英雄距离超过一定距离后，宠物开始向英雄移动
                if (Vector3.Distance(hero.transform.position, transform.position) > 5f)
                {
                    //调用宠物移动方法
                    PetToMove();
                    //播放宠物移动动画
                    petAnim.SetBool("Run", true);
                }
                else
                {
                    //关闭宠物移动动画
                    petAnim.SetBool("Run", false);
                }
                //宠物朝向英雄
                transform.LookAt(hero.transform.position);
            }
            //如果宠物攻击
            if (IsPetAtk)
            {
                //如果宠物与敌人距离小于1
                if (Vector3.Distance(transform.position, enemy.transform.position) <= 1f)
                {
                    //宠物自动寻路到宠物本身位置
                    petAgent.SetDestination(transform.position);
                    //关闭攻击循环
                    IsPetAtk = false;
                    //播放攻击动画
                    petAnim.SetBool("Atk", true);
                }
                //如果宠物与敌人距离在1~5之间
                if (Vector3.Distance(transform.position, enemy.transform.position) >= 1f &&
                    Vector3.Distance(transform.position, enemy.transform.position) <= 5f)
                {
                    //宠物自动寻路到敌人位置
                    petAgent.SetDestination(enemy.transform.position);
                    //关闭攻击循环
                    IsPetAtk = false;
                    //播放移动动画
                    petAnim.SetBool("Run", true);
                }
                //如果宠物与敌人距离大于5
                if (Vector3.Distance(transform.position, enemy.transform.position) > 5f)
                {
                    //调用宠物移动函数
                    PetToMove();
                    //播放移动动画
                    petAnim.SetBool("Run", true);
                }
            }
            //强制宠物跟随英雄
            if (Input.GetKeyDown(KeyCode.M))
            {
                IsPetAtk = false;
                NoMeetEnemy = true;
            }
            //强制宠物攻击敌人
            if (Input.GetKeyDown(KeyCode.A))
            {
                IsPetAtk = true;
                NoMeetEnemy = false;
            }
        }
    }
    //宠物移动到英雄位置的方法
    void PetToMove()
    {
        transform.position = Vector3.Lerp(transform.position, hero.transform.position, Time.deltaTime * speed);
    }
}

