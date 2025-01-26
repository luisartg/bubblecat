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

    private string gameScene = "Level01";

    private void Awake()
    {
    }

    void Start()
    {
        AudioManager.Instance.PlayMusic("menu");
        panelCredits.SetActive(false);
        // panelOptions.SetActive(false);
        panelMenu.SetActive(true);
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
        PlaySound("pop high");
        // AudioManager.Instance.PlaySFX("pop high");
        StartCoroutine(LoadSceneAfterSecond());
    }

    IEnumerator LoadSceneAfterSecond()
    {
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(gameScene);
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
        AudioManager.Instance.PlaySFX("pop high");
        StartCoroutine(LoadCreditsAfterSecond());
    }

      IEnumerator LoadCreditsAfterSecond()
    {
        yield return new WaitForSeconds(1.1f);
              SwitchMenuPanelState();
        SwitchCreditsPanelState();
        Debug.Log("Show credits: " + panelCredits.activeInHierarchy);
    }

    public void ExitGameApp()
    {
        AudioManager.Instance.PlaySFX("pop high");
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

    private void PlaySound(string soundName)
    {
        AudioManager.Instance.PlaySFX(soundName);
    }
}