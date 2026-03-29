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
            //Subscribe to the score change event so UI updates only when score changes
            scoreManager.OnScoreChanged += UpdateScoreUI;
            
            //Set initial UI value (before any events are triggered)
            UpdateScoreUI(scoreManager.count);
        }
    }
    
    private void UpdateScoreUI(int newScore)
    {
        countText.text = "Eggs collected: " + newScore;
    }
}