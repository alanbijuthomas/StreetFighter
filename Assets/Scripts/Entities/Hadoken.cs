using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class for Hadoken
public class Hadoken : MonoBehaviour {
  // fighter variable for caster
  public Fighter caster;
  // float variable for movement force
  public float movementForce = 200;
  // float variable for damage
  public float damage;

  // rigid body variable for body
  private Rigidbody body;
  // float variable for creation time
  private float creationTime;

  // Start is called before the first frame update
  void Start() {
    // set the creation time
    creationTime = Time.time;
    // set the hadoken
    body = GetComponent<Rigidbody>();
    // apply a movement force to the hadoken
    body.AddRelativeForce(new Vector3(movementForce, 0, 0));
  }

  // Update is called once per frame
  void Update() {
    // destroy the hadoken after 3 seconds
    if (Time.time - creationTime > 3) {
      Destroy(gameObject);
    }
  }

  void OnCollisionEnter (Collision col) {
    // get the fighter hadoken collides with
    Fighter fighter = col.gameObject.GetComponent<Fighter>();
    // transfer damage and destroy the hadoken
    if (fighter != null && fighter != caster) {
      fighter.hurt(damage);
      Destroy(gameObject);
    }
  }
}
