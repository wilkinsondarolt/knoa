using System.Collections;
using System.Collections.Generic;
using UnityEngine; 


public class Pause : MonoBehaviour {
	public bool Paused;

	void Start ()
    {
		Paused = false;			
	}
	
	void Update ()
    {
		if (Input.GetKeyDown (KeyCode.Escape))
        {
			Paused = !Paused;
			AudioListener.pause = !AudioListener.pause;
		}
		if (Paused)
			Time.timeScale = 0;
		else if (!Paused) 
			Time.timeScale = 1;	
	}


	public void PauseGame()
    {
        Paused = !Paused;
		AudioListener.pause = !AudioListener.pause;

		if (Paused)
			Time.timeScale = 0;
		else if (!Paused)
			Time.timeScale = 1;
	}


}
