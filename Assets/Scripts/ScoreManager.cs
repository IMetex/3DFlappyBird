using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int score;
    int highScore;
    Text scroeText;
    public Text panelScore;
    public Text panelHighScore;
    public GameObject newImage;
    


    void Start()
    {
        score = 0;
        scroeText = GetComponent<Text>();
        scroeText.text = score.ToString();
        panelScore.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highScore");
        panelHighScore.text = highScore.ToString();
    }
    public void Score()
    {
        score++;
        scroeText.text = score.ToString();
        panelScore.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            panelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highScore", highScore);
            newImage.SetActive(true);
        }
    }
    public int GetScored()
    {
        return score;
    }
}
