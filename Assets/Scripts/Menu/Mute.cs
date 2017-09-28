using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour {
	public bool muted;

	public void MuteGame()
    {
		AudioListener.pause = !AudioListener.pause;
        muted = AudioListener.pause;
	}
}
