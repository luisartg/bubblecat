using UnityEngine;

public class CollectableCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        // scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        UpdateScoreText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddPoint();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SubtractPoint();
        }
    }

    public void AddPoint()
    {
        score++;
        UpdateScoreText();
    }

    public void SubtractPoint()
    {
        score--;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = ":  " + score;
    }
}
