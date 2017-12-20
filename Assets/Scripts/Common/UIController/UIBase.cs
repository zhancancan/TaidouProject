using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    /*
     * 所有UI界面的基类，该类只定义或者说规范子类的行为（功能）
     * 具体的UI界面如何实现不用管，该类仅仅只是一个声明子类应该具备那些状态而已
     * 
     */
    //一个页面分为四种状态，进入，暂停，恢复，退出
    public virtual void OnEntering() { }
    public virtual void OnPausing() { }
    public virtual void OnResuming() { }
    public virtual void OnExiting() { }
}
