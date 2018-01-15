using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TaskManager : MonoBehaviour
{
    public static TaskManager _instance;
    public TextAsset taskinfoText;
    public ArrayList taskList = new ArrayList();
    private Task currentTask;
    private PlayerAutoMove playerAutoMove;
    bool isArrivalTranscript;   
    private PlayerAutoMove PlayerAutoMove
    {
        get
        {
            if(playerAutoMove == null)
            {
                playerAutoMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAutoMove>();

            }
            return playerAutoMove;
        }
    }
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
    //执行某个任务
    public void OnExcuteTask(Task task)
    {
        currentTask = task;
        if(task.TaskProgress == TaskProgress.NoStart)//点击下一步，自动导航到NPC
        {
            PlayerAutoMove.SetDestinations(NPCManager._instance.GetNpcById(task.NpcId).transform.position);
        }
        else if(task.TaskProgress == TaskProgress.Accept)
        {
            PlayerAutoMove.SetDestinations(NPCManager._instance.transcriptPosition.transform.position);
        }
    }
    public void OnAcceptTask()
    {
        currentTask.TaskProgress = TaskProgress.Accept;
        //接收完任务后自动寻路到副本入口
        PlayerAutoMove.SetDestinations(NPCManager._instance.transcriptPosition.transform.position);
        isArrivalTranscript = true;
    }
    public void OnArriveDestination()
    {
        //达到NPC点
        if(currentTask.TaskProgress == TaskProgress.NoStart)
        {           
            NPCTalk._instance.Show(currentTask.NpcTalk);
        }
        if (isArrivalTranscript)
        {
            UIManager.Instance.PushUIPanel("UIMap");
        }
    }
}
