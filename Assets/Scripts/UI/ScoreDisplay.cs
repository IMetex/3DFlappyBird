using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : Singletion<ScoreDisplay>
{
    private int score;
    private int highScore;

    [Header("GameScreen UI Referances")] 
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;

    [Header("LoseUI Referances")] [SerializeField]
    private TMP_Text _paneScoreText;


    void Start()
    {
        score = 0;
        _scoreText.text = "Score: " + score.ToString();

        highScore = PlayerPrefs.GetInt("highscore");
        _highScoreText.text = "HighScore: " + highScore.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score"))
        {
            Scored();
        }
    }

    public void Scored()
    {
        score++;
        _scoreText.text = "Score: " + score.ToString();
        _paneScoreText.text = "Score: " + score.ToString();

        if (score > highScore)
        {
            highScore = score;
            _highScoreText.text = "High Score: " + highScore.ToString();
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }
}