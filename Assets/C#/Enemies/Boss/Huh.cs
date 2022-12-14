using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huh : StateMachineBehaviour
{
    Boss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        if (boss.health <= boss.health / 3)
        {
            animator.SetBool("SecondForm", true);
        }
    }
}
