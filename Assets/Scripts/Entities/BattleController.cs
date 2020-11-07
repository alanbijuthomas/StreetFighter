using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class for battle controller
public class BattleController : MonoBehaviour {
  // int variable for round time
  public int roundTime = 99;
  // float variable for last time update
	private float lastTimeUpdate = 0;
  // boolean variable for battle started
  private bool battleStarted;
  // boolean variable for battle ended
  private bool battleEnded;

  // fighter variable for player 1
  public Fighter player1;
  // fighter variable for player 2
  public Fighter player2;

  // banner controller variable for banner
  public BannerController banner;

  // audio source variable for audio player
  public AudioSource audioPlayer;
  // audio clip variable for background music
	public AudioClip backgroundMusic;

  // Start is called before the first frame update
  void Start() {
    // show the fight banner
    banner.showFight();
  }

  // ends game
  private void endGame() {
    // check which player has less health, set it to 0
    if (player1.healthPercent > player2.healthPercent) {
      player2.health = 0;
    } else {
      player1.health = 0;
    }
  }

  // Update is called once per frame
  void Update() {
    // if the battle hasn't started and the banner has finished animating
    if (!battleStarted && !banner.isAnimating) {
      // start the battle
      battleStarted = true;
      // enable the players
      player1.enable = true;
			player2.enable = true;
      // play the background music
      GameUtils.playSound(backgroundMusic, audioPlayer);
    }

    // if the battle has started and the battle hasn't started
    if (battleStarted && !battleEnded) {
      // check if time needs updating
      if (roundTime > 0 && Time.time - lastTimeUpdate > 1) {
        // update the time
        roundTime--;
        lastTimeUpdate = Time.time;
        // if it's 0, end the game
        if (roundTime == 0) {
          endGame();
        }
      }

      // if a player has died, show the appropriate banner and end the battle
      if (player1.healthPercent <= 0) {
        banner.showYouLose();
        battleEnded = true;
      } else if (player2.healthPercent <= 0) {
        banner.showYouWin();
        battleEnded = true;
      }
    }
  }
}
