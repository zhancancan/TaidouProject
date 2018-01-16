using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera1 : MonoBehaviour
{

    public Transform player;
    private Vector3 offsetPosition;
    private float distance;
    private float scrollSpeed = 10; //鼠标滚轮速度
    private bool isRotating; //开启摄像机旋转
    private float rotateSpeed = 2; //摄像机旋转速度

    void Start()
    {
        //摄像机朝向player
        transform.LookAt(player.position);
        //获取摄像机与player的位置偏移
        offsetPosition = transform.position - player.position;
        //offsetPosition = player.position-transform.position;
    }

    void Update()
    {
        //摄像机跟随player与player保持相对位置偏移 
        transform.position = offsetPosition + player.position;
        //transform.position = player.position - offsetPosition;
        //摄像机的旋转
        RotateView();
        //摄像机的摄影控制(移动和缩放)
        ScrollView();
    }

    void ScrollView()
    {
        //返回位置偏移的向量长度
        distance = offsetPosition.magnitude;

        //根据鼠标滚轮的前后移动获取变化长度
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

        //限制变化长度的范围在最小为4最大为22之间
        distance = Mathf.Clamp(distance, 4, 22);

        //新的偏移值为偏移值的单位向量*变换长度
        offsetPosition = offsetPosition.normalized * distance;

    }

    void RotateView()
    {

        //按下鼠标右键开启旋转摄像机
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }

        //抬起鼠标右键关闭旋转摄像机
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        if (isRotating)
        {

            //获取摄像机初始位置
            Vector3 pos = transform.position;
            //获取摄像机初始角度
            Quaternion rot = transform.rotation;

            //摄像机围绕player的位置延player的Y轴旋转,旋转的速度为鼠标水平滑动的速度
            transform.RotateAround(player.position, player.up, Input.GetAxis("Mouse X") * rotateSpeed);

            //摄像机围绕player的位置延自身的X轴旋转,旋转的速度为鼠标垂直滑动的速度
            transform.RotateAround(player.position, transform.right, Input.GetAxis("Mouse Y") * rotateSpeed);

            //获取摄像机x轴向的欧拉角
            float x = transform.eulerAngles.x;

            //如果摄像机的x轴旋转角度超出范围,恢复初始位置和角度
            if (x < 10 || x > 80)
            {
                transform.position = pos;
                transform.rotation = rot;
            }
        }

        //更新摄像机与player的位置偏移
        offsetPosition = transform.position - player.position;
    }
}
