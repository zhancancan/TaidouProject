﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager _instance;
    public TextAsset taskinfoText;
    public ArrayList taskList = new ArrayList();
    private void Awake()
    {
        _instance = this;
        InitTask();
    }
    /// <summary>
    /// 初始化任务信息
    /// </summary>
    public void InitTask()
    {
        string[] taskInfoArray = taskinfoText.ToString().Split('\n');
        foreach (string str in taskInfoArray)
        {
            string[] proArray = str.Split('|');
            Task task = new Task();
            task.Id = int.Parse(proArray[0]);
            switch (proArray[1])
            {
                case "Main":
                    task.TaskType = TaskType.Main;
                    break;
                case "Reward":
                    task.TaskType = TaskType.Reward;
                    break;
                case "Daily":
                    task.TaskType = TaskType.Daily;
                    break;
            }
            task.Name = proArray[2];            
            task.Des = proArray[3];
            task.Coin = int.Parse(proArray[4]);
            task.Dainmond = int.Parse(proArray[5]);
            task.NpcTalk = proArray[6];
            task.NpcId = int.Parse(proArray[7]);
            task.TranscriptId = int.Parse(proArray[8]);
            taskList.Add(task);
        }
    }
    public ArrayList GetTaskList()
    {
        return taskList;
    }
}