using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//任务类型
public enum TaskType
{
    Main,//主线任务
    Reward,//赏金任务
    Daily//日常任务
}
//任务完成状态
public enum TaskProgress
{
    NoStart,
    Accept,
    Complete,
    Reward
}
//任务属性
public class Task
{
    //id
    //任务类型
    //名称
    //图标
    //任务描述
    //获得的金币奖励
    //获得的钻石奖励
    //和NPC交谈的话语
    //NPC的id
    //副本id
    //任务的状态
    //未开始
    //接收任务
    //任务完成
    //领取奖励
    private int id;
    private TaskType taskType;
    private string name;    
    private string des;
    private int coin;
    private int dainmond;
    private string npcTalk;
    private int npcId;
    private int transcriptId;
    private TaskProgress taskProgress = TaskProgress.NoStart;

    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public TaskType TaskType
    {
        get
        {
            return taskType;
        }
        set
        {
            taskType = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }   

    public string Des
    {
        get
        {
            return des;
        }
        set
        {
            des = value;
        }
    }

    public int Coin
    {
        get
        {
            return coin;
        }
        set
        {
            coin = value;
        }
    }

    public int Dainmond
    {
        get
        {
            return dainmond;
        }
        set
        {
            dainmond = value;
        }
    }

    public string NpcTalk
    {
        get
        {
            return npcTalk;
        }
        set
        {
            npcTalk = value;
        }
    }

    public int NpcId
    {
        get
        {
            return npcId;
        }
        set
        {
            npcId = value;
        }
    }

    public int TranscriptId
    {
        get
        {
            return transcriptId;
        }
        set
        {
            transcriptId = value;
        }
    }

    public TaskProgress TaskProgress
    {
        get
        {
            return taskProgress;
        }
        set
        {
            taskProgress = value;
        }
    }
}
