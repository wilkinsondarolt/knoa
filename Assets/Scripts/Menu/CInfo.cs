using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInfo : MonoBehaviour {

	private int x;
	GameObject changeGUI;

	// Use this for initialization
	void Start () {
		changeGUI = GameObject.Find("ControllerInfo");
		changeGUI.SetActive(false);
		x = 1;
			}
	
	// Update is called once per frame
	public void GUI(){

		if (x == 0) {
			changeGUI.SetActive(false);
			x = 1;
		
		} 
		else {
			changeGUI.SetActive(true);
			x = 0;
		
		}
	}
}
