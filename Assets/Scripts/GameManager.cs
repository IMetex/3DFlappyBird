using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singletion<GameManager>
{
    [Header("Behavior Referance")] 
    [SerializeField] private BirdController _birdController;

    private bool _gameOver = false;
    private bool _isStarted = false;

    public bool GameOver
    {
        get => _gameOver;
        set => _gameOver = value;
    }
    
    public bool IsStarded
    {
        get => _isStarted;
        set => _isStarted = value;
    }


    private void Update()
    {
       Lost();
    }
    

    public void Lost()
    {
        if (_gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            _birdController.GameStarted();
            _gameOver = false;
            Restart();
        }
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
    
    
}