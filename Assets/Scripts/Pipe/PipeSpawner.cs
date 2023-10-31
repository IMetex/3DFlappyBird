using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Referances")] [SerializeField]
    private GameObject _pipesHolder;

    [SerializeField] private Transform _spawnPoint;

    [Header("Spawn Rate")] [SerializeField]
    private float _spawnRate;

    [Header("Y Axis Border")] [SerializeField]
    private int _minHeight;

    [SerializeField] private int _maxHeight;


    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 0.1f, _spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        if (GameManager.Instance.GameOver)
            return;
        
        if (GameManager.Instance.IsStarded)
        {
            // GameObject pipes = Instantiate(_pipePrefab, transform.position, Quaternion.identity);
            GameObject pipes = ObjectPool.Instance.GetPooledObject();

            if (pipes != null)
            {
                pipes.transform.position = _spawnPoint.transform.position;
                pipes.transform.parent = _pipesHolder.transform;
                pipes.SetActive(true);

                pipes.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
            }
        }
    }
}