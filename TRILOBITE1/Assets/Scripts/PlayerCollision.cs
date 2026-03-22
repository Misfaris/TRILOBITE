using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public AudioClip eggCollectionSound;
    private AudioSource playerAudio;
    [SerializeField] private float eggVolume = 1.0f;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Ignore floor
        if (other.CompareTag("Floor")) return;
        
        //Collect eggs
        if (other.CompareTag("Egg"))
        {
            other.gameObject.SetActive(false);
            if (ScoreManager.Instance == null) return;
            
            ScoreManager.Instance.AddEgg(1);
            playerAudio.PlayOneShot(eggCollectionSound, eggVolume);
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