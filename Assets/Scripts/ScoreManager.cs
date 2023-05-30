using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int score;
    Text scroeText;
    void Start()
    {
        score = 0;
        scroeText = GetComponent<Text>();
        scroeText.text = score.ToString();
    }
    public void Score()
    {
        score++;
        scroeText.text = score.ToString();
    }
}
