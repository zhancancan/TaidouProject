using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private string CurrenSceneName;

    private void Start()
    {
        GameStartForDifferentScenes();
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        //如果场景切换了 那么重新去加载主界面
        if (CurrenSceneName != SceneManager.GetActiveScene().name)
        {
            //切换场景的时候 清空存储经加载过UI界面的字典以及控制当前界面显示的堆栈
            UIManager.Instance.currentUIStack.Clear();
            UIManager.Instance.uiHaveLoaded.Clear();
            GameStartForDifferentScenes();
        }
    }

    /// <summary>
    /// 每个场景都会有个主界面，所以开始都要进行主界面入栈操作
    /// </summary>
    void GameStartForDifferentScenes()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            //hj
            case ConstDates.StartScene:
                CurrenSceneName = ConstDates.StartScene;
                UIManager.Instance.PushUIPanel(ConstDates.UIStart);
                break;
            //swl
            case ConstDates.SelectPlayerScene:
                CurrenSceneName = ConstDates.SelectPlayerScene;
                UIManager.Instance.PushUIPanel(ConstDates.UISelectPlayer);
                break;
            case ConstDates.CreatePlayerScene:
                CurrenSceneName = ConstDates.CreatePlayerScene;
                UIManager.Instance.PushUIPanel(ConstDates.UICreatePlayer);
                break;
            //zcc
            case ConstDates.MainScene:
                CurrenSceneName = ConstDates.MainScene;
                UIManager.Instance.PushUIPanel(ConstDates.UIMain);
                break;
            default:
                break;
        }    
    }
}
