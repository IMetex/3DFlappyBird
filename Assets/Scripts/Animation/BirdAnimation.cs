using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    [Header("GameObjects Referances")]
    [SerializeField] private GameObject _wingsLeft;
    [SerializeField] private GameObject _wingsRight;
    [SerializeField] private GameObject _bird;
    
    [Header("Script Referances")]
    [SerializeField] private BirdController _birdController;


    private void Update()
    {
        if (!GameManager.Instance.GameOver)
        {
            WingAnimation();
        }
    }

    public void WingAnimation()
    {
        // nose dive
        float speedToRange = Mathf.InverseLerp(-10, 10, _birdController.VerticalSpeed);
        float noseAngle = Mathf.Lerp(-30, 30, speedToRange);
        _bird.transform.rotation = Quaternion.Euler(Vector3.forward * noseAngle) * Quaternion.Euler(Vector3.up * 20);

        // wings
        float flapSpeed = (_birdController.VerticalSpeed > 0) ? 30 : 5;
        float angle = Mathf.Sin(Time.time * flapSpeed) * 45;
        
        _wingsLeft.transform.localRotation = Quaternion.Euler(Vector3.left * angle);
        _wingsRight.transform.localRotation = Quaternion.Euler(Vector3.right * angle);
    }
}