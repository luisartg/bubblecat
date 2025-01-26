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
        AudioManager.Instance.PlayMusic("Mu_Niv1");
        Debug.Log("Game Started");
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        // loseScreen.SetActive(false);
        winScreen.SetActive(false);
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
            StartCoroutine(PauseOff());
        }
        else
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
    }

    IEnumerator PauseOff()
    {
        yield return new WaitForSeconds(1.1f);
        AudioManager.Instance.PlaySFX("pop high");
        pauseScreen.SetActive(false);
    }

    //public void PlayAgain()
    //{
    //    // SceneManager.LoadScene("InGameLevel");
    //    AudioManager.Instance.PlaySFX("pop low");
    //    // Application.LoadLevel(Application.loadedLevel);
    //    StartCoroutine(PlayAgainAfterSecond());

    //}
    //IEnumerator PlayAgainAfterSecond()
    //{
    //    yield return new WaitForSeconds(1.1f);
    //    Application.LoadLevel(Application.loadedLevel);
    //}

    public void ToggleOptions()
    {
        Debug.Log("Pantalla de opciones: ");
    }

    public void ExitGame()
    {
        AudioManager.Instance.PlaySFX("pop high");
        StartCoroutine(LoadExitGame());
    }
    IEnumerator LoadExitGame()
    {
        yield return new WaitForSeconds(1.1f);
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