using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInfo : MonoBehaviour {
	private GameObject changeGUI;

	void Start ()
    {
		changeGUI = GameObject.Find("ControllerInfo");
		changeGUI.SetActive(false);
    }
	
	// Update is called once per frame
	public void GUI()
    {
        changeGUI.SetActive(!changeGUI.activeSelf);
	}
}
