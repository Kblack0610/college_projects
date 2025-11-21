using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class UtilityJoystick : MonoBehaviour {

	private float h3;
	private float v3;
	public GameObject botHighlight;
	public GameObject rightHighlight;

	public GameObject leftHighlight;

void Awake() {

	botHighlight.SetActive(false);
	rightHighlight.SetActive(false);
	leftHighlight.SetActive(false);
}

void Update() {

	Debug.Log("h3: " + h3 + "v3: " + v3);

	//Right
	if (h3>0)
	{

	}
	else
	{

	}
}

	void FixedUpdate () {
	
	float h3 = CnInputManager.GetAxis("Horizontal3");
	float v3 = CnInputManager.GetAxis("Vertical3");

	

}



}
