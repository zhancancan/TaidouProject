using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/// <summary>
///1.共有17个接口方法
///2.其中OnMove使用的参数是AxisEventData eventData
///3.其中OnUpdateSelected、OnSelect 、OnDeselect 、OnSubmit 、OnCancel 使用的参数是BaseEventData eventData
///4.其余使用的参数是PointerEventData eventData
/// </summary>
public class EventTriggerListener : EventTrigger
{
    #region 委托和事件 

    //委托带参数是为了方便取得绑定了UI事件的对象以及对象的执行事件的数据    
    public delegate void PointerEventDelegate(GameObject go, PointerEventData eventData = null);

    //可变参数（用RuntimeArgumentHandle，因为__arglist不能用于委托） 也可以用可变数组prams
    //public delegate void PointerEventDelegate(RuntimeArgumentHandle handle);

    public delegate void BaseEventDelegate(GameObject go, BaseEventData eventData = null);

    public delegate void AxisEventDelegate(GameObject go, AxisEventData eventData = null);

    //定义事件
    /// <summary>
    /// 鼠标进入事件
    /// </summary>
    public event PointerEventDelegate onPointerEnter;

    /// <summary>
    /// 鼠标离开事件
    /// </summary>              
    public event PointerEventDelegate onPointerExit;

    /// <summary>
    /// 鼠标按下事件
    /// </summary>
    public event PointerEventDelegate onPointerDown;

    /// <summary>
    /// 鼠标抬起事件
    /// </summary>
    public event PointerEventDelegate onPointerUp;

    /// <summary>
    /// 在同一物体上按下并释放
    /// </summary>
    public event PointerEventDelegate onPointerClick;

    /// <summary>
    /// 拖拽时的初始化，跟IPointerDownHandler差不多，在按下时调用 
    /// </summary>
    public event PointerEventDelegate onInitializePotentialDrag;

    /// <summary>
    /// 拖拽开始
    /// </summary>
    public event PointerEventDelegate onBeginDrag;

    /// <summary>
    /// 拖拽中
    /// </summary>
    public event PointerEventDelegate onDrag;

    /// <summary>
    /// 拖拽结束(被拖拽的物体调用)
    /// </summary>
    public event PointerEventDelegate onEndDrag;

    /// <summary>
    /// 拖拽结束(拖拽结束后的位置(即鼠标位置)如果有物体，则那个物体调用)
    /// </summary>
    public event PointerEventDelegate onDrop;

    /// <summary>
    /// 滚轮滚动
    /// </summary>
    public event PointerEventDelegate onScroll;

    /// <summary>
    /// 被选中的物体每帧调用
    /// </summary>
    public event BaseEventDelegate onUpdateSelected;

    /// <summary>
    /// 物体被选中时
    /// </summary>
    public event BaseEventDelegate onSelect;

    /// <summary>
    /// 物体从选中到取消选中时
    /// </summary>
    public event BaseEventDelegate onDeselect;

    /// <summary>
    /// 物体移动时(与InputManager里的Horizontal和Vertica按键相对应)，前提条件是物体被选中
    /// </summary>
    public event AxisEventDelegate onMove;

    /// <summary>
    /// 提交按钮被按下时(与InputManager里的Submit按键相对应，PC上默认的是Enter键)，前提条件是物体被选中
    /// </summary>
    public event BaseEventDelegate onSubmit;

    /// <summary>
    /// 取消按钮被按下时(与InputManager里的Cancel按键相对应，PC上默认的是Esc键)，前提条件是物体被选中
    /// </summary>
    public event BaseEventDelegate onCancel;

    #endregion

    /// <summary>
    /// 获取事件监听脚本实例
    /// </summary>
    /// <param name="go">当前游戏物体对象</param>
    /// <returns></returns>
    public static EventTriggerListener GetListener(GameObject go)
    {
        EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
        if (listener == null) listener = go.AddComponent<EventTriggerListener>();
        return listener;
    }

    #region 事件回调  

    /// <summary>
    /// 包装一层方法 传一个__arglist，无法创建有效的 RuntimeArgumentHandle 结构的实例（它没有含带参数的构造函数）
    /// </summary>
    /// <param name="__arglist"></param>
    //public void Wrap(__arglist)
    //{
    //    onPointerClick(__arglist);
    //}

    public override void OnPointerEnter(PointerEventData eventData)
    {
        //鼠标进入事件执行
        if (onPointerEnter != null) onPointerEnter(gameObject, eventData);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        //鼠标离开事件执行
        if (onPointerExit != null) onPointerExit(gameObject, eventData);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (onPointerDown != null) onPointerDown(gameObject, eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (onPointerUp != null) onPointerUp(gameObject, eventData);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onPointerClick != null) onPointerClick(gameObject, eventData);
        //Wrap(__arglist("aaa", "bbbb"));
    }

    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        if (onInitializePotentialDrag != null) onInitializePotentialDrag(gameObject, eventData);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (onBeginDrag != null) onBeginDrag(gameObject, eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (onDrag != null) onDrag(gameObject, eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (onEndDrag != null) onEndDrag(gameObject, eventData);
    }

    public override void OnDrop(PointerEventData eventData)
    {
        if (onDrop != null) onDrop(gameObject, eventData);
    }

    public override void OnScroll(PointerEventData eventData)
    {
        if (onScroll != null) onScroll(gameObject, eventData);
    }

    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (onUpdateSelected != null) onUpdateSelected(gameObject, eventData);
    }

    public override void OnSelect(BaseEventData eventData)
    {
        if (onSelect != null) onSelect(gameObject, eventData);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        if (onDeselect != null) onDeselect(gameObject, eventData);
    }

    public override void OnMove(AxisEventData eventData)
    {
        if (onMove != null) onMove(gameObject, eventData);
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        if (onSubmit != null) onSubmit(gameObject, eventData);
    }

    public override void OnCancel(BaseEventData eventData)
    {
        if (onCancel != null) onCancel(gameObject, eventData);
    }

    #endregion

}