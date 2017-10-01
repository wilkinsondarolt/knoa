using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skipscene : MonoBehaviour {

	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
			{
				Scenes.LoadScene("Main");
			}		
	}
}
