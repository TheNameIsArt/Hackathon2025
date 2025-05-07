using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CarlsMinigameManager : MonoBehaviour
{
    private int lives = 3;
    private int gameOverLifeAmount = 0;
    private float timePlayed;
    public GameObject gameoverUI;
    public GameObject winUI;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI scoreText;
    public string gameOverSceneName; // Add this line

    void Awake()
    {
        Time.timeScale = 1f;
    }
    void Start()
    {
        livesText.text = "Lives remaining: " + lives + "/3";
        scoreText.text = "Score: ";
    }

    void Update()
    {
        livesText.text = "Lives remaining: " + lives + "/3";

        timePlayed += Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(timePlayed); //Mathf runder til hele tal

        if (lives <= gameOverLifeAmount)
        {
            GameOver();
        }

        if (scoreText.text == "Score: 30")
        {
            Win();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            lives--;
            Debug.Log("Life lost!");
            collision.gameObject.SetActive(false);
        }
    }

    void GameOver()
    {
        Debug.Log("game over!");
        //Time.timeScale = 0f; // Game gets paused
        gameoverUI.SetActive(true);
        //SceneManager.LoadScene(gameOverSceneName); // Add this line
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Win()
    {
        Debug.Log("game over!");
        //Time.timeScale = 0f; // Game gets paused
        winUI.SetActive(true);
        //SceneManager.LoadScene(gameOverSceneName); // Add this line
    }
}
