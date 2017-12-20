using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICreatePlayer : UIBase {

    public override void OnEntering()
    {
        gameObject.SetActive(true);
    }

    public override void OnPausing()
    {

    }

    public override void OnResuming()
    {

    }

    public override void OnExiting()
    {

    }

    /// <summary>
    /// 切换到旋转角色场景
    /// </summary>
    public void ChangerToSelectPlayerScene()
    {
        SceneManager.LoadSceneAsync(ConstDates.SelectPlayerSceneIndex);
    }
}
