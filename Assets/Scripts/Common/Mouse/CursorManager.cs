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
    public Texture2D aaa;

    void Awake ()
    {
        _instance = this;
    }

    /// <summary>
    /// 正常状态鼠标指针
    /// </summary>
    public void SetCursorNormal()
    {
        Texture2D cursorNormal = TextureManager.Instance.GetTexture2D(ConstDates.ResourceTexturePrefabDirZcc, ConstDates.Cursor_Normal);
        Cursor.SetCursor(cursorNormal, hotspot,cursorMode);
    }

    /// <summary>
    /// 点击NPC时鼠标指针
    /// </summary>
    public void SetCursorNpcTalk()
    {
        Texture2D cursorNpcTalk = TextureManager.Instance.GetTexture2D(ConstDates.ResourceTexturePrefabDirZcc, ConstDates.Cursor_NpcTalk);
        Cursor.SetCursor(cursorNpcTalk, hotspot, cursorMode);
    }

    /// <summary>
    /// 点击敌人时鼠标指针
    /// </summary>
    public void SetCursorAttack()
    {
        Texture2D cursorAttack = TextureManager.Instance.GetTexture2D(ConstDates.ResourceTexturePrefabDirZcc, ConstDates.Cursor_Attack);
        Cursor.SetCursor(cursorAttack, hotspot, cursorMode);
    }

    /// <summary>
    /// 点击技能时鼠标指针
    /// </summary>
    public void SetCursorLookTarget()
    {
        Texture2D cursorLookTarget = TextureManager.Instance.GetTexture2D(ConstDates.ResourceTexturePrefabDirZcc, ConstDates.Cursor_LockTarget);
        Cursor.SetCursor(cursorLookTarget, hotspot, cursorMode);
    }

    /// <summary>
    /// 点击拾取物品时鼠标指针
    /// </summary>
    public void SetCursorPick()
    {
        Texture2D cursorPick = TextureManager.Instance.GetTexture2D(ConstDates.ResourceTexturePrefabDirZcc, ConstDates.Cursor_Pick);
        Cursor.SetCursor(cursorPick, hotspot, cursorMode);
    }
}
