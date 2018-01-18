using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    //没遇见敌人
    bool NoMeetEnemy = true;
    //宠物是否攻击
    bool IsPetAtk = true;


    private void Start()
    {
        //获取英雄对象
        hero = GameObject.FindGameObjectWithTag("Player");
        //获取敌人对象
        //获取动画组件
        petAnim = this.GetComponent<Animator>();
     
    }

    private void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        //如果找到英雄对象
        if (hero != null)
        {
            //如果没遇到敌人
            if (NoMeetEnemy)
            {
                //宠物与英雄距离超过一定距离后，宠物开始向英雄移动
                if (Vector3.Distance(hero.transform.position, transform.position) > 4f)
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
            if (enemy != null)
            {

                //}
                //如果宠物攻击
                if (IsPetAtk)
                {
                    //如果英雄与敌人距离小于1
                    if (Vector3.Distance(hero.transform.position, enemy.transform.position) <= 3f)
                    {
                        petAnim.SetBool("Run", false);
                        //宠物自动寻路到宠物本身位置
                        transform.position = Vector3.Lerp(transform.position,
                            new Vector3(hero.transform.position.x - 2, hero.transform.position.y, hero.transform.position.z - 2), Time.deltaTime * speed);
                        //遇见敌人
                        NoMeetEnemy = false;
                        //播放攻击动画
                        petAnim.SetBool("Atk", true);
                    }
                    //如果英雄与敌人距离在3~8之间
                    if (Vector3.Distance(hero.transform.position, enemy.transform.position) >= 3f &&
                        Vector3.Distance(hero.transform.position, enemy.transform.position) <= 8f)
                    {
                        //宠物移动到敌人位置                   
                        transform.position = Vector3.Lerp(transform.position, 
                            new Vector3(enemy.transform.position.x - 1.5f, enemy.transform.position.y, enemy.transform.position.z - 1.5f), Time.deltaTime * speed);
                        //检测到敌人
                        NoMeetEnemy = false;
                        //播放移动动画
                        petAnim.SetBool("Run", true);
                        //宠物朝向敌人
                        transform.LookAt(enemy.transform.position);
                    }
                    //如果英雄与敌人距离大于5
                    if (Vector3.Distance(hero.transform.position, enemy.transform.position) > 5f)
                    {
                        //检测不到敌人
                        NoMeetEnemy = true;
                        //关闭攻击动画
                        petAnim.SetBool("Atk", false);

                    }
                    //当宠物与敌人间距小于3时，播放攻击动画并且停止移动动画
                    if (Vector3.Distance(transform.position, enemy.transform.position) < 3f)
                    {
                        petAnim.SetBool("Run", false);
                        petAnim.SetBool("Atk", true);
                    }
                }
            }
        }
    }
    //宠物移动到英雄位置的方法
    void PetToMove()
    {
        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(hero.transform.position.x-2, hero.transform.position.y, hero.transform.position.z-2), Time.deltaTime * speed);
    }
}

