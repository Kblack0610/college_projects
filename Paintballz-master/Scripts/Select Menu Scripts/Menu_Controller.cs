using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Controller : MonoBehaviour {

	private float timeLeft = 5;
	
	private bool menuShown; 
	public GameObject menuObject;
	public GameObject menuText;
	public GameObject backBtn;
	public GameObject selectBtn;

	void Start () {
		menuShown = true;


	}
	
	
	void Update () {
		timeLeft -= Time.deltaTime;
		Debug.Log(timeLeft);

		if (timeLeft <= 0)
		{
			Debug.Log("Times Up");
			menuShown = false;
		}
		
		if (menuShown == false)
		{
			menuObject.SetActive(false);
			menuText.SetActive(false);
			backBtn.SetActive(false);
			selectBtn.SetActive(false);
		}
		
	}

	
}
