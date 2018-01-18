using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController playerCtr;
    private PlayerDir playerDir;
    private PlayerAttack playerAttack;

    public PlayerMoveState playerMoveState;
    private float speed = 4;
    public bool isMoving = false;

	void Start ()
	{
	    playerDir = GetComponent<PlayerDir>();
        playerAttack = GetComponent<PlayerAttack>();
	    playerCtr = GetComponent<CharacterController>();
    }

    void Update()
    {
	    if (playerAttack.state == PlayerState.ControlWalk)
	    {
            float distance = Vector3.Distance(playerDir.targetPositon, transform.position);
            if (distance > 0.1f)
            {
                isMoving = true;
                playerCtr.SimpleMove(transform.forward * speed);
                playerMoveState = PlayerMoveState.Walk;
            }
            else
            {
                isMoving = false;
                playerMoveState = PlayerMoveState.Idle;
            }
        }
	    else
	    {
	    }
    }

    public void SimpleMove(Vector3 targetPos)
    {
        transform.LookAt(targetPos);
        playerCtr.SimpleMove(transform.forward * speed);
    }
}
