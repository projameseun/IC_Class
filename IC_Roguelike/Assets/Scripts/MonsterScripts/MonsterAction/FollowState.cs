﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : StateMachineBehaviour
{
    private Transform enemyTransform;
    private Enemy enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.isFind && Vector2.Distance(enemy.player.position, enemyTransform.position) > 0.7f)
        {
            enemy.TracePlayer();
        }
        else if (enemy.isFind && Vector2.Distance(enemy.player.position, enemyTransform.position) > 0.5f)
            animator.SetBool("IsReady", true);
        else
        {
            animator.SetBool("IsFollow", false);
        }
        enemy.DirectionEnemy(enemy.player.position.x, enemyTransform.position.x);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
