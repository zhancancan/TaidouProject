using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public enum DoTweenMoveDirection//物体移动的方向
{
    Up,
    Down,
    Left,
    Right,
    None
}

public struct PosState
{
    public float XOriginal; //物体当前坐标X轴离中心点的偏移量
    public float YOriginal; //物体当前坐标Y轴离中心点的偏移量

    public PosState(float x,float y)
    {
        this.XOriginal = x;//物体之前X
        this.YOriginal = y;//物体之前Y
    }
}

public class DoTweenEffectManager
{
    //保存物体各个方向上的状态
    public static Dictionary<GameObject, PosState> poseDit = new Dictionary<GameObject, PosState>();

    //初始化数据 
    //distance 物体移动距离,当为0的时候，移动的是屏幕的外面，否则移动确定的距离
    public static void MoveComponet(bool ison,GameObject objNeedMove,Toggle controlBtn, DoTweenMoveDirection direction, float duration = 1, float distance = 0 , Action fcHide = null, Action fcShow = null)
    {
        Vector3 objLocalPosition = objNeedMove.transform.localPosition;//需要移动物体的位置

        if (!poseDit.ContainsKey(objNeedMove))//判断是否字典已经保存该物体各方向的移动状态
        {
            PosState directionState;
            directionState = new PosState(objLocalPosition.x, objLocalPosition.y);////移动方式为移动固定距离
            poseDit.Add(objNeedMove, directionState);
        }

        PosState dirState = poseDit[objNeedMove];//获取物体各方向移动状态

        RectTransform rectTransform = objNeedMove.transform.GetComponent<RectTransform>();
        float w = rectTransform.rect.width; //控件宽度
        float h = rectTransform.rect.height;//控件高度

        float x1 = objNeedMove.transform.localPosition.x;//物体当前坐标X轴离中心点的偏移量
        float y1 = objNeedMove.transform.localPosition.y;//物体当前坐标Y轴离中心点的偏移量
        float x2 = Screen.width / 2 + w / 2; //屏幕宽度+物体宽度
        float y2 = Screen.height / 2 + h / 2; //屏幕高度+物体高度

        //以中心点为（0，0） 一四象限坐标为正，二三象限坐标为负
        switch (direction)
        {
           case DoTweenMoveDirection.Up:
                if (0 == distance) distance = y2 - y1;//物体在指定方向上需要移动的距离
                Vector3 vuHide = new Vector3(objLocalPosition.x, objLocalPosition.y+distance, objLocalPosition.z);
                Vector3 vuShow = new Vector3(objLocalPosition.x, dirState.YOriginal, objLocalPosition.z);
                ShowOrHideObj(objNeedMove, controlBtn,ison, vuHide, vuShow, duration,fcHide,fcShow);
                break;
            case DoTweenMoveDirection.Down:
                if (0 == distance) distance = -y2 - y1;
                else distance = -distance;
                Vector3 vdHide = new Vector3(objLocalPosition.x, objLocalPosition.y+distance, objLocalPosition.z);
                Vector3 vdShow = new Vector3(objLocalPosition.x, dirState.YOriginal, objLocalPosition.z);
                ShowOrHideObj(objNeedMove, controlBtn, ison, vdHide, vdShow, duration, fcHide, fcShow);
                break;
            case DoTweenMoveDirection.Left:
                if (0 == distance) distance = -x2 - x1;
                else distance = -distance;
                Vector3 vlHide = new Vector3(objLocalPosition.x + distance, objLocalPosition.y, objLocalPosition.z);
                Vector3 vlShow = new Vector3(dirState.XOriginal, objLocalPosition.y, objLocalPosition.z); 
                ShowOrHideObj(objNeedMove, controlBtn,ison, vlHide,vlShow, duration, fcHide, fcShow);
                break;
            case DoTweenMoveDirection.Right:
                if (0 == distance) distance = x2 - x1;
                Vector3 vrHide = new Vector3(objLocalPosition.x + distance, objLocalPosition.y, objLocalPosition.z);
                Vector3 vrShow = new Vector3(dirState.XOriginal, objLocalPosition.y, objLocalPosition.z);
                ShowOrHideObj(objNeedMove, controlBtn,ison, vrHide, vrShow, duration, fcHide, fcShow);
                break;
        }
    }

    /// <summary>
    /// 根据各方向上的显示和隐藏状态取移动物体
    /// </summary>
    /// <param name="objNeedMove">需要移动的物体</param>
    /// <param name="controlBtn">控制物体显示和隐藏的按钮</param>
    /// <param name="direction">物体移动方向</param> 
    /// <param name="dirState">物体各方向显示隐藏状态结构体变量</param> 
    /// <param name="showOrHide">物体某个方向的显示隐藏状态</param> 
    /// <param name="objLocalPosition">物体当前</param>
    /// <param name="distance">物体移动距离</param>
    /// <param name="duration">移动完成时间</param>
    private static void ShowOrHideObj(GameObject objNeedMove, Toggle controlBtn, bool xyShowOrHide, Vector3 vHide,Vector3 vShow,float duration, Action fcHide = null, Action fcShow = null)
    {
        controlBtn.interactable = false;
        if (xyShowOrHide) //显示
        {
            if (fcShow != null) fcShow();
            DOTween.To(() => objNeedMove.transform.localPosition, (vector3) => objNeedMove.transform.localPosition = vector3, vShow, duration)
                .OnComplete(
                    () => {
                        controlBtn.interactable = true;
                    }
                ).SetEase(Ease.OutSine);
        }
        else//隐藏
        {
            DOTween.To(() => objNeedMove.transform.localPosition, (vector3) => objNeedMove.transform.localPosition = vector3, vHide, duration)
                .OnComplete(() => {
                        controlBtn.interactable = true;
                        //对字典中物体各个方向赋值
                        //注意：这里的赋值，必须直接
                        if (fcHide != null) fcHide();
                    }
                ).SetEase(Ease.OutSine);
        }
    }
}

