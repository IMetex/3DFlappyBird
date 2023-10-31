using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIState : Singletion<UIState>
{
    [Header("UI GameObjects")] 
    
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _scoreScreen;
    [SerializeField] private GameObject _loseScreen;
    

    public void GameStardedUI()
    {
        _gameScreen.SetActive(false);
        _scoreScreen.SetActive(true);
        
    }

    public void GameLostUI()
    {
        _scoreScreen.SetActive(false);
        _loseScreen.SetActive(true);
    }
}