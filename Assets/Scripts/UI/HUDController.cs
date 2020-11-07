using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// class controls the HUD
public class HUDController : MonoBehaviour {
  // fighter variables for players
  public Fighter player1;
	public Fighter player2;

  // text variables for player tags
	public Text player1Tag;
	public Text player2Tag;

  // scrollbar variables for player health bars
  public Scrollbar player1HealthBar;
	public Scrollbar player2HealthBar;

  // text variable for timer tag
  public Text timerTag;

  // battle controller variable
  public BattleController battle;

  // Start is called before the first frame update
  void Start() {
    // set the player tags to their names
    player1Tag.text = player1.fighterName;
    player2Tag.text = player2.fighterName;
  }

  // Update is called once per frame
  void Update() {
    // get the current time and update the timer tag
    timerTag.text = battle.roundTime.ToString();

    // slowly decrease the health bars if needed
    if (player1HealthBar.size > player1.healthPercent) {
			player1HealthBar.size -= 0.01f;
		}
		if (player2HealthBar.size > player2.healthPercent) {
			player2HealthBar.size -= 0.01f;
		}
  }
}
