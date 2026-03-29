using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AudioClip eggCollectionSound;
    private AudioSource playerAudio;
    [SerializeField] private float eggVolume = 1.0f;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameManager gameManager;
        
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
            scoreManager.AddEgg(1);
            playerAudio.PlayOneShot(eggCollectionSound, eggVolume);
            return;
        }
        
        //FAIL only on obstacles
        if (!other.CompareTag("Obstacle")) return;

        gameManager.FailRun();
    }
}