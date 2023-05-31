using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    float timer;
    public float maxTime;
    private const float maxY = 2f;
    private const float minY = -2.5f;
    float randomY;

    void Start()
    {
        //InstantiateObstacle();
    }
    void Update()
    {
        if (GameManager.gameOver == false && GameManager.gameStarted == true)
        {
            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                InstantiateObstacle();
                timer = 0;
            }
        }
    }
    public void InstantiateObstacle()
    {
        randomY = Random.Range(minY, maxY);
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, randomY);
    }
}
