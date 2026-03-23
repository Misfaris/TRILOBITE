using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour


{
    public TMP_Text countText;
    [SerializeField] private ScoreManager scoreManager;
    
    // Update is called once per frame
    void Update()
    {
        
        if (scoreManager == null)
        {
            countText.text = "Eggs collected: 0";
            return;
        }
        countText.text = "Eggs collected:"+ scoreManager.count;
    }
}
