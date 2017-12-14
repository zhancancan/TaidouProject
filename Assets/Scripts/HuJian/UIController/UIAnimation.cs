
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//控制界面云朵实现移动
public class UIAnimation : MonoBehaviour
{
    public float speed = 20f;
    bool isStartMove = true;

    private void Update()
    {
        if (isStartMove)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (transform.position.x >= 1000f)
        {
            isStartMove = true;
        }
        if (transform.position.x <= -1000f)
        {
            isStartMove = false;
        }

    }
}
