using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollowPlayer : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 offset;

    public float distance = 0;
    private float scaleSpeed = 10;
    private float rotateSpeed = 5;
    private bool isClicked = false;

    void Start ()
	{
	    playerTransform = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        offset = transform.position - playerTransform.position;
        distance = offset.magnitude;
        transform.LookAt(playerTransform.position);
    }

    void Update ()
    {
        RotateView();
        ScaleView();
        transform.position = offset + playerTransform.position;
    }

    //滑动滚轮缩放视野
    void ScaleView()
    {
        distance = offset.magnitude - Input.GetAxis("Mouse ScrollWheel") * scaleSpeed;
        distance = Mathf.Clamp(distance, 2.5f, 30);//控制缩放的范围
        offset = offset.normalized * distance;
    }

    //选择视野
    void RotateView()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isClicked = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isClicked = false;
        }

        if (isClicked)
        {
            Vector3 position = transform.position;//存储物体之前的位置
            Quaternion rotation = transform.rotation;//存储物体之前的角度

            transform.RotateAround(playerTransform.position, playerTransform.up, Input.GetAxis("Mouse X") * rotateSpeed);//物体围绕别的物体的轴转

            transform.RotateAround(playerTransform.position, transform.right, Input.GetAxis("Mouse Y") * rotateSpeed);

            float x = transform.eulerAngles.x;
            if (x < 10 || x > 80)//绕世界x轴的旋转角度范围
            {
                //位置和角度重置
                transform.position = position;
                transform.rotation = rotation;
            }
            offset = transform.position - playerTransform.position;
        }
    }

    //检查鼠标的位置，如果在地面上才可以缩放/旋转
}
