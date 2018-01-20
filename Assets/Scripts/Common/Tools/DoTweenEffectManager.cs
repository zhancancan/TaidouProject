//using System;
//using System.Collections;
//using System.Collections.Generic;
//using DG.Tweening;
//using UnityEngine;
//using UnityEngine.UI;
//
//public enum DoTweenMoveDirection//物体移动的方向
//{
//    Up,
//    Down,
//    Left,
//    Right,
//    None
//}
//
//public struct ObjDirectionState
//{
//    public bool LeftShowOrHide;
//    public bool RightShowOrHide;
//    public bool UpShowOrHide;
//    public bool DownShowOrHide;
//    public float XOriginal; //物体当前坐标X轴离中心点的偏移量
//    public float YOriginal; //物体当前坐标Y轴离中心点的偏移量
//
//    public ObjDirectionState(bool leftShowOrHide, bool rightShowOrHide, bool upShowOrHide, bool downShowOrHide, float x,float y)
//    {
//        this.LeftShowOrHide = leftShowOrHide;
//        this.RightShowOrHide = rightShowOrHide;
//        this.UpShowOrHide = upShowOrHide;
//        this.DownShowOrHide = downShowOrHide;
//        this.XOriginal = x;//物体之前X
//        this.YOriginal = y;//物体之前Y
//    }
//}
//
//
//
//public class DoTweenEffectManager
//{
//    //保存物体各个方向上的状态
//    public static Dictionary<GameObject,ObjDirectionState> ObjDirectionStateDit = new Dictionary<GameObject, ObjDirectionState>();
//
//    //从屏幕外开始移动,需要指定原来在屏幕中的位置
//    public static void MoveFromOutScreen(GameObject objNeedMove, Button controlBtn, DoTweenMoveDirection direction, Vector2 originalPos, float duration = 1, bool opposite = false, Action fcHide = null, Action fcShow = null)
//    {
//        MoveComponet(objNeedMove, controlBtn, direction, originalPos,true, duration, 0, opposite,fcHide,fcShow);
//    }
//
//    //从屏幕内开始移动，无需指定位置
//    public static void MoveFronInScreen(GameObject objNeedMove, Button controlBtn, DoTweenMoveDirection direction, float duration = 1, bool opposite = false,Action fcHide = null, Action fcShow = null )
//    {
//        Vector2 v = new Vector2(objNeedMove.transform.localPosition.x, objNeedMove.transform.localPosition.y);
//        MoveComponet(objNeedMove, controlBtn, direction, v,false,duration, 0, opposite, fcHide, fcShow);
//    }
//
//    //屏幕内移动一定距离
//    public static void MoveDistance(GameObject objNeedMove, Button controlBtn, DoTweenMoveDirection direction, float duration = 1, float distance = 0, bool opposite = false, Action fcHide = null, Action fcShow = null)
//    {
//        Vector2 v = new Vector2(objNeedMove.transform.localPosition.x, objNeedMove.transform.localPosition.y);
//        MoveComponet(objNeedMove, controlBtn, direction,v,false, duration, distance, opposite, fcHide, fcShow);
//    }
//
//    //初始化数据 
//    //oppsite 为true表示物体经过旋转，宽和高调换
//    //distance 物体移动距离,当为0的时候，移动的是屏幕的外面，否则移动确定的距离
//    private static void MoveComponet(GameObject objNeedMove,Button controlBtn, DoTweenMoveDirection direction, Vector2 originalPos, bool objOutOfScreen = false, float duration = 1, float distance = 0 ,bool opposite=false, Action fcHide = null, Action fcShow = null)
//    {
//        Vector3 objLocalPosition = objNeedMove.transform.localPosition;//需要移动物体的位置
//
//        if (!ObjDirectionStateDit.ContainsKey(objNeedMove))//判断是否字典已经保存该物体各方向的移动状态
//        {
//            ObjDirectionState directionState;
//            if (0 == distance) //移动方式为移动到屏幕的外面
//            {
//                if (objOutOfScreen) directionState = new ObjDirectionState(true, true, true, true, originalPos.x, originalPos.y);//开始的时候物体是否在屏幕的外面
//                else directionState = new ObjDirectionState(false, false, false, false, objLocalPosition.x, objLocalPosition.y);
//            }
//            else directionState = new ObjDirectionState(false, false, false, false, objLocalPosition.x, objLocalPosition.y);////移动方式为移动固定距离
//            ObjDirectionStateDit.Add(objNeedMove, directionState);
//        }
//
//        ObjDirectionState dirState = ObjDirectionStateDit[objNeedMove];//获取物体各方向移动状态
//
//        RectTransform rectTransform = objNeedMove.transform.GetComponent<RectTransform>();
//        float w = rectTransform.rect.width; //控件宽度
//        float h = rectTransform.rect.height;//控件高度
//
//        float x1 = objNeedMove.transform.localPosition.x;//物体当前坐标X轴离中心点的偏移量
//        float y1 = objNeedMove.transform.localPosition.y;//物体当前坐标Y轴离中心点的偏移量
//        float x2 = Screen.width / 2 + w / 2; //屏幕宽度+物体宽度
//        float y2 = Screen.height / 2 + h / 2; //屏幕高度+物体高度
//
//        if (opposite)//是否Z旋转
//        {
//            float wTemp = w;
//            w = h;
//            h = wTemp;
//            x2 = Screen.width / 2 + w / 2;
//            y2 = Screen.height / 2 + h / 2;
//        }
//        
//        //以中心点为（0，0） 一四象限坐标为正，二三象限坐标为负
//        switch (direction)
//        {
//           case DoTweenMoveDirection.Up:
//                if (0 == distance) distance = y2 - y1;//物体在指定方向上需要移动的距离
//                Vector3 vuHide = new Vector3(objLocalPosition.x, objLocalPosition.y+distance, objLocalPosition.z);
//                Vector3 vuShow = new Vector3(objLocalPosition.x, dirState.YOriginal, objLocalPosition.z);
//                ShowOrHideObj(objNeedMove, controlBtn, direction, dirState, dirState.UpShowOrHide, vuHide, vuShow, distance, duration,fcHide,fcShow);
//                break;
//            case DoTweenMoveDirection.Down:
//                if (0 == distance) distance = -y2 - y1;
//                else distance = -distance;
//                Vector3 vdHide = new Vector3(objLocalPosition.x, objLocalPosition.y+distance, objLocalPosition.z);
//                Vector3 vdShow = new Vector3(objLocalPosition.x, dirState.YOriginal, objLocalPosition.z);
//                ShowOrHideObj(objNeedMove, controlBtn, direction, dirState, dirState.DownShowOrHide, vdHide, vdShow, distance, duration, fcHide, fcShow);
//                break;
//            case DoTweenMoveDirection.Left:
//                if (0 == distance) distance = -x2 - x1;
//                else distance = -distance;
//                Vector3 vlHide = new Vector3(objLocalPosition.x + distance, objLocalPosition.y, objLocalPosition.z);
//                Vector3 vlShow = new Vector3(dirState.XOriginal, objLocalPosition.y, objLocalPosition.z); 
//                ShowOrHideObj(objNeedMove, controlBtn, direction, dirState, dirState.LeftShowOrHide, vlHide,vlShow, distance, duration, fcHide, fcShow);
//                break;
//            case DoTweenMoveDirection.Right:
//                if (0 == distance) distance = x2 - x1;
//                Vector3 vrHide = new Vector3(objLocalPosition.x + distance, objLocalPosition.y, objLocalPosition.z);
//                Vector3 vrShow = new Vector3(dirState.XOriginal, objLocalPosition.y, objLocalPosition.z);
//                ShowOrHideObj(objNeedMove, controlBtn, direction, dirState, dirState.RightShowOrHide, vrHide, vrShow, distance, duration, fcHide, fcShow);
//                break;
//        }
//    }
//
//    /// <summary>
//    /// 根据各方向上的显示和隐藏状态取移动物体
//    /// </summary>
//    /// <param name="objNeedMove">需要移动的物体</param>
//    /// <param name="controlBtn">控制物体显示和隐藏的按钮</param>
//    /// <param name="direction">物体移动方向</param> 
//    /// <param name="dirState">物体各方向显示隐藏状态结构体变量</param> 
//    /// <param name="showOrHide">物体某个方向的显示隐藏状态</param> 
//    /// <param name="objLocalPosition">物体当前</param>
//    /// <param name="distance">物体移动距离</param>
//    /// <param name="duration">移动完成时间</param>
//    private static void ShowOrHideObj(GameObject objNeedMove, Button controlBtn, DoTweenMoveDirection direction,ObjDirectionState dirState, bool xyShowOrHide, Vector3 vHide,Vector3 vShow, float distance,float duration, Action fcHide = null, Action fcShow = null)
//    {
//        controlBtn.interactable = false;
//        if (!xyShowOrHide) //显示-隐藏
//        {
//            DOTween.To(() => objNeedMove.transform.localPosition,(vector3) => objNeedMove.transform.localPosition = vector3,vHide, duration)
//                .OnComplete(() =>{
//                        controlBtn.interactable = true;
//                        //对字典中物体各个方向赋值
//                        //注意：这里的赋值，必须直接
//                         OneDirectionShowHide(direction, dirState,objNeedMove);
//                        if (fcHide!=null) fcHide();
//                    }
//                ).SetEase(Ease.OutSine);
//        }
//        else//隐藏-显示
//        {
//            if (fcShow != null) fcShow();
//            DOTween.To(() => objNeedMove.transform.localPosition,(vector3) => objNeedMove.transform.localPosition = vector3,vShow,duration)
//                .OnComplete(
//                    () =>{
//                        controlBtn.interactable = true;
//                        OneDirectionShowHide(direction, dirState,objNeedMove);
//                    }
//                ).SetEase(Ease.OutSine);
//        }
//    }
//
//    //根据用户传入的移动方向，更该方向上的显示隐藏状态
//    private static  void OneDirectionShowHide(DoTweenMoveDirection direction,ObjDirectionState dirState, GameObject objNeedMove)
//    {
//        switch (direction)
//        {
//            case DoTweenMoveDirection.Left:
//                dirState.LeftShowOrHide = !dirState.LeftShowOrHide;
//                break;
//            case DoTweenMoveDirection.Right:
//                    dirState.RightShowOrHide = !dirState.RightShowOrHide;
//                break;
//            case DoTweenMoveDirection.Up:
//                dirState.UpShowOrHide = !dirState.UpShowOrHide;
//                break;
//            case DoTweenMoveDirection.Down:
//                dirState.DownShowOrHide = !dirState.DownShowOrHide;
//                break;
//        }
//        ObjDirectionStateDit.Remove(objNeedMove);
//        ObjDirectionStateDit.Add(objNeedMove, dirState);
//    }
//
//    //清除字典中某个移动物体的信息，如果UI经过手动旋转的时候，需要重删除该UI
//    public static void ClearInfo(GameObject objNeedMove)
//    {
//        if (ObjDirectionStateDit.ContainsKey(objNeedMove))
//        {
//            ObjDirectionStateDit.Remove(objNeedMove);
//        }
//    }
//}









































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

