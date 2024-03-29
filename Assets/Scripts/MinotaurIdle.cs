﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurIdle : StateMachineBehaviour
{

    public float timer;
    public float minTime;
    public float maxTime;

    private int action;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime,maxTime);
        action = Random.Range(1,5);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

      if(timer <= 0 && action>=3)
      animator.SetTrigger("Move");

      if(timer <= 0 && action == 2)
      animator.SetTrigger("Spin Atk");

      if(timer <= 0 && action == 1)
      animator.SetTrigger("Atk");

      else if(timer>0)
      {
          timer -= Time.deltaTime;
      }  
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
