using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;
    public Text highScoreText;
    public GameObject playButton;
    public GameObject pauseButton;
    public GameObject gameOver;
    public Player player;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Application.targetFrameRate = 60;
            Pause();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore", 0);
    }

    public void Play() 
    {
        score = 0;
        scoreText.text = score.ToString();

        player.transform.position = Vector2.zero;

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipe[] pipes = FindObjectsOfType<Pipe>();

        for (int i = 0; i < pipes.Length; i++) 
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause() 
    {
        Time.timeScale = 0.0f;
        player.enabled = false;
    }

    public void GameOver() 
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();

        int highScore = PlayerPrefs.GetInt("highScore", 0);
        if (score > highScore) 
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = "High Score: " + score;
        }
    }

    public void PlayerScores() 
    {
        score++;
        scoreText.text = score.ToString();
    }
}
