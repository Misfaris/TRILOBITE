using UnityEngine;

public class ScoreManager : MonoBehaviour

{
    
    // Allows other scripts to access the one ScoreManager in the scene but only ScoreManager can set the value
    public static ScoreManager Instance { get; private set; }
    public int totalEggs = 30;
    
    //Number of eggs collected
    public int count { get; private set; }
    
    private void Awake()
    {
        //Make sure there is only one ScoreManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
    }
    
    
    // Public method other scripts can call to add an egg.
    public void AddEgg(int amount)
    {
        count += amount;
        Debug.Log("Eggs collected: " + count);

        if (count >= totalEggs)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.WinRun();
            } 
        }
    }
}
