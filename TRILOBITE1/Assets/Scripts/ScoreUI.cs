using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text countText;
    
    // Update is called once per frame
    void Update()
    {
        
        if (countText == null)
        {
            Debug.LogError("ScoreUI: countText is NOT assigned in the Inspector.");
            return;
        }
        
        if (ScoreManager.Instance == null)
        {
            countText.text = "Eggs collected: 0";
            return;
        }
        countText.text = "Eggs collected:"+ScoreManager.Instance.count;
    }
}
