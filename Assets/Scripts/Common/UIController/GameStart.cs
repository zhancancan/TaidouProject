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
        if (CurrenSceneName != SceneManager.GetActiveScene().name)
        {
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
            case ConstDates.StartScene:
                CurrenSceneName = ConstDates.StartScene;
                UIManager.Instance.PushUIPanel(ConstDates.UIStart);
                break;
            case ConstDates.MainScene:
                CurrenSceneName = ConstDates.MainScene;
                UIManager.Instance.PushUIPanel(ConstDates.UIMain);
                break;
            default:
                break;
        }    
    }
}
