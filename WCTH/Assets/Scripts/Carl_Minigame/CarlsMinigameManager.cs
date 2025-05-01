using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CarlsMinigameManager : MonoBehaviour
{
    private int lives = 3;
    private int gameOverLifeAmount = 0;
    private int score;
    private int scoreToWin = 30;
    private float timePlayed;
    public GameObject gameoverUI;
    public GameObject tryAgainUI;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI scoreText;
    public AudioSource damageSound;

    void Awake()
    {
        Time.timeScale = 1f;
    }
    void Start()
    {
        livesText.text ="Lives remaining: " + lives + "/3";
        scoreText.text ="Score: ";
    }

    void Update()
    {
        livesText.text = "Lives remaining: " + lives + "/3";
        
        timePlayed += Time.deltaTime;
        scoreText.text ="Score: " + Mathf.FloorToInt(timePlayed); //Mathf runder til hele tal
        score = + Mathf.FloorToInt(timePlayed);
        
        if (lives <= gameOverLifeAmount)
        {
            GameOver();
        }

        if (score >= scoreToWin)
        {
            Win();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            lives --;
            Debug.Log("Life lost!");
            collision.gameObject.SetActive(false);
            damageSound.PlayOneShot(damageSound.clip);

        }
    }

    void GameOver()
    {
        Debug.Log("game over!");
        Time.timeScale = 0f; //Game gets paused
        gameoverUI.SetActive(true);
    }

    void Win()
    {
        Debug.Log("You Win!");
        Time.timeScale = 0f; //Game gets paused
        //Indsæt Lil Carl der siger "What!?!?!"s
         tryAgainUI.SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
