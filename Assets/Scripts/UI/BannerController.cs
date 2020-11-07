using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class controls the banners
public class BannerController : MonoBehaviour {
  // animator variable
  private Animator animator;
  // audio player variable
	private AudioSource audioPlayer;

  // boolean stores whether banner is animating
  private bool animating;

  // Start is called before the first frame update
  void Awake() {
    // set the animator
    animator = GetComponent<Animator>();
    // set the audio player
    audioPlayer = GetComponent<AudioSource>();
  }

  // show fight banner
  public void showFight() {
    // set animating to true
		animating = true;
    // trigger animator
		animator.SetTrigger("FIGHT");
	}

  // show you win banner
	public void showYouWin() {
    // set animating to true
		animating = true;
    // trigger animator
		animator.SetTrigger("YOU_WIN");
	}

  // show you lose banner
	public void showYouLose() {
    // set animating to true
		animating = true;
    // trigger animator
		animator.SetTrigger("YOU_LOSE");
	}

  // play sound clip
  public void playSound(AudioClip sound) {
    GameUtils.playSound(sound, audioPlayer);
  }

  // set animating to false
  public void animationEnded() {
    animating = false;
  }

  // check whether animating
  public bool isAnimating {
    get {
      return animating;
    }
  }
}
