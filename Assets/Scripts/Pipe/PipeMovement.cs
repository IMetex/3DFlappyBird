using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float leftEdge;

    private void Update()
    {
        if (GameManager.Instance.GameOver)
            return;
        
        if (GameManager.Instance.IsStarded )
        {
            transform.position += Vector3.left * (_speed * Time.deltaTime);
        }

        if (transform.position.x < leftEdge)
        {
            transform.gameObject.SetActive(false);
        }
    }
}