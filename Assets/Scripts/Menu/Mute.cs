using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour {
	public bool Muted;

	public void MuteGame()
    {
		AudioListener.pause = !AudioListener.pause;
        Muted = AudioListener.pause;
	}
}
