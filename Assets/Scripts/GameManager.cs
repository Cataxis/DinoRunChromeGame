using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bestScoreText;
    [SerializeField] private float initialScrollSpeed;

    int score;
    int bestScore;
    float timer;
    float scrollSpeed;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "Best: " + bestScore.ToString("000");
    }

    void Update()
    {
        UpdateScore();
        UpdateSpeed();
    }

    public void UpdateScore()
    {
        int scorePerSeconds = 2;

        timer += Time.deltaTime;
        score = (int)(timer * scorePerSeconds);

        scoreText.text = "Score: " + score.ToString("000");

        if (score > bestScore)
        {
            bestScore = score;
            bestScoreText.text = "Best: " + bestScore.ToString("000");

            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }

    private void UpdateSpeed()
    {
        float speedDivider = 10f;
        scrollSpeed = initialScrollSpeed + timer / speedDivider;
    }
}

