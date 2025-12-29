using UnityEngine;

public class GameManager : MonoBehaviour

{
    public static GameManager Instance;
    // This is a STATIC reference to the only GameManager, "static" means it belongs to the class itself
    // I create this Instance to allow other scripts to call it

    private bool runOver;
    // This tracks whether the run has already ended.

    private void Awake()
    // Awake() is called by Unity before Start()
    
    {
        if (Instance != null)
        // If an Instance already exists, it means there's already a GameManager in the scene.
        {
            Destroy(gameObject);
            // Destroy THIS GameManager so we don’t end up with two
            return;
            // Exit Awake() early.
        }

        Instance = this;
        // If no GameManager exists yet, this object becomes the Instance
        // From now on, other scripts can access it
    }
    
    
    private void Update()
    {
        // Allow restart only after failure
        if (runOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartRun();
        }
    }

    public void FailRun()
    // This method means "the run has failed".
    // Any system (collision, timer, pit, enemy) can call this to end a run
    {
        if (runOver) return;
        // If the run already ended, do nothing.
     
        runOver = true;
        // Mark the run as over so future calls are ignored.

        Debug.Log("RUN FAILED");
        // Print a message to the Console to confirm that failure logic is being triggered correctly.

        Time.timeScale = 0f;
        // Freeze the entire game. This is TEMPORARY DEBUG BEHAVIOR.
    }
    
    private void RestartRun()
    {
        Debug.Log("RESTART");

        // Unfreeze time
        Time.timeScale = 1f;

        runOver = false;
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
}
}