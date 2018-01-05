using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMove move;
    private Animator animator;
//    private PlayerAttack attack;

    void Start ()
	{
	    move = GetComponent<PlayerMove>();
//	    attack = GetComponent<PlayerAttack>();
        animator = GetComponent<Animator>();
	}
	 
	void LateUpdate () {
//	    if (attack.state == PlayerState.ControlWalk)
//	    {
	    if (move.playerState == PlayerState.Idle)
	    {
             animator.SetBool("Walk", false);
             animator.SetBool("Idle",true);
        }
        else if (move.playerState == PlayerState.Walk)
	    {
	        animator.SetBool("Idle", false);
	        animator.SetBool("Walk",true);
	    }
//      }
//      else if (attack.state == PlayerState.NormalAttack)
//	    {
//	        if (attack.attack_state == AttackState.Moving)
//	        {
//	            PlayAnim("Run");
//	        }
//	    }
	}

}
