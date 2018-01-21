using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMove playerMove;
    private PlayerAttack playerAttack;
    private Animator playerAnimator;

    void Start ()
	{
	    playerMove = GetComponent<PlayerMove>();
	    playerAttack = GetComponent<PlayerAttack>();
        playerAnimator = GetComponent<Animator>();
	}
	 
    void LateUpdate () {
     
	    if (playerAttack.state == PlayerState.ControlWalk)
	    {
	        if (playerMove.playerMoveState == PlayerMoveState.Idle)
	        {
                playerAnimator.SetBool("PlayerMove",false);
            }
            else if (playerMove.playerMoveState == PlayerMoveState.Walk)
	        {
	            playerAnimator.SetBool("PlayerMove", true);
	            //playerAnimator.SetFloat("PlayerMoveTree", 0);
	            playerAnimator.SetFloat("PlayerMoveTree", 1);
            }
	        else if (playerMove.playerMoveState == PlayerMoveState.Run)
	        {
	            playerAnimator.SetBool("PlayerMove", true);
	            playerAnimator.SetFloat("PlayerMoveTree", 1);
            }
       }
       else if (playerAttack.state == PlayerState.NormalAttack)
	   {
	        if (playerAttack.attackState == PlayerAttackState.Moving)
	        {
	            playerAnimator.SetBool("PlayerMove", true);
	            playerAnimator.SetFloat("PlayerMoveTree", 1);
            }
            else if(playerAttack.attackState == PlayerAttackState.Attack && playerAttack.attackState == PlayerAttackState.Idle)
	        {
	            playerAnimator.SetBool("PlayerMove", false);
            }
	   }
	}

}
