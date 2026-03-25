using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour


{
    public TMP_Text countText;
    [SerializeField] private ScoreManager scoreManager;
    
    void Start()
    {
        
        if (scoreManager != null)
        {
            scoreManager.OnScoreChanged += UpdateScoreUI;
            UpdateScoreUI(scoreManager.count);
        }
    }
    
    private void UpdateScoreUI(int newScore)
    {
        countText.text = "Eggs collected: " + newScore;
    }
}