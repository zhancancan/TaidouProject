using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSettingManager : MonoBehaviour
{
    private static SystemSettingManager _instance;
    public static SystemSettingManager Instance {
        get { return _instance; }
    }

    private bool isShow;
    private GameObject systemSettingGo;

	void Awake ()
	{
	    _instance = this;
	}
	
	void Update ()
	{
	    if (null == systemSettingGo)
	    {
	        systemSettingGo = GameObject.FindGameObjectWithTag(Tags.SystemSetting);
        }
	    else
	    {
	        isShow = systemSettingGo.activeSelf;
	    }
        if (Input.GetKeyDown(KeyCode.Escape))
	    {
	        if (isShow)
	        {
	            UIManager.Instance.PopUIPanel();
	            isShow = false;
            }
	        else
	        {
	            UIManager.Instance.PushUIPanel(ConstDates.UISystemSetting);
	            isShow = true;
	        }
	    }
	}
}
