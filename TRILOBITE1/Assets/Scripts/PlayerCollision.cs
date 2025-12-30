using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"TRIGGER: {other.name} | trigger={other.isTrigger}");

        //Ignore floor
        if (other.CompareTag("Floor")) return;
        
        //Collect eggs
        if (other.CompareTag("Egg"))
        {
            other.gameObject.SetActive(false);
            if (ScoreManager.Instance == null)
            {
                Debug.LogError("ScoreManager.Instance is NULL");
                return;
            }
            
            ScoreManager.Instance.AddEgg(1);
            return;
        }
        
        //FAIL only on obstacles
        if (!other.CompareTag("Obstacle")) return;

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is NULL");
            return;
        }
        GameManager.Instance.FailRun();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}