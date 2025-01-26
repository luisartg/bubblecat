using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScrene : MonoBehaviour
{
    private Animator[] animator = new Animator[3];
    public GameObject[] gameObjects = new GameObject[3];
    [TextArea(3, 10)]
    public string[] dialogues;
    public TMPro.TextMeshProUGUI dialogueText;
    int currentPanel = 0;
    public Image scoreImage;
    public TMPro.TextMeshProUGUI scoreText;
    private bool nextKeyToTitle = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // animator[0] = gameObjects[0].GetComponent<Animator>();
        // animator[1] = gameObjects[1].GetComponent<Animator>();
        // animator[2] = gameObjects[2].GetComponent<Animator>();
        foreach (var go in gameObjects)
        {
            go.SetActive(false);
        }
        ActivatePanel(currentPanel);
    }

    // Update is called once per frame
    void Update()
    {
        nextKeyToTitle = false;

        if (Input.anyKeyDown)
        {
            currentPanel++;
            if (nextKeyToTitle)
            {
                SceneManager.LoadScene("TitleScreen");
            }
            if (currentPanel >= gameObjects.Length)
            {
                // currentPanel = 0; //
                ShowScore();
            }
            else
            {
                ActivatePanel(currentPanel);
            }
        }



        // if (Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     ActivatePanel(0);
        //     // animator[0].SetTrigger("StartAnimPanel1");
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     ActivatePanel(1);
        //     print("Activating 2");
        //     animator[0].SetTrigger("StartAnimPanel2");
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha3))
        // {
        //     ActivatePanel(2);
        //     animator[0].SetTrigger("StartAnimPanel3");

        // }

        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     DeactivatePanel(0);
        // }

        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     DeactivatePanel(1);
        //     print("Deactivating 2");
        // }

        // if (Input.anyKeyDown)
        // {
        //     DeactivatePanel(2);
        // }
    }

    public void ActivatePanel(int index)
    {
        gameObjects[index].SetActive(true);
        Animator currentAnimator = gameObjects[index].GetComponent<Animator>();
        currentAnimator.SetTrigger("StartAnimPanel");
        dialogueText.text = dialogues[index];
    }

    void ShowScore()
    {
        nextKeyToTitle = true;
    }

    public void DeactivatePanel(int index)
    {
        gameObjects[index].SetActive(false);
    }



}
