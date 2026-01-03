using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour

{
    public TextMeshProUGUI winText;
    public TextMeshProUGUI gameOverText;
    public GameObject introPanel;
    private bool runStarted;
    private bool runOver;

    public static GameManager Instance;
    // This is a STATIC reference to the only GameManager, "static" means it belongs to the class itself
    // I create this Instance to allow other scripts to call it

    private void Awake()
        // Awake() is called by Unity before Start()

    {
        if (Instance != null)
            // If an Instance already exists, it means there's already a GameManager in the scene
        {
            Destroy(gameObject);
            // Destroy THIS GameManager so we don’t end up with two
            return;
            // Exit Awake() early
        }

        Instance = this;
        // If no GameManager exists yet, this object becomes the Instance
        // From now on, other scripts can access it
    }

    private void Start()
    {
        Time.timeScale = 0;
        runStarted = false;
        runOver = false;
        introPanel.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            HandleRKey();
        }

    }

    private void HandleRKey()
    {
        if (!runStarted)
        {
            StartRun();
        }
        else if (runOver)
        {
            RestartRun();
        }
    }

    public void StartRun()
        {
            Time.timeScale = 1;
            runStarted = true;
            runOver = false;
            introPanel.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(false);
            winText.gameObject.SetActive(false);
        }

        public void FailRun()
            // This method means "the run has failed"
            // Any system (collision, timer, pit, enemy) can call this to end a run
        {
            if (runOver) return;
            // If the run already ended, do nothing

            runOver = true;
            // Mark the run as over so future calls are ignored

            gameOverText.gameObject.SetActive(true);
            // Show GAME OVER text

            Time.timeScale = 0f;
            // Freeze the entire game. This is TEMPORARY DEBUG BEHAVIOR
        }


        public void WinRun()
        {
            Time.timeScale = 0;
            runStarted = true;
            runOver = true;
            introPanel.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(false);
            winText.gameObject.SetActive(true);
        }

        public void RestartRun()
        {

            // Unfreeze time
            Time.timeScale = 1f;
            runOver = false;

            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
            );
        }
    }
