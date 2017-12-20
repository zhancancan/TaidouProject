using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISelectPlayer : UIBase {

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
    /// 切换到创建角色场景
    /// </summary>
    public void ChangerToCreatePlayerScene()
    {
        SceneManager.LoadSceneAsync(ConstDates.CreatePlayerSceneIndex);
    }

    /// <summary>
    /// 切换到主场景
    /// </summary>
    public void ChangerToMainScene()
    {
        SceneManager.LoadSceneAsync(ConstDates.MainSceneIndex);
    }
}
