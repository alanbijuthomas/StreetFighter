using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// standard class used to play sound clips
public class GameUtils {

  // method to play sounds
  public static void playSound(AudioClip clip, AudioSource audioPlayer) {
		audioPlayer.Stop();
		audioPlayer.clip = clip;
		audioPlayer.loop = false;
		audioPlayer.time = 0;
		audioPlayer.Play();
	}
}
