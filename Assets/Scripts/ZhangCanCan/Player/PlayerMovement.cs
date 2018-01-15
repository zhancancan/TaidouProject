using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 0f;//人物的速度
    Vector3 _moment; //移动方向
    Rigidbody _rig;//人物身上的刚体
    Animator _aim;//人物身上的动画控制器

    int _floorMask;//地板的层号
    public float maxCamRayLength = 1000f;//相机发射射线的最大长度

    private void Awake()
    {
        //获取地板层号，为了检测射线碰撞
        _floorMask = LayerMask.GetMask("Wall");
        _rig = this.GetComponent<Rigidbody>();
        _aim = this.GetComponent<Animator>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //1.移动
        Move(h, v);
        //2.旋转
        Turning();
        //3.播放动画
        PlayAnimation(h,v);
    }
    private void Move(float h, float v)
    {
        _moment.Set(h, 0, v);
        //这里的归一化是为了在电脑上处理向量的时候的统一性
        //如果向量带有长度，那么CPU在计算的时候会根据自己的性能产生不一样的时间（配置高速度越快）
        //归一化的目的就是保证无论什么配置在处理单位向量的时候，速度是一致的
        _moment = _moment.normalized * speed * Time.deltaTime;
        _rig.MovePosition(transform.position + _moment);
    }
    public void Turning()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //碰撞信息存储
        RaycastHit floorHit;

        //检测射线碰撞
        if(Physics.Raycast(cameraRay,out floorHit, maxCamRayLength, _floorMask))
        {
            //获取人物的朝向（看向鼠标点的位置）
            Vector3 playerToMousePosition = (floorHit.point - transform.position).normalized;
            //固定Y轴
            playerToMousePosition.y = 0f;
            //获取新的旋转角度（四元数）
            Quaternion newRotation = Quaternion.LookRotation(playerToMousePosition);
            //实现人物旋转
            _rig.MoveRotation(newRotation);
        }
    }
    private void PlayAnimation(float h, float v)
    {
        _aim.SetBool("Walk", h != 0 || v != 0);
    }

   

    

}
