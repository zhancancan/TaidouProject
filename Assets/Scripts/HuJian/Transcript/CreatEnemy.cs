using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatEnemy : MonoBehaviour
{
    public static CreatEnemy _instance;
    public GameObject[] enemy;//敌人预支体            
    public Transform[] points;//生成敌人的地点
    bool isCreat;
    public float createEnemyTime = 2f;//生成敌人的时间

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        if (isCreat)
        {
            InvokeRepeating("CreateFirstEnemy", createEnemyTime, createEnemyTime);
            InvokeRepeating("CreateSecondEnemy", createEnemyTime, createEnemyTime);
            InvokeRepeating("CreateThirdEnemy", createEnemyTime, createEnemyTime);
            InvokeRepeating("CreateFourthEnemy", createEnemyTime, createEnemyTime);
        }
    }
    public void CreateFirstEnemy()
    {        
        Instantiate(enemy[0], points[0].position, points[0].rotation);
        isCreat = true;
    }
    public void CreateSecondEnemy()
    {
        Instantiate(enemy[1], points[1].position, points[1].rotation);
        isCreat = true;
    }
    public void CreateThirdEnemy()
    {
        Instantiate(enemy[2], points[2].position, points[2].rotation);
        isCreat = true;
    }
    public void CreateFourthEnemy()
    {
        Instantiate(enemy[3], points[3].position, points[3].rotation);
        isCreat = true;
    }

}
