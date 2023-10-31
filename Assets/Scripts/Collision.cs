using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : Singletion<Collision>
{
    [SerializeField] private ParticleSystem _deadPartical;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver = true;
            _deadPartical.Play();
            UIState.Instance.GameLostUI();
        }
    }
}