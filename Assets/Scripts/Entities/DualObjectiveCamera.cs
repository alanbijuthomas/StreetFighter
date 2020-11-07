using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class for dual objective camera
public class DualObjectiveCamera : MonoBehaviour {
  // transform variable for left target
  public Transform leftTarget;
  // transform variable for right target
	public Transform rightTarget;

  // float variable for minimum distance
	public float minDistance;

  // Update is called once per frame
  void Update() {
    // calculate the distance between the left and right target
    float distanceBetweenTargets = Mathf.Abs(leftTarget.position.x - rightTarget.position.x) * 2;
    // get the center position between the left and right target
    float centerPosition = (leftTarget.position.x + rightTarget.position.x) / 2;

    // set new position appropriately
    transform.position = new Vector3 (
      centerPosition, transform.position.y,
      distanceBetweenTargets > minDistance? -distanceBetweenTargets: -minDistance
      );
  }
}
