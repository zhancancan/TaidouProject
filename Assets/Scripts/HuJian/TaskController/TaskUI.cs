using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskUI : MonoBehaviour
{
    private RectTransform contentTask;
    public GameObject taskItemPrefab;
    private void Awake()
    {
        contentTask = transform.Find("TaskListContent").GetComponent<RectTransform>();
    }
    private void Start()
    {
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
            GameObject go =Instantiate(taskItemPrefab);
            go.transform.SetParent(contentTask.transform);
            TaskItemUI ti = go.GetComponent<TaskItemUI>();
            ti.SetTask(task);
        }
    }
}
