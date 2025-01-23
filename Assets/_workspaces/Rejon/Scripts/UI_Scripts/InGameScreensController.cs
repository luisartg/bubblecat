using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameScreensController : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject winScreen;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started");
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        // loseScreen.SetActive(false);
        // winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            ShowWinScreen();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ShowLoseScreen();
        }
    }

    public void PauseGame()
    {
        if (pauseScreen.activeInHierarchy)
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        // SceneManager.LoadScene("InGameLevel");
        Application.LoadLevel(Application.loadedLevel);

    }

    public void ToggleOptions()
    {
        Debug.Log("Pantalla de opciones: ");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ShowWinScreen()
    {
        Time.timeScale = 0f;
        winScreen.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        Time.timeScale = 0f;
        loseScreen.SetActive(true);
    }
}