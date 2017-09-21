using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : SingletonObject {
    private Fading fadeControl;

    private void Start()
    {
        fadeControl = this.GetComponent<Fading>();
    }

    void Update () {
        if (Input.GetKey(KeyCode.Space)){
            StartCoroutine(ChangeLevel("Main"));            
        }		
	}

    IEnumerator ChangeLevel(string SceneName)
    {
        fadeControl.BeginFade(1);
        yield return new WaitForSeconds(fadeControl.fadeSpeed);
        Scenes.LoadScene("Main");
    }
}
