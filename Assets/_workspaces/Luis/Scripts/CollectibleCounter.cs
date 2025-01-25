using UnityEngine;

public class CollectibleCounter : MonoBehaviour
{
    [SerializeField]
    private int counter = 0;

    [SerializeField]
    private int totalOnLevel = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RegisterCollectible()
    {
        totalOnLevel++;
    }

    public void ItemCollected()
    {
        counter++;
    }

    public int GetTotalCollectibles()
    {
        return totalOnLevel;
    }

    public int GetCollectedNumber()
    {
        return counter;
    }
}