public struct ObjDirectionState
{
    public bool LeftShowOrHide;
    public bool RightShowOrHide;
    public bool UpShowOrHide;
    public bool DownShowOrHide;
    public float XOriginal; //物体当前坐标X轴离中心点的偏移量
    public float YOriginal; //物体当前坐标Y轴离中心点的偏移量

    public ObjDirectionState(bool leftShowOrHide, bool rightShowOrHide, bool upShowOrHide, bool downShowOrHide, float x, float y)
    {
        this.LeftShowOrHide = leftShowOrHide;
        this.RightShowOrHide = rightShowOrHide;
        this.UpShowOrHide = upShowOrHide;
        this.DownShowOrHide = downShowOrHide;
        this.XOriginal = x;//物体之前X
        this.YOriginal = y;//物体之前Y
    }
}



public class DoTweenEffectManager
{
    //保存物体各个方向上的状态
    public static Dictionary<GameObject, ObjDirectionState> ObjDirectionStateDit = new Dictionary<GameObject, ObjDirectionState>();

    //从屏幕外开始移动,需要指定原来在屏幕中的位置
    public static void MoveFromOutScreen(GameObject objNeedMove, Button controlBtn, DoTweenMoveDirection direction, Vector2 originalPos, float duration = 1, bool opposite = false, Action fcHide = null, Action fcShow = null)
    {
        MoveComponet(objNeedMove, controlBtn, direction, originalPos, true, duration, 0, opposite, fcHide, fcShow);
    }

