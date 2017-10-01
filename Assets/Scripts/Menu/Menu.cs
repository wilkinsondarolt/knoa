using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : SingletonObject
{
    void Update ()
    {
		if (Input.GetKey(KeyCode.Return)){
            Scenes.LoadScene("Prologue");
        }		
	}
}
