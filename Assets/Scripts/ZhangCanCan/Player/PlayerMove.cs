using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController playerCtr;
    private PlayerDir playerDir;
    private PlayerAttack playerAttack;
    private Animator playerAnimator;

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
                
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    playerMoveState = PlayerMoveState.Run;
                }
                else
                {
                    playerMoveState = PlayerMoveState.Walk;
                }
                print(playerMoveState);
            }
            else
            {
                isMoving = false;
                playerMoveState = PlayerMoveState.Idle;
            }
        }	   
    }

    public void SimpleMove(Vector3 targetPos)
    {
        transform.LookAt(targetPos);
        playerCtr.SimpleMove(transform.forward * speed);
    }

    //人物奔跑
    void PlayerRun()
    {
       
    }
}
