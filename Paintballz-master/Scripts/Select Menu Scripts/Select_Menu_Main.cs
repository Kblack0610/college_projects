using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class Select_Menu_Main : MonoBehaviour {
	
	public Input selectButton;

	public GameObject mainMenu;
	public GameObject menuA;
	public GameObject menuB;
	public GameObject menuC;
	public GameObject menuD;
	public GameObject highlight1;
	public GameObject highlight2;
	public GameObject highlight3;
	public GameObject highlight4;

    private bool selected1 = false;
    private bool selected2 = false;
    private bool selected3 = false;
    private bool selected4 = false;

	
	void Start () {
		highlight1.SetActive(false);
		highlight2.SetActive(false);
		highlight3.SetActive(false);
		highlight4.SetActive(false);

		mainMenu.SetActive(true);
		menuA.SetActive(false);
		menuB.SetActive(false);
		menuC.SetActive(false);
		menuD.SetActive(false);
		
	}

		
	void FixedUpdate () {
		float h = CnInputManager.GetAxis("Horizontal");
		float v = CnInputManager.GetAxis("Vertical");
		//Debug.Log(h + "," + v);

        //Option 1
		if (h > 0 && v > 0) 
		{
			highlight1.SetActive(true);
			selected1 = true;			
		} 
		else 
		{
			highlight1.SetActive(false);
            selected1 = false;
		}

        //Option 2
		if (h > 0 && v < 0) 
		{
			highlight2.SetActive(true);
            selected2 = true;    
		} 
		else 
		{
			highlight2.SetActive(false);
            selected2 = false;
		}
		
        //Option 3
		if (h < 0 && v < 0) 
		{
			highlight3.SetActive(true);
            selected3 = true;
        } 
		else 
		{
			highlight3.SetActive(false);
            selected3 = false;
		} 
		
        //Option 4
		if (h < 0 && v > 0)	
		{
			highlight4.SetActive(true);
            selected4 = true;
		} 
		else 
		{
			highlight4.SetActive(false);
            selected4 = false;
		}

       
       
        
	}

	public void OnClickSelect () {
		Debug.Log("selectClick");

        //Option 1
        if (selected1 == true)
        {
            mainMenu.SetActive(false);
            menuA.SetActive(true);
        }
        else
        {
            //mainMenu.SetActive(true);
            menuA.SetActive(false);
        }

        //Option 2
        if (selected2 == true)
        {
            mainMenu.SetActive(false);
            menuB.SetActive(true);
        }
        else
        {
            //mainMenu.SetActive(true);
            menuB.SetActive(false);
        }

        //Option 3
        if (selected3 == true)
        {
            mainMenu.SetActive(false);
            menuC.SetActive(true);
        }
        else
        {
            //mainMenu.SetActive(true);
            menuC.SetActive(false);
        }

        //Option 4
        if (selected4 == true)
        {
            mainMenu.SetActive(false);
            menuD.SetActive(true);
        }
        else
        {
            //mainMenu.SetActive(true);
            menuD.SetActive(false);
        }
	}

	public void OnClickBack () {
		
	}
}
