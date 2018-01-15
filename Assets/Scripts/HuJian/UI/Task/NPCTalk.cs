using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCTalk : MonoBehaviour {
    public static NPCTalk _instance;
    private Canvas uiTalk;
    private Text npcTalk;
    private Button acceptBtn;
    private void Awake()
    {
        uiTalk = this.GetComponent<Canvas>();
        npcTalk = transform.Find("TalkBG/TalkContentTxt").GetComponent<Text>();
        acceptBtn = transform.Find("AcceptBtn").GetComponent<Button>();
        acceptBtn.onClick.AddListener(OnAccept);
        _instance = this;
        uiTalk.gameObject.SetActive(false);
    }
    public void Show(string tasktalk)
    {
        npcTalk.text = tasktalk;
        uiTalk.gameObject.SetActive(true);
    }
    void OnAccept()
    {        
        uiTalk.gameObject.SetActive(false);
        //通知任务管理器任务已经接收
        TaskManager._instance.OnAcceptTask();
    }
}
