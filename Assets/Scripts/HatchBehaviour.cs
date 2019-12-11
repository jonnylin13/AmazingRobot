using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        HatchSounds cs = animator.GetComponent<HatchSounds>();
        if (stateInfo.IsName("hatch_close"))
        {
            cs.close();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("hatch_close")) {
            animator.SetBool("hatchOpen", true);
            var parent = animator.GetComponentInParent<Transform>();
            ObjectDelivered hatchTrigger = parent.GetComponent<ObjectDelivered>();

            if (hatchTrigger.hasObject())
                Destroy(hatchTrigger.getObjectDelivered());
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
