using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestText;
    public GameObject gameOverPanel;

    [Header("Score Settings")]
    public float scoreRate = 1f; // 1 point per second

    private int score;
    private int bestScore;
    private float timer;

    public bool isGameOver = false;

    private const string BEST_KEY = "BEST_SCORE";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        score = 0;
        timer = 0f;
        isGameOver = false;

        bestScore = PlayerPrefs.GetInt(BEST_KEY, 0);

        scoreText.text = "Score: 0";
        bestText.text = "Best: " + bestScore;

        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        // بعد از Game Over هیچ چیزی آپدیت نشود
        if (isGameOver)
            return;

        timer += Time.deltaTime;

        if (timer >= 1f / scoreRate)
        {
            timer = 0f;
            score++;
            scoreText.text = "Score: " + score;

            if (score > bestScore)
            {
                bestScore = score;
                bestText.text = "Best: " + bestScore;
                PlayerPrefs.SetInt(BEST_KEY, bestScore);
                PlayerPrefs.Save();
            }
        }
    }

    public void GameOver()
    {
        if (isGameOver)
            return;

        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
