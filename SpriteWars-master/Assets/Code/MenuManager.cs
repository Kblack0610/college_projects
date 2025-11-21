using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public int menuID = 0;
    public GameObject[] menuPanels;
    public GameObject gameEndPanel;
    public GameObject optionsPanel;
    public GameObject loadoutPanel;

    // Use this for initialization
    void Start()
    {
        menuPanels = GameObject.FindGameObjectsWithTag("MenuPanel");

        // gameEndPanel = GameObject.Find("GameEndPanel");
        // gameEndPanel.gameObject.SetActive(false);
        // 
        // menuPanels = GameObject.FindGameObjectsWithTag("MenuPanel");
    }

    public void switchToMenu(int menuID)
    {
        // foreach (GameObject panel in menuPanels)
        // {
        //     //            panel.gameObject.renderer.enabled=false;
        //     panel.gameObject.SetActive(false);
        //     Debug.Log(panel.name);
        // }
        hideMenus();

        switch (menuID)
        {
            case 0:
                loadoutPanel.gameObject.SetActive(true);
                break;
            case 1:
                optionsPanel.gameObject.SetActive(true);
                break;
            case 2:
                gameEndPanel.gameObject.SetActive(true);
                break;
        }
    }


    public void hideMenus()
    {
        loadoutPanel.gameObject.SetActive(false);
        optionsPanel.gameObject.SetActive(false);
        gameEndPanel.gameObject.SetActive(false);

        // foreach (GameObject panel in menuPanels)
        // {
        //     panel.gameObject.SetActive(false);
        //     Debug.Log(panel.name);
        // }


    }

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
}