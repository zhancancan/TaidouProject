using System.Collections;
using System.Collections.Generic;
using UnityEngine;    
using UnityEngine.AI;

public class PlayerAutoMove : MonoBehaviour
{
    private CharacterController playerCharacter;
    private NavMeshAgent agent;
    private PlayerDir playerDir; 
    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
        playerCharacter = this.GetComponent<CharacterController>();
        playerDir = this.GetComponent<PlayerDir>();   
        agent.enabled = false;
    }
    private void Update()
    {
        if (agent.enabled)
        {
            playerCharacter.enabled = false;
            playerDir.enabled = false;
            if (agent.remainingDistance < 1.5&&agent.remainingDistance!=0)
            {                
                agent.isStopped = true;           
                agent.enabled = false;
                TaskManager._instance.OnArriveDestination();
            }
            if (Input.GetMouseButtonDown(0))
            {
                agent.enabled = false;
                playerCharacter.enabled = true;
                playerDir.enabled = true;
            }
        }
      
    }

    public void SetDestinations(Vector3 targetPos)
    {
        agent.enabled = true;
        agent.SetDestination(targetPos);
    }
   
}
