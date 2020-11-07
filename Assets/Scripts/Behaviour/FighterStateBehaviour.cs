using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class for fighter states
public class FighterStateBehaviour : StateMachineBehaviour {

  // fighter states variable for behavior state
  public FighterStates behaviorState;
  // audio clip variable for sound effect
  public AudioClip soundEffect;

  // float variable for horizontal force
  public float horizontalForce;
  // float variable for vertical force
	public float verticalForce;

  // fighter variable for fighter
	protected Fighter fighter;

  // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    // set the fighter
    if (fighter == null) {
      fighter = animator.gameObject.GetComponent<Fighter>();
    }

    // set the fighter's current state to behavior state
    fighter.currentState = behaviorState;

    // if available, play a sound effect
    if (soundEffect != null) {
      fighter.playSound(soundEffect);
    }

    // add a vertical force
    fighter.body.AddRelativeForce(new Vector3(0, verticalForce, 0));
  }

  // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    // add a horizontal force
    fighter.body.AddRelativeForce(new Vector3(0, 0, horizontalForce));
  }

  // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
  //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  //{
  //
  //}

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
