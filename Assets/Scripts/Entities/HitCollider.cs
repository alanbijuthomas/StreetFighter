using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class for hit collider
public class HitCollider : MonoBehaviour {
  // string variable for attack name
  public string attackName;
  // float variable for damage
	public float damage;

  // fighter variable for owner
	public Fighter owner;

	void OnTriggerEnter(Collider other) {
    // get the other fighter
		Fighter somebody = other.gameObject.GetComponent<Fighter>();

    // transfer damage appropriately
    if (owner.attacking) {
      if (somebody != null && somebody != owner) {
        somebody.hurt(damage);
      }
    }
	}
}
