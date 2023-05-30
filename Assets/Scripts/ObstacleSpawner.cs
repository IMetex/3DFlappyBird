using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float maxTime;
    public float minY;
    public float maxY;
    float timer;
    float randomY;

    void Start()
    {
        InstantiateObtacle();
    }

    void Update()
    {
        SpawnTimer();

    }
    
    void InstantiateObtacle()
    {
        GameObject newObstacle = Instantiate(obstaclePrefab);
        newObstacle.transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    void SpawnTimer()
    {
        timer += Time.deltaTime;
        if (timer >= Time.deltaTime)
        {
            randomY = Random.Range(minY,maxY);
            InstantiateObtacle();
            timer = 0;

        }
    }
}
