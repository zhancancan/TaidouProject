using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITask : UIBase
{
    private RectTransform contentTask;
    private GameObject taskItemPrefab;
    private Button exit;
    public static UITask _instance;
    private void Awake()
    {
        _instance = this;
        exit = transform.Find("TaskBG/ESCBtn").GetComponent<Button>();
        contentTask = transform.Find("TaskBG/TaskScrollView/TaskItemUI/TaskListContent").GetComponent<RectTransform>();
    }
    private void Start()
    {
        exit.onClick.AddListener(()=> {UIManager.Instance.PopUIPanel();});
        InitTaskList();
    }
    /// <summary>
    /// 初始化任务列表信息
    /// </summary>
    void InitTaskList()
    {
        ArrayList taskList = TaskManager._instance.GetTaskList();
        foreach(Task task in taskList)
        {
            GameObject go = UIManager.Instance.GetUIPrefabInstance(ConstDates.UITaskList);
            print(go.name);
            go.transform.SetParent(contentTask.transform);
            UITaskItem ti = go.GetComponent<UITaskItem>();
            ti.SetTask(task);
        }
    }

    public override void OnEntering()
    {
        gameObject.SetActive(true);
    }

    public override void OnPausing()
    {
        gameObject.SetActive(false);
    }

    public override void OnResuming()
    {

    }

    public override void OnExiting()
    {
        gameObject.SetActive(false);
    }
}
