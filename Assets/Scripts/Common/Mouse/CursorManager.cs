using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private static CursorManager _instance;//单例
    public static CursorManager Instance {
        get { return _instance; }
    }

    private CursorMode cursorMode = CursorMode.Auto;//选择设置鼠标的方式
    private Vector2 hotspot = Vector2.zero;//鼠标左上角

    void Awake ()
    {
        _instance = this;
    }

//    /// <summary>
//    /// 正常状态鼠标指针
//    /// </summary>
//    public void SetCursorNormal()
//    {
//        Cursor.SetCursor(cursor_normal,hotspot,cursorMode);
//    }

//    /// <summary>
//    /// 点击NPC时鼠标指针
//    /// </summary>
//    public void SetCursorTalk()
//    {
//        Cursor.SetCursor(cursor_talk, hotspot, cursorMode);
//    }
//
//    /// <summary>
//    /// 点击敌人时鼠标指针
//    /// </summary>
//    public void SetCursorAttack()
//    {
//        Cursor.SetCursor(cursor_attack, hotspot, cursorMode);
//    }
//
//    /// <summary>
//    /// 点击技能时鼠标指针
//    /// </summary>
//    public void SetCursorLookTarget()
//    {
//        Cursor.SetCursor(cursor_lookTarget, hotspot, cursorMode);
//    }
//
//    /// <summary>
//    /// 点击拾取物品时鼠标指针
//    /// </summary>
//    public void SetCursorPick()
//    {
//        Cursor.SetCursor(cursor_pick, hotspot, cursorMode);
//    }
}
