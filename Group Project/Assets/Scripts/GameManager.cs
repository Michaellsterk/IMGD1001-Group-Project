using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject highscoreBackground;
    private int score;
    private int highscore;
    public Text highscoreText;

    private void Awake() {
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);
        highscoreBackground.SetActive(false);
        highscoreText.enabled = false;
        highscore = 0;
        highscoreText.text = highscore.ToString();
        Pause();
    }

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        highscoreBackground.SetActive(false);
        highscoreText.enabled = false;

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        foreach (Pipes pipe in pipes) {
            Destroy(pipe.gameObject);
        }
    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver() {
        if (score > highscore) {
            highscore = score;
            highscoreText.text=highscore.ToString();
        }
        highscoreBackground.SetActive(true);
        gameOver.SetActive(true);
        playButton.SetActive(true);
        highscoreText.enabled = true;
        Pause();
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }
}
