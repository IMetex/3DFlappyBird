using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [Header("GameObject Referances")] [SerializeField]
    private GameObject _bird;

    [Header("Bird Value")] [SerializeField]
    private float _gravity;

    [SerializeField] private float _jump;

    private float verticalSpeed;
    public float VerticalSpeed => verticalSpeed;

    private void Start()
    {
        GameStarted();
    }

    private void Update()
    {
        if (GameManager.Instance.IsStarded)
        {
            verticalSpeed += -_gravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalSpeed = 0;
            verticalSpeed += _jump;
            UIState.Instance.GameStardedUI();
            GameManager.Instance.IsStarded = true;
        }
        BirdPosition();
    }

    public void GameStarted()
    {
        verticalSpeed = 0;
        _bird.transform.position = new Vector3(-5, 7, 0);
    }

    public void BirdPosition()
    {
        var newPos = Vector3.up * (verticalSpeed * Time.deltaTime);
        _bird.transform.position += newPos;

        _bird.transform.position = new Vector3(_bird.transform.position.x,
            Mathf.Clamp(_bird.transform.position.y, 1, 12),
            _bird.transform.position.z);
    }
}