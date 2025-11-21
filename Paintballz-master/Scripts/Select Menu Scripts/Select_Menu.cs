using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class Select_Menu : MonoBehaviour {
	
	public Input selectButton;

	public GameObject MainMenu;
	public GameObject Menu1;
	public GameObject Menu2;
	public GameObject Menu3;
	public GameObject Menu4;
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

		//MainMenu.SetActive(true);
		//Menu1.SetActive(false);
		//Menu2.SetActive(false);
		//Menu3.SetActive(false);
		//Menu4.SetActive(false);
		
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

	public void OnClickBack () {

		MainMenu.SetActive(true);
		Menu1.SetActive(false);
		Menu2.SetActive(false);
		Menu3.SetActive(false);
		Menu4.SetActive(false);
		
		
	}

	public void OnClickSelect () {
		Debug.Log("selectClick");

        ////Option 1
        //if (selected1 == true)
        //{
        //    MainMenu.SetActive(false);
        //    Menu1.SetActive(true);
        //}
        //else
        //{
        //    MainMenu.SetActive(true);
        //    Menu1.SetActive(false);
        //}

        ////Option 2
        //if (selected2 == true)
       // {
        //    MainMenu.SetActive(false);
        //    Menu2.SetActive(true);
       // }
        //else
       // {
        //    MainMenu.SetActive(true);
        //    Menu2.SetActive(false);
       // }

        ////Option 3
        //if (selected3 == true)
       // {
        //    MainMenu.SetActive(false);
        //    Menu3.SetActive(true);
       // }
        //else
       // {
        //    MainMenu.SetActive(true);
        //    Menu3.SetActive(false);
       // }

        //Option 4
        //if (selected4 == true)
       // {
       //     MainMenu.SetActive(false);
        //    Menu4.SetActive(true);
       // }
       // else
       // {
       //     MainMenu.SetActive(true);
        //    Menu4.SetActive(false);
       // }
	}
}
