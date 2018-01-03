using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Move,
    Idle
}

public class PlayerMove : MonoBehaviour
{
    private CharacterController playerCtr;
    private PlayerDir playerDir;

    public PlayerState playerState;
    private float speed = 4;
    public bool isMoving = false;

	void Start ()
	{
	    playerDir = GetComponent<PlayerDir>();
        //playerAttack = GetComponent<PlayerAttack>();
	    playerCtr = GetComponent<CharacterController>();
    }

    void Update()
    {
//	    if (playerAttack.state == PlayerStateState.ControlWalk)
//	    {
        float distance = Vector3.Distance(playerDir.targetPositon, transform.position);
        if (distance > 0.1f)
        {
            isMoving = true;
            playerCtr.SimpleMove(transform.forward * speed);
            playerState = PlayerState.Move;
        }
        else
        {
            isMoving = false;
            playerState = PlayerState.Idle;
        }
//      }
//	    else
//	    {
//	        
//	    }
    }

    public void SimpleMove(Vector3 targetPos)
    {
        transform.LookAt(targetPos);
        playerCtr.SimpleMove(transform.forward * speed);
    }
}
