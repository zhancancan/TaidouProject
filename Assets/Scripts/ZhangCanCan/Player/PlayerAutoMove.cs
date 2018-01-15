using System.Collections;
using System.Collections.Generic;
using UnityEngine;    
using UnityEngine.AI;

public class PlayerAutoMove : MonoBehaviour
{
    private NavMeshAgent agent; 
    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();   
        agent.enabled = false;
    }
    private void Update()
    {
        if (agent.enabled)
        {
            if (agent.remainingDistance < 1.5&&agent.remainingDistance!=0)
            {                
                agent.isStopped = true;           
                agent.enabled = false;
                TaskManager._instance.OnArriveDestination();
            }
        }
      
    }

    public void SetDestinations(Vector3 targetPos)
    {
        agent.enabled = true;
        agent.SetDestination(targetPos);
    }
   
}
