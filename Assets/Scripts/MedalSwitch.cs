using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MedalSwitch : MonoBehaviour
{
    public Sprite bronzMedal, metalMedal, silverMedal, goldMedal;
    Image img;
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int gameScored = GameManager.gameScored;
        if (gameScored > 0 && gameScored <= 1)
        {
            img.sprite = metalMedal;
        }
        else if (gameScored > 1 && gameScored <= 2)
        {
            img.sprite = bronzMedal;
        }
        else if (gameScored > 2 && gameScored <= 3)
        {
            img.sprite = silverMedal;
        }
        else if (gameScored > 3)
        {
            img.sprite = goldMedal;
        }
    }
}
