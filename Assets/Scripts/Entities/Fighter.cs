using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class for fighter
public class Fighter : MonoBehaviour {

  // player type variable
  public enum PlayerType {
    HUMAN, AI
  };

  // static float variable for maximum health
  public static float MAX_HEALTH = 100f;
  // float variable for health, initially maximum
  public float health = MAX_HEALTH;

  // string variable for fighter name
  public string fighterName;
  // fighter variable for opponent
  public Fighter opponent;
  // boolean variable for enable
  public bool enable;

  // player type variable for player
  public PlayerType player;
  // fighter states variable for current state, initially idle
  public FighterStates currentState = FighterStates.IDLE;

  // animator variable for animator
  protected Animator animator;
  // rigid body variable for body
	private Rigidbody myBody;
  // audio source variable for audio player
  private AudioSource audioPlayer;

  // float variable for random
  private float random;
  // float variable for last random update
  private float lastRandomUpdate;

  // Start is called before the first frame update
  void Start() {
    // set the rigid body
    myBody = GetComponent<Rigidbody>();
    // set the animator
		animator = GetComponent<Animator>();
    // set the audio source
    audioPlayer = GetComponent<AudioSource>();
  }

  // update the human input
  public void UpdateHumanInput() {
    // set the animator's boolean for walk
		if (Input.GetAxis("Horizontal") > 0.1) {
			animator.SetBool("WALK", true);
		} else {
			animator.SetBool("WALK", false);
		}

    // set the animator's boolean for walk back
    if (Input.GetAxis("Horizontal") < -0.1) {
      animator.SetBool("WALK_BACK", true);
    } else {
      animator.SetBool("WALK_BACK", false);
    }

    // set the animator's boolean for duck
    if (Input.GetAxis("Vertical") < -0.1) {
      animator.SetBool("DUCK", true);
    } else {
      animator.SetBool("DUCK", false);
    }

    // trigger jump if W pressed
    if (Input.GetKeyDown(KeyCode.W)) {
      animator.SetTrigger("JUMP");
    }

    // trigger punch if space pressed
    if (Input.GetKeyDown(KeyCode.Space)) {
      animator.SetTrigger("PUNCH");
    }

    // trigger kick if K pressed
    if (Input.GetKeyDown(KeyCode.K)) {
      animator.SetTrigger("KICK");
    }

    // set the animator's boolean for defend if J is held down
    if (Input.GetKey(KeyCode.J)) {
      animator.SetBool("DEFEND", true);
    } else {
      animator.SetBool("DEFEND", false);
    }

    // trigger hadoken if H pressed
    if (Input.GetKeyDown(KeyCode.H)) {
      animator.SetTrigger("HADOKEN");
    }
	}

  // update the ai input
  public void UpdateAIInput() {
    // set the animator's boolean for defending
    animator.SetBool("DEFENDING", defending);
    // set the animator's boolean for invulnerable
    animator.SetBool("INVULNERABLE", invulnerable);
    // set the animator's boolean for enable
    animator.SetBool("ENABLE", enable);
    // set the animator's boolean for opponent attacking
    animator.SetBool("OPPONENT_ATTACKING", opponent.attacking);

    // set the animator's distance
    animator.SetFloat("distance", getDistance());

    // if it's been a second since last random update, update the random value
    if (Time.time - lastRandomUpdate > 1) {
      random = Random.value;
      lastRandomUpdate = Time.time;
    }
    // set the animator's random
    animator.SetFloat("random", random);
  }

  // Update is called once per frame
  void Update() {
    // set the health
    animator.SetFloat("health", healthPercent);

    // set the opponent health, if initial, set to 1
    if (opponent != null) {
      animator.SetFloat("opponent_health", opponent.healthPercent);
    } else {
      animator.SetFloat("opponent_health", 1);
    }

    // if enable
    if (enable) {
      // if player is human, update human input, else ai input
      if (player == PlayerType.HUMAN) {
        UpdateHumanInput();
      } else {
				UpdateAIInput();
			}
    }

    // if health is less than 0 and state isn't dead, set to dead
    if (health <= 0 && currentState != FighterStates.DEAD) {
      animator.SetTrigger("DEAD");
    }
  }

  // get distance between player and opponent
  private float getDistance() {
    return Mathf.Abs(transform.position.x - opponent.transform.position.x);
  }

  // hurt by attack, lose health
  public virtual void hurt(float damage) {
    // if vulnerable
    if (!invulnerable) {
      // if defending, reduce damage
      if (defending) {
        damage *= 0.33f;
      }
      // if health is greater than damage, subtract damage, else, set to 0
      if (health >= damage) {
        health -= damage;
      } else {
        health = 0;
      }

      // if health is above 0, trigger take hit animation
      if (health > 0) {
        animator.SetTrigger("TAKE_HIT");
      }
    }
	}

  // play sound clip
  public void playSound(AudioClip sound) {
    GameUtils.playSound(sound, audioPlayer);
  }

  // check whether invulnerable (taking hit or dead)
  public bool invulnerable {
    get {
      return currentState == FighterStates.TAKE_HIT || currentState == FighterStates.TAKE_HIT_DEFEND || currentState == FighterStates.DEAD;
    }
  }

  // check whether defending
  public bool defending {
    get {
      return currentState == FighterStates.DEFEND || currentState == FighterStates.TAKE_HIT_DEFEND;
    }
  }

  // check whether attacking
  public bool attacking {
    get {
      return currentState == FighterStates.ATTACK;
    }
  }

  // get health percentage
  public float healthPercent {
    get {
      return health / MAX_HEALTH;
    }
  }

  // get the body
  public Rigidbody body {
    get {
      return this.myBody;
    }
  }

}
