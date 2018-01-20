using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 0f;//人物的速度
    Animator _aim;//人物身上的动画控制器
    private void Awake()
    {
        _aim = this.GetComponent<Animator>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //1.移动
        Move();        
        //3.播放动画
        PlayAnimation(h,v);
    }
    private void Move()
    {
        float v = Input.GetAxis("Vertical");
        transform.position += transform.forward * v * Time.deltaTime * 3f;
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, h, 0) * 2f);
    }   
    private void PlayAnimation(float h, float v)
    {
        _aim.SetBool("Walk", h != 0 || v != 0);
        _aim.SetBool("Idle", h == 0 && v == 0);
    }   
}
