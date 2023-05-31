using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameManager gameManager;
    Rigidbody2D rb2;
    Animator anim;
    public float fishSpeed;
    private int angle;
    private int maxAngle = 20;
    private int minAngle = -60;
    bool touchGround;
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        FishSwim();
    }

    void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            rb2.velocity = new Vector2(rb2.velocity.x, fishSpeed);
        }
    }
    void FishRotation()
    {
        if (rb2.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle += 4;
            }
        }
        else if (rb2.velocity.y < -2.5f)
        {
            if (angle > minAngle)
            {
                angle -= 2;
            }
        }
        if (touchGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            scoreManager.Score();
        }
        else if (other.CompareTag("Column"))
        {
            gameManager.GameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                gameManager.GameOver();
                FishDead();
            }
            else
            {
                FishDead();
            }
        }
    }
    void FishDead()
    {
        touchGround = true;
        transform.rotation = Quaternion.Euler(0,0,-90);
        anim.enabled = false;
    }
}