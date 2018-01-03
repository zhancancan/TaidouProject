using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour {

    //攻击特效的渲染
    Renderer[] rendererArray;
    //这个脚本中带的重置特效的方法
    NcCurveAnimation[] curveAnim;

    GameObject effectOffset;

    void Start () {
        rendererArray = GetComponentsInChildren<Renderer>();
        curveAnim = GetComponentsInChildren<NcCurveAnimation>();

        if (transform.Find("EffectOffset") != null)
        {
            effectOffset = transform.Find("EffectOffset").gameObject;
        }
    }
	
    public void Show()
    {
        if (effectOffset != null)
        {
            effectOffset.SetActive(false);
            effectOffset.SetActive(true);
        }
        else
        {
            //遍历打开渲染效果
            foreach (Renderer renderer in rendererArray)
            {
                renderer.enabled = true;
            }
            //遍历重置特效
            foreach (NcCurveAnimation anim in curveAnim)
            {
                anim.ResetAnimation();
            }
        }
    }
}
