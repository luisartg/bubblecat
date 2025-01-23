using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelCredits;
    [SerializeField] private GameObject panelOptions;

    private void Awake()
    {
        AudioManager.Instance.PlayMusic("menu");
    }

    void Start()
    {
        panelMenu.SetActive(true);
        panelCredits.SetActive(false);
        panelOptions.SetActive(false);
    }

    #region Update

    // Update is called once per frame
    void Update()
    {
    }

    #endregion

    public void StartGame()
    {
        // Debug.Log("Prueba de press");
        SceneManager.LoadScene("HowToPlay");
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("IngameLevel");

    }

    public void ToggleOptions()
    {
        Debug.Log("Pantalla de opciones: ");
        SwitchMenuPanelState();
        SwitchOptionsPanelState();
    }

    public void ToggleCredits() 
    {
        SwitchMenuPanelState();
        SwitchCreditsPanelState();
        Debug.Log("Show credits: " + panelCredits.activeInHierarchy);
    }

    public void ExitGameApp()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    private void SwitchMenuPanelState()
    {
        if (panelMenu.activeInHierarchy)
        {
            panelMenu.SetActive(false);
        }
        else
        {
            panelMenu.SetActive(true);
        }
    }

    private void SwitchCreditsPanelState()
    {
        if (panelCredits.activeInHierarchy)
        {
            panelCredits.SetActive(false);
        }
        else
        {
            panelCredits.SetActive(true);
        }
    }
    
    private void SwitchOptionsPanelState()
    {
        if (panelOptions.activeInHierarchy)
        {
            panelOptions.SetActive(false);
        }
        else
        {
            panelOptions.SetActive(true);
        }
    }
}