    //从屏幕内开始移动，无需指定位置
    public static void MoveFronInScreen(GameObject objNeedMove, Button controlBtn, DoTweenMoveDirection direction, float duration = 1, bool opposite = false, Action fcHide = null, Action fcShow = null)
    {
        Vector2 v = new Vector2(objNeedMove.transform.localPosition.x, objNeedMove.transform.localPosition.y);
        MoveComponet(objNeedMove, controlBtn, direction, v, false, duration, 0, opposite, fcHide, fcShow);
    }

    //屏幕内移动一定距离
    public static void MoveDistance(GameObject objNeedMove, Button controlBtn, DoTweenMoveDirection direction, float duration = 1, float distance = 0, bool opposite = false, Action fcHide = null, Action fcShow = null)
    {
        Vector2 v = new Vector2(objNeedMove.transform.localPosition.x, objNeedMove.transform.localPosition.y);
        MoveComponet(objNeedMove, controlBtn, direction, v, false, duration, distance, opposite, fcHide, fcShow);
    }

    //初始化数据 
    //oppsite 为true表示物体经过旋转，宽和高调换
    //distance 物体移动距离,当为0的时候，移动的是屏幕的外面，否则移动确定的距离
    private static void MoveComponet(GameObject objNeedMove, Button controlBtn, DoTweenMoveDirection direction, Vector2 originalPos, bool objOutOfScreen = false, float duration = 1, float distance = 0, bool opposite = false, Action fcHide = null, Action fcShow = null)
    {
        Vector3 objLocalPosition = objNeedMove.transform.localPosition;//需要移动物体的位置

        if (!ObjDirectionStateDit.ContainsKey(objNeedMove))//判断是否字典已经保存该物体各方向的移动状态
        {
            ObjDirectionState directionState;
            if (0 == distance) //移动方式为移动到屏幕的外面
            {
                if (objOutOfScreen) directionState = new ObjDirectionState(true, true, true, true, originalPos.x, originalPos.y);//开始的时候物体是否在屏幕的外面
                else directionState = new ObjDirectionState(false, false, false, false, objLocalPosition.x, objLocalPosition.y);
            }
            else directionState = new ObjDirectionState(false, false, false, false, objLocalPosition.x, objLocalPosition.y);////移动方式为移动固定距离
            ObjDirectionStateDit.Add(objNeedMove, directionState);
        }

        ObjDirectionState dirState = ObjDirectionStateDit[objNeedMove];//获取物体各方向移动状态

        RectTransform rectTransform = objNeedMove.transform.GetComponent<RectTransform>();
        float w = rectTransform.rect.width; //控件宽度
        float h = rectTransform.rect.height;//控件高度

        float x1 = objNeedMove.transform.localPosition.x;//物体当前坐标X轴离中心点的偏移量
        float y1 = objNeedMove.transform.localPosition.y;//物体当前坐标Y轴离中心点的偏移量
        float x2 = Screen.width / 2 + w / 2; //屏幕宽度+物体宽度
        float y2 = Screen.height / 2 + h / 2; //屏幕高度+物体高度

        if (opposite)//是否Z旋转
        {
            float wTemp = w;
            w = h;
            h = wTemp;
            x2 = Screen.width / 2 + w / 2;
            y2 = Screen.height / 2 + h / 2;
        }

        //以中心点为（0，0） 一四象限坐标为正，二三象限坐标为负
        switch (direction)
        {
            case DoTweenMoveDirection.Up:
                if (0 == distance) distance = y2 - y1;//物体在指定方向上需要移动的距离
                Vector3 vuHide = new Vector3(objLocalPosition.x, objLocalPosition.y + distance, objLocalPosition.z);
                Vector3 vuShow = new Vector3(objLocalPosition.x, dirState.YOriginal, objLocalPosition.z);
                ShowOrHideObj(objNeedMove, controlBtn, direction, dirState, dirState.UpShowOrHide, vuHide, vuShow, distance, duration, fcHide, fcShow);
                break;
            case DoTweenMoveDirection.Down:
                if (0 == distance) distance = -y2 - y1;
                else distance = -distance;
                Vector3 vdHide = new Vector3(objLocalPosition.x, objLocalPosition.y + distance, objLocalPosition.z);
                Vector3 vdShow = new Vector3(objLocalPosition.x, dirState.YOriginal, objLocalPosition.z);
                ShowOrHideObj(objNeedMove, controlBtn, direction, dirState, dirState.DownShowOrHide, vdHide, vdShow, distance, duration, fcHide, fcShow);
                break;
            case DoTweenMoveDirection.Left:
                if (0 == distance) distance = -x2 - x1;
                else distance = -distance;
                Vector3 vlHide = new Vector3(objLocalPosition.x + distance, objLocalPosition.y, objLocalPosition.z);
                Vector3 vlShow = new Vector3(dirState.XOriginal, objLocalPosition.y, objLocalPosition.z);
                ShowOrHideObj(objNeedMove, controlBtn, direction, dirState, dirState.LeftShowOrHide, vlHide, vlShow, distance, duration, fcHide, fcShow);
                break;
            case DoTweenMoveDirection.Right:
                if (0 == distance) distance = x2 - x1;
                Vector3 vrHide = new Vector3(objLocalPosition.x + distance, objLocalPosition.y, objLocalPosition.z);
                Vector3 vrShow = new Vector3(dirState.XOriginal, objLocalPosition.y, objLocalPosition.z);
                ShowOrHideObj(objNeedMove, controlBtn, direction, dirState, dirState.RightShowOrHide, vrHide, vrShow, distance, duration, fcHide, fcShow);
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
    private static void ShowOrHideObj(GameObject objNeedMove, Button controlBtn, DoTweenMoveDirection direction, ObjDirectionState dirState, bool xyShowOrHide, Vector3 vHide, Vector3 vShow, float distance, float duration, Action fcHide = null, Action fcShow = null)
    {
        controlBtn.interactable = false;
        if (!xyShowOrHide) //显示-隐藏
        {
            DOTween.To(() => objNeedMove.transform.localPosition, (vector3) => objNeedMove.transform.localPosition = vector3, vHide, duration)
                .OnComplete(() => {
                    controlBtn.interactable = true;
                    //对字典中物体各个方向赋值
                    //注意：这里的赋值，必须直接
                    OneDirectionShowHide(direction, dirState, objNeedMove);
                    if (fcHide != null) fcHide();
                }
                ).SetEase(Ease.OutSine);
        }
        else//隐藏-显示
        {
            if (fcShow != null) fcShow();
            DOTween.To(() => objNeedMove.transform.localPosition, (vector3) => objNeedMove.transform.localPosition = vector3, vShow, duration)
                .OnComplete(
                    () => {
                        controlBtn.interactable = true;
                        OneDirectionShowHide(direction, dirState, objNeedMove);
                    }
                ).SetEase(Ease.OutSine);
        }
    }

    //根据用户传入的移动方向，更该方向上的显示隐藏状态
    private static void OneDirectionShowHide(DoTweenMoveDirection direction, ObjDirectionState dirState, GameObject objNeedMove)
    {
        switch (direction)
        {
            case DoTweenMoveDirection.Left:
                dirState.LeftShowOrHide = !dirState.LeftShowOrHide;
                break;
            case DoTweenMoveDirection.Right:
                dirState.RightShowOrHide = !dirState.RightShowOrHide;
                break;
            case DoTweenMoveDirection.Up:
                dirState.UpShowOrHide = !dirState.UpShowOrHide;
                break;
            case DoTweenMoveDirection.Down:
                dirState.DownShowOrHide = !dirState.DownShowOrHide;
                break;
        }
        ObjDirectionStateDit.Remove(objNeedMove);
        ObjDirectionStateDit.Add(objNeedMove, dirState);
    }

    //清除字典中某个移动物体的信息，如果UI经过手动旋转的时候，需要重删除该UI
    public static void ClearInfo(GameObject objNeedMove)
    {
        if (ObjDirectionStateDit.ContainsKey(objNeedMove))
        {
            ObjDirectionStateDit.Remove(objNeedMove);
        }
    }
}
