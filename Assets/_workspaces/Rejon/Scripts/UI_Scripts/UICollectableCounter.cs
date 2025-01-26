using UnityEngine;

public class UICollectableCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    //private int score = 0;
    private CollectibleCounter collectibleCounter;


    void Start()
    {
        // scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        collectibleCounter = FindFirstObjectByType<CollectibleCounter>();
        UpdateScoreText();
        
    }

    // public void AddPoint()
    // {
    //     score++;
    //     UpdateScoreText();
    // }

    // public void SubtractPoint()
    // {
    //     score--;
    //     UpdateScoreText();
    // }

    private void UpdateScoreText()
    {
        scoreText.text = $"{collectibleCounter.GetCollectedNumber()} / {collectibleCounter.GetTotalCollectibles()}";   
    }
}
