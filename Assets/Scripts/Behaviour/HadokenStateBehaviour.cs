using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class for hadoken state derives fighter state
public class HadokenStateBehaviour : FighterStateBehaviour {
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    // use derived method
    base.OnStateEnter(animator, stateInfo, layerIndex);

    // find the x coordinate of fighter
    float fighterX = fighter.transform.position.x;

    // create an instance of hadoken
    GameObject instance = Object.Instantiate (
      Resources.Load("SFX/Hadoken"),
      new Vector3(fighterX, 1, 0),
      Quaternion.Euler(0, 0, 0)
      ) as GameObject;

    // make and set the hadoken object
    Hadoken hadoken = instance.GetComponent<Hadoken>();
    // set the caster
    hadoken.caster = fighter;
  }
}
