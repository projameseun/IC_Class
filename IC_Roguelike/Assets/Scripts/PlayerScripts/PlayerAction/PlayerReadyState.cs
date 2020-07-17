﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReadyState : StateMachineBehaviour
{
    PlayerCharacter player;
    Transform playerTransform;
    TouchPanelController touchPanel;
    Enemy enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<PlayerCharacter>();
        playerTransform = animator.GetComponent<Transform>();
        touchPanel = FindObjectOfType<TouchPanelController>();
        enemy = FindObjectOfType<Enemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (touchPanel.isClick == true)
        {
            animator.SetBool("IsMove", true);
            animator.SetBool("IsReady", false);
        }

        if (player.atkDelay <= 0)
            animator.SetTrigger("Attack");

        touchPanel.DirectionPlayer();
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
