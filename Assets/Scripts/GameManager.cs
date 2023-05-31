using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;
    public static bool gameStarted;
    public GameObject gameOverPanel;
    public GameObject gameReady;
    public GameObject score;
    public static int gameScored;
    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }
    private void Start()
    {
        gameOver = false;
        gameStarted = false;
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameStarted()
    {
        gameStarted = true;
        gameReady.SetActive(false);
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScored = score.GetComponent<ScoreManager>().GetScored();
    }
}